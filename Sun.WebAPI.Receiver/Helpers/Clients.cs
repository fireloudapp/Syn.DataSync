using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sun.WebAPI.Receiver.Helpers
{

    public class ClientSettings //NotificationSettings
    {
        public TimeSpan NotificationInterval { get; set; }
        public short TokenExpiryInDays { get; set; }
        public TimeSpan TimeoutInterval { get; set; }
        public bool IsImplicit { get; set; }
        public List<NotificationSource> Sources { get; set; }

        //public NotificationSetting()
        //{
        //    IsImplicit = true;
        //    TimeoutInterval = TimeSpan.FromSeconds(30);
        //}
    }
   

    public class NotificationSource
    {
        public Uri Url { get; set; }        
        public string User { get; set; }
        public string Secret { get; set; }
        public string Queue { get; set; }
    }

    public class ClientsData
    {
        public List<Client> ClientInfo { get; set; }
    }
    public class Clients
    {
        public IList<Client> ClientList { get; set; }
    }
    public class Client
    {
        public string UserName { get; set; }
        public string SecretKey { get; set; }
        public string QueueName { get; set; }
    }
}
