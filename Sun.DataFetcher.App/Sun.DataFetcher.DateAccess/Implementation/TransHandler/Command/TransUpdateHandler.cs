using Sun.DataFetcher.DateAccess.Interface;
using Sun.DataFetcher.DateAccess.SQLText;
using Sun.DataSync.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;
using SystemGeneric.DataAccess.MySQL;
using SystemGeneric.Loggers;

namespace Sun.DataFetcher.DateAccess.Implementation.TransHandler.Command
{
    public class TransUpdateHandler : IUpdate<Trans>
    {
        #region Declaraion
        IGenericRepository _repository = null;
        #endregion

        #region Constructor
        public TransUpdateHandler(string connectionString)
        {
            _repository = new GenericRepository(connectionString);
        }
        #endregion

        #region Execute Query
        public bool GetHandler(int parentId = 0, int isSync = 0)
        {
            bool result = false;
            try
            {
                GenericParameter genericParameter = new GenericParameter
                {
                    SqlCommand = TransSQL.UPDATE_SYNC,
                    ExecuteType = CommandType.Text
                };

                #region Filter Parameter
                genericParameter.InputParameters.Add("@TransID", parentId);
                genericParameter.InputParameters.Add("@IsSync", isSync);
                #endregion

                _repository.ExecuteCommand(genericParameter);
                result = true;
            }
            catch(Exception ex)
            {   
                Logger.Log.Error(ex, MethodBase.GetCurrentMethod().Name);
                result = false;
            }
            
            return result;
        }
        #endregion
    }
}
