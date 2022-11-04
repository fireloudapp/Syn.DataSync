using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Sun.RDS.Sync.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Configuration;
using Sun.DataSync.Domain;
using Newtonsoft.Json;
using Sun.DataSync.Domain.Enumerables;
using Sun.RDS.Sync.Service.Helper;
using Sun.RDS.Sync.Service.Syncronize;
using SystemGeneric.Loggers;
using System.Reflection;
using System.Diagnostics;
using Microsoft.Extensions.Hosting;

namespace Sun.RDS.Sync.Service.Rabbit
{
    public class ReceiveService : IHostedService, IDisposable
    {
        #region Declaration        
        static IConnection _connection = null;
        ProjectInfo _projectConfig;
        #endregion

        #region Constructor
        public ReceiveService()
        {
            _projectConfig = new ProjectInfo();
            _projectConfig.UserName = ConfigurationManager.AppSettings["UserName"];
            _projectConfig.Password = ConfigurationManager.AppSettings["Password"];
            _projectConfig.URL = ConfigurationManager.AppSettings["RabbitMQ_URL"];
            _projectConfig.TransactionQueue = ConfigurationManager.AppSettings["ListenerQueue"];
            Logger.Log.Information("ReceiverConfiguration Details");
            Logger.Log.Information(_projectConfig.ToString());
            Logger.Log.Information(Environment.NewLine);

            _connection = GetConnection(_projectConfig);
        }
        #endregion

        public Task StartAsync(CancellationToken cancellationToken)
        {
            if (_connection != null)
            {
                IModel channel = GetConnection(_projectConfig).CreateModel();
                //IModel channel = _connection.CreateModel();
                DataRecevier(channel, _projectConfig.TransactionQueue);
            }
            return Task.CompletedTask;
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
        /// <summary>
        /// Trace log queue message receving method
        /// </summary>
        /// <param name="channel">rabbit mq connection model</param>
        /// <param name="queueName">trace log queue name</param>
        public void DataRecevier(IModel channel, string queueName)
        {
            try
            {
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    Logger.Log.Information("Message Received.");
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);

                    SaveToRDS(message, channel, ea);
                    // acknowledge receipt of the message, will be done in "SaveToRDS" Method.

            };
                channel.BasicConsume(queue: queueName,
                    autoAck: false,
                    consumer: consumer);
            }
            catch(Exception ex)
            {
                Logger.Log.Error(ex, MethodBase.GetCurrentMethod().Name);
            }
        }

        void SaveToRDS(string message, IModel channel, BasicDeliverEventArgs ea)
        {            
            Logger.Log.Information("SaveToRDS Started");
            try
            {
                TransactionModel model = JsonConvert.DeserializeObject<TransactionModel>(message);
                bool canAcknowledge = false;
                ISyncronize syncronize;
                switch (model.ModelTypeValue)
                {
                    case ModelType.Trans:
                        syncronize = new TransSyncronizer();
                        canAcknowledge = syncronize.Execute(model); 
                        break;
                    case ModelType.Sample:
                        //This is an example. By this way we should expand other transaction tables.
                        //syncronize = new SampleSyncronizer();
                        //syncronize.Execute(model);
                        //Other tables/transaction to be handled.
                        break;
                    case ModelType.WebKDS:
                        //Initiate the class for WebKDSSyncronizer()
                        //syncronize = new WebKDSSyncronizer();
                        //canAcknowledge = syncronize.Execute(model);
                        break;
                    default:
                        break;
                }

                if (canAcknowledge)
                {
                    //Acknowledge the RabbitMQ
                    channel.BasicAck(ea.DeliveryTag, true); 
                    Logger.Log.Information("RabbitMQ Acknowledged : " + ea.ConsumerTag);
                }
                else
                {
                    Logger.Log.Warning("Not Acked Message");
                    Logger.Log.Information(message);
                    Logger.Log.Error("Something went wrong message not 'Acknowledged'.");
                }
            }
            catch (Exception ex)
            {               
                Logger.Log.Error(ex, MethodBase.GetCurrentMethod().Name);
            }
            Logger.Log.Information("SaveToRDS Completed" + Environment.NewLine);

        }
        /// <summary>
        /// Create rabbitmq connection
        /// </summary>
        /// <param name="projectInfo">project related info like hostname,portnumber etc..</param>
        /// <returns>return rabbitmq connection</returns>
        static IConnection GetConnection(ProjectInfo projectInfo)
        {
            IConnection connection = null;
            try
            {
                ConnectionFactory factory = new ConnectionFactory
                {
                    Uri = new Uri(projectInfo.URL),
                    UserName = projectInfo.UserName,
                    Password = projectInfo.Password,
                };               
                projectInfo = null;
                connection = factory.CreateConnection();
            }
            catch(Exception ex)
            {
                Logger.Log.Error(ex.Demystify(), MethodBase.GetCurrentMethod().Name);
            }
            return connection;
        }

        public void Dispose()
        {
            _connection?.Dispose();
            _connection = null;
        }
    }
}
