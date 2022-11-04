using Sun.DataSync.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.RDS.Sync.DataAccess.Models
{
    public class TransTransactionModel
    {
        public Trans TransModel { get; set; }
        public IList<TransDetail> TransDetailList { get; set; }
    }
}
