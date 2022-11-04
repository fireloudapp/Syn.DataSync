using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Helper.Domains;
using RabbitMQ.Helper.Engine;
using Sun.DataSync.Domain;
using Sun.DataSync.Domain.Enumerables;
using Sun.DataSync.Domain.Generate;
using Sun.WebAPI.Receiver.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using SystemGeneric.Loggers;

namespace Sun.WebAPI.Receiver.Controllers
{
    //[Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ReceiverTransController : ControllerBase
    {
        #region Variables
        private readonly IConfiguration _configuration;
        RabbitMQConfiguration _rabbitMQConfig;
        PushMessage _pushMessage;
        #endregion

        #region Constructor
        public ReceiverTransController(IConfiguration configuration)
        {
            _configuration = configuration;            
            _rabbitMQConfig = new RabbitMQConfiguration()
            {
                URL = _configuration.GetValue<string>("RabbitMQ:URL"),
                UserName = _configuration.GetValue<string>("RabbitMQ:UserName"),
                Password = _configuration.GetValue<string>("RabbitMQ:Password")   
                //Queue & RouteKey should be initialized during execution, else "Request" might thorw error.
            };
                    
        }
        #endregion

        #region POST API's
        
        [Route("api/ReceiveTrans")]
        [HttpPost]
        public async Task<APIMessage<TransactionModel>> ReceiveMessage([FromBody] object obj)
        {
            APIMessage<TransactionModel> message = null;
            
            try
            {
                var model = JsonConvert.DeserializeObject<TransactionModel>(obj.ToString()); //Convert the object into TransactionModel, WebAPI does not accepts complex data type hence convertion from obj to string => then serialize to destination object is required. 

                using (var trace = new TraceTree())
                {
                    _rabbitMQConfig.QueueName = Request.Headers["QueueName"];
                    _rabbitMQConfig.RoutingKey = Request.Headers["RoutingKey"];
                    _pushMessage = new PushMessage(_rabbitMQConfig);
                    message = new APIMessage<TransactionModel>();
                   
                    bool result = await _pushMessage.SendMessageAsync(model);
                    if (result)
                    {
                        message.ActionResultData = Ok("Success");
                        //It does not requires the model to return, it will have imact.
                        //message.DataModel = model;
                        //message.DataModel.ModelTypeValue = ModelType.Trans;//Type based on transaction.
                    }
                    else
                    {
                        message.ActionResultData = BadRequest("Message Failed to send. Please retry after sometimes.");
                        //message.DataModel = model;
                    }
                }
            }
            catch (Exception ex)
            {
                message.ActionResultData = BadRequest(ex.Message);
                Logger.Log.Error(ex, MethodBase.GetCurrentMethod().Name);
                var modelData = JsonConvert.SerializeObject(obj);
                Logger.Log.Warning(modelData);                
            }
            return message;
        }
       
        #endregion

        #region GET API's
        [HttpGet]
        [Route("api/test")]
        public APIMessage<string> TestReceives(string someMessage)
        {
            APIMessage<string> message = null;
            try
            {
                message = new APIMessage<string>();
                message.ActionResultData = Ok();
                message.DataModel = someMessage;
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex, MethodBase.GetCurrentMethod().Name);
                message.ActionResultData = BadRequest(ex.Message);
            }

            return message;
        }

        [HttpGet]
        [Route("api/GenerateFakeTrans")]
        public APIMessage<TransactionModel> Generate()
        {
            APIMessage<TransactionModel> message = null;
            try
            {
                message = new APIMessage<TransactionModel>();
                message.ActionResultData = Ok();
                message.DataModel = TransGenerateCode.GetTrans();
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex, MethodBase.GetCurrentMethod().Name);
                message.ActionResultData = BadRequest(ex.Message);
            }

            return message;
        }
        #endregion
    }

    

}
