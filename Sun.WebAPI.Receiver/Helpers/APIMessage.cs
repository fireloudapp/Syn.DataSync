using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sun.WebAPI.Receiver.Helpers
{
    public class APIMessage<T>
    {
        public IActionResult ActionResultData { get; set; }
        public T DataModel { get; set; }
    }
}
