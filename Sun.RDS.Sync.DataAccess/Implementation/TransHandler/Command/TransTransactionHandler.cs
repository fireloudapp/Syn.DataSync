using Sun.DataSync.Domain;
using Sun.RDS.Sync.DataAccess.Implementation.TransHandler.Command;
using Sun.RDS.Sync.DataAccess.Implementation.TransHandler.Query;
using Sun.RDS.Sync.DataAccess.Interface;
using Sun.RDS.Sync.DataAccess.Models;
using Sun.RDS.Sync.DataAccess.Query;
using System;
using System.Data;
using System.Reflection;
using SystemGeneric.DataAccess.MySQL;
using SystemGeneric.Loggers;

namespace Sun.RDS.Sync.DataAccess.Implementation.TransHandler
{
    public class TransTransactionHandler : BaseDataAccess, ICommand<TransTransactionModel>
    {
        string _conString;
        #region Constructor
        public TransTransactionHandler(string connectionString) : base(connectionString)
        {
            _conString = connectionString;
        }
        #endregion

        #region Command Handler        
        public TransTransactionModel CommandHandler(TransTransactionModel sourceModel)
        {
            try
            {
                if (sourceModel.TransModel == null)
                {
                    Logger.Log.Warning( "TransTransactionModel.TransModel is null");
                }
                else
                {
                    //Check if Tran Already Exists
                    IQueryById<Trans> getTrans = new GetTransById(_conString);
                    Trans existinTrans = getTrans.GetHandler(sourceModel.TransModel.TransID);
                    if (existinTrans == null)
                    {
                        //'Trans' data does not exists hence create new one.
                        Logger.Log.Information("TransModel Creation Initiated");
                        CreateTrans(sourceModel);
                    }
                    else
                    {
                        //'Trans' data already exists hence Update the 'Trans'
                        Logger.Log.Information("TransModel Update Initiated");
                        UpdateTrans(sourceModel);
                    }
                    Logger.Log.Information("Completed " + nameof(TransTransactionHandler));
                }
                //Catch is not handled, because it has been addressed in caller method.
            }
            finally
            {
                repository.Dispose();
            }

            return sourceModel;
        }

        private void CreateTrans(TransTransactionModel sourceModel)
        {
            //1. First Child Item has to be inserted 
            InsertOrUpdateChildItems_TransDetail(sourceModel);
            //2. Parent Table inserted at last to make consistency
            ICommand<Trans> transCommand = new CreateTransHandler(_conString);
            transCommand.CommandHandler(sourceModel.TransModel);
            Logger.Log.Information("Trans Created : " + sourceModel.TransModel.TransID);
        }

        private void UpdateTrans(TransTransactionModel sourceModel)
        {
            //In Update case first parent has to be updated then child.   
            //1. Parent Table inserted at last to make consistency
            ICommand<Trans> transCommand = new UpdateTransHandler(_conString);
            transCommand.CommandHandler(sourceModel.TransModel);
            Logger.Log.Information("Trans Updated : " + sourceModel.TransModel.TransID);
            //2. Delete & Insert Child Item
            InsertOrUpdateChildItems_TransDetail(sourceModel);
            
        }

        /// <summary>
        /// Usually the handles child items. in our case it is "TransDetail"
        /// </summary>
        /// <param name="sourceModel"></param>
        private void InsertOrUpdateChildItems_TransDetail(TransTransactionModel sourceModel)
        {
            //2. Delete the Child Item.
            // child items should always be deleted and then inserted. It is the better way of handling data consistency)
            foreach (var transDetail in sourceModel.TransDetailList)
            {
                ICommand<TransDetail> transDetailCommand = new DeleteTransDetailHandler(_conString);
                transDetailCommand.CommandHandler(transDetail);
                Logger.Log.Warning("TransDetail Deleted : " + transDetail.TransID);
            }

            //3. Child Item has to be inserted 
            foreach (var transDetail in sourceModel.TransDetailList)
            {
                ICommand<TransDetail> transDetailCommand = new CreateTransDetailHandler(_conString);
                transDetailCommand.CommandHandler(transDetail);
                Logger.Log.Information("TransDetail Created : " + transDetail.TransID);
            }
            
        }

        #endregion
    }
}
