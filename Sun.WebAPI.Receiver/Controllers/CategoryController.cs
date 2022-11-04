using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Helper.Domains;
using RabbitMQ.Helper.Engine;
using Sun.WebAPI.Receiver.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using SystemGeneric.Loggers;

namespace Sun.WebAPI.Receiver.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        #region Variables
        private readonly IConfiguration _configuration;
        RabbitMQConfiguration _rabbitMQConfig;
        PushMessage _pushMessage;
        #endregion

        #region Constructor
        public CategoryController(IConfiguration configuration)
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


        [Route("api/receiveCategoryTest")]
        [HttpPost]
        public async Task<APIMessage<Category>> ReceiveTest([FromBody] Category model)
        {
            APIMessage<Category> message = null;
            try
            {
                using (var trace = new TraceTree())
                {
                    _rabbitMQConfig.QueueName = "SampleClient";
                    _rabbitMQConfig.RoutingKey = "SampleClient";
                    _pushMessage = new PushMessage(_rabbitMQConfig);
                    message = new APIMessage<Category>();
                    bool result = await _pushMessage.SendMessageAsync(model);
                    if (result)
                    {
                        message.ActionResultData = Ok();
                        message.DataModel = model;
                    }
                    else
                    {
                        message.ActionResultData = BadRequest("Message Failed to send. Please retry after sometimes.");
                        message.DataModel = model;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex, MethodBase.GetCurrentMethod().Name);
                message.ActionResultData = BadRequest(ex.Message);
            }
            return message;
        }

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
        #endregion

    }

    public class Category
    {
        public string Description { get; set; }
        public string Picture { get; set; }
        public bool IsActive { get; set; } = true;
        public int CreatedBy { get; set; }

    }
}
