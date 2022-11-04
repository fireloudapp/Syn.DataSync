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
    public class GenTransDetailsById : IQueryById<TransDetail>
    {
        #region Declaraion
        IGenericRepository _repository = null;
        #endregion

        #region Constructor

        public GenTransDetailsById(string connectionString)
        {
            _repository = new GenericRepository(connectionString);
        }
        #endregion

        #region Execute Query
        public IEnumerable<TransDetail> GetHandler(int parentId = 0)
        {
            GenericParameter genericParameter = new GenericParameter
            {
                SqlCommand = TransSQL.GET_BY_TRANSID,
                ExecuteType = CommandType.Text
            };
            #region Filter Parameter
            genericParameter.InputParameters.Add("@TransID", parentId);
            #endregion

            var dataList = _repository.ExecuteQueryList<TransDetail>(genericParameter);
            return dataList;
        }
        #endregion
    }
}
