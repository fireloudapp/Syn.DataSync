using Newtonsoft.Json;
using Sun.DataSync.Domain;
using Sun.RDS.Sync.DataAccess.Implementation.TransHandler;
using Sun.RDS.Sync.DataAccess.Interface;
using Sun.RDS.Sync.DataAccess.Models;
using Sun.RDS.Sync.Service.Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Text;
using SystemGeneric.Loggers;

namespace Sun.RDS.Sync.Service.Syncronize
{
    public class TransSyncronizer : ISyncronize
    {
        string _connString = string.Empty;
        public TransSyncronizer()
        {
            _connString = ConfigurationManager.AppSettings["RDSDataBase"];
            Logger.Log.Information("TranSyncronizer - Initialized");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Execute(TransactionModel model)
        {
            bool result = false;
            try
            {
                ICommand<TransTransactionModel> command = new TransTransactionHandler(_connString);
                TransTransactionModel transTransactionModel = new TransTransactionModel();
                
                transTransactionModel.TransModel = JsonConvert.DeserializeObject<Trans>(model.MasterTable.ToString());
                transTransactionModel.TransDetailList = JsonConvert.DeserializeObject<List<TransDetail>>(model.ChildList1.ToString());                
                command.CommandHandler(transTransactionModel);
                result = true;
            }
            catch(Exception ex)
            {
                Logger.Log.Error(ex, MethodBase.GetCurrentMethod().Name);
                result = false;
            }
            Logger.Log.Information("TranSyncronizer - Completed");
            return result;
        } 
    }
}
