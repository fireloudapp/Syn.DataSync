using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using SystemGeneric.Loggers;

namespace Sun.WebAPI.Library
{
    [Route("api/[controller]")]
    [ApiController]
    public class GaneshController : ControllerBase
    {
        #region Variables
        private readonly IConfiguration _configuration;
        
        #endregion

        #region Constructor
        public GaneshController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        #endregion

        
        #region GET API's
        [HttpGet]
        [Route("api/ganeshTest")]
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
    public class APIMessage<T>
    {
        public IActionResult ActionResultData { get; set; }
        public T DataModel { get; set; }
    }
}
