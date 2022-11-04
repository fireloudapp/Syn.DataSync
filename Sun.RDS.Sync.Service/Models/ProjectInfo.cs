using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.RDS.Sync.Service.Models
{
    public class ProjectInfo
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string URL { get; set; }
        public string HostName { get; set; }
        public string TransactionQueue { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
