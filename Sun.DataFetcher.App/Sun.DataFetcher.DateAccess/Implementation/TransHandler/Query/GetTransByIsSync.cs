using Sun.DataFetcher.DateAccess.Interface;
using Sun.DataFetcher.DateAccess.SQLText;
using Sun.DataSync.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using SystemGeneric.DataAccess.MySQL;

namespace Sun.DataFetcher.DateAccess.Implementation.TransHandler
{
    public class GetTransByIsSync : IQueryByIsSync<Trans>
    {
        #region Declaraion
        IGenericRepository _repository = null;
        #endregion

        #region Constructor

        public GetTransByIsSync(string connectionString) 
        {
            _repository = new GenericRepository(connectionString);
        }
        #endregion

        #region Execute Query
        public IEnumerable<Trans> GetHandler(int isSync = 0, string limit = "15")
        {
            GenericParameter genericParameter = new GenericParameter
            {
                SqlCommand = TransSQL.GET_BYSYNC,
                ExecuteType = CommandType.Text
            };
            #region Filter Parameter
            genericParameter.SqlCommand = genericParameter.SqlCommand.Replace("#Limit#", limit);
            genericParameter.InputParameters.Add("@IsSync", isSync);
            #endregion

            var dataList = _repository.ExecuteQueryList<Trans>(genericParameter);
            return dataList;
        }
        #endregion
    }
}
