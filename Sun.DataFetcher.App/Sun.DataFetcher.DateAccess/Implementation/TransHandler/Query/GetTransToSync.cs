using Sun.DataFetcher.DateAccess.Interface;
using Sun.DataSync.Domain;
using Sun.DataSync.Domain.Enumerables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using SystemGeneric.DataAccess.MySQL;
using SystemGeneric.Loggers;

namespace Sun.DataFetcher.DateAccess.Implementation.TransHandler
{
    public class GetTransToSync : IQueryByIsSync<TransactionModel>
    {
        #region Declaraion
        string _connString = null;
        #endregion

        #region Constructor

        public GetTransToSync(string connectionString)
        {
            _connString = connectionString;
        }
        #endregion

        #region Execute Query
        public IEnumerable<TransactionModel> GetHandler(int isSync = 0, string limit = "15")
        {
            //1. Initialize the Transaction Model for binding trans and transDetails
            IList<TransactionModel> transactionModelList = new List<TransactionModel>();

            //2. Get Trans List 
            IQueryByIsSync<Trans> queryByIsSync = new GetTransByIsSync(_connString);
            IEnumerable<Trans> transList = queryByIsSync.GetHandler(isSync, limit);

            foreach (var trans in transList)
            {
                //3. Adding the Trans to TransactionModel List.
                TransactionModel transactionModel = new TransactionModel();
                transactionModel.ModelTypeValue = ModelType.Trans;
                transactionModel.MasterTable = trans;
                IQueryById<TransDetail> transDetails = new GenTransDetailsById(_connString);
                IEnumerable<TransDetail> transDetailList = transDetails.GetHandler(trans.TransID);
                Logger.Log.Information(string.Format("Trans Id: {0} Trans Detail Count : {1}", trans.TransID, transDetailList.Count()));
                transactionModel.ChildList1 = transDetailList.ToList();
                //4. Added to list
                transactionModelList.Add(transactionModel);
            }
            
            return transactionModelList;
        }
        #endregion
    }
}
