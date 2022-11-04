using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Sun.DataSync.Domain.Enumerables;

namespace Sun.DataSync.Domain
{
    /// <summary>
    /// This is a common Transaction Model, which is used to send and receive the message/model as a JSON Data.
    /// </summary>
    public class TransactionModel
    {
        /// <summary>
        /// Model type is the definition of transaction type, it can be a transaction name or a table name.
        /// </summary>
        [JsonProperty("modelTypeValue")]
        public ModelType ModelTypeValue { get; set; } 
        //If you need to handle additional table or transaction add another property as dynamic and reuse the same for rest of all the transactions.
        //Example: Provided below
        [JsonProperty("master")]
        public dynamic MasterTable { get; set; }//Tans
        [JsonProperty("childList1")]
        public dynamic ChildList1 { get; set; } // TansDetails as a list
        [JsonProperty("childList2")]
        public dynamic ChildList2 { get; set; }
        [JsonProperty("childList3")]
        public dynamic ChildList3 { get; set; }
        [JsonProperty("childList4")]
        public dynamic ChildList4 { get; set; }
        [JsonProperty("childList5")]
        public dynamic ChildList5 { get; set; }
        //etc.. 

    }
}
