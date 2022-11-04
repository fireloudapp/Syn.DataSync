using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Helper.Domains;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SystemGeneric.Loggers;

namespace RabbitMQ.Helper.Engine
{
    /// <summary>
    /// Push Message to Rabbit MQ
    /// </summary>
    public class PushMessage
    {
        ConnectionFactory _factory = null;
        RabbitMQConfiguration _mQConfig = null;
        public PushMessage(RabbitMQConfiguration mQConfig)
        {
            _factory = new ConnectionFactory() { };
            _factory.Uri = new Uri(mQConfig.URL);
            _factory.UserName = mQConfig.UserName;
            _factory.Password = mQConfig.Password;
            _factory.VirtualHost = @"SRG_Host";
            _mQConfig = mQConfig;            
            
        }
        /// <summary>
        /// Sends the message to RabbitMQ Service in Async way
        /// </summary>
        /// <typeparam name="T">Model Type</typeparam>
        /// <param name="messageModel">Model Data</param>
        /// <returns>bool</returns>
        public Task<bool> SendMessageAsync<T>(T messageModel)
        {
            var result = Task.Run(() => SendMessage(messageModel));
            return result;
        }
        /// <summary>
        /// Sends the message to RabbitMQ Service
        /// </summary>
        /// <typeparam name="T">Model Type</typeparam>
        /// <param name="messageModel">Model Data</param>
        /// <returns>bool</returns>
        public bool SendMessage<T>(T messageModel)
        {
            bool result = false;
            try
            {                 
                using (var connection = _factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: _mQConfig.QueueName,
                                         durable: true,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);
                    string message = JsonConvert.SerializeObject(messageModel, Formatting.Indented);

                    var body = Encoding.UTF8.GetBytes(message);
                    var properties = channel.CreateBasicProperties();
                    properties.Persistent = true;
                    
                    channel.BasicPublish(exchange: "",
                                         routingKey: _mQConfig.RoutingKey,
                                         basicProperties: properties,
                                         body: body);
                    
                    Console.WriteLine("[x] Sent {0}", message);

                }
                result = true;
            }
            catch(Exception ex)
            {
                result = false;
                Logger.Log.Error(ex, MethodBase.GetCurrentMethod().Name);
            }
            return result;            
        }
    }
}
