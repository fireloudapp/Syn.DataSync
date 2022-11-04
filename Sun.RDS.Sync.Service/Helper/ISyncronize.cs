using Sun.DataSync.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.RDS.Sync.Service.Helper
{
    public interface ISyncronize
    {
        bool Execute(TransactionModel model);
    }
}
