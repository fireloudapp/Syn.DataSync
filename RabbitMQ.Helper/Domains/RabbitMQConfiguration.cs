using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.Helper.Domains
{
    public class RabbitMQConfiguration
    {
        public string URL { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string QueueName { get; set; }
        public string RoutingKey { get; set; }
    }
}
