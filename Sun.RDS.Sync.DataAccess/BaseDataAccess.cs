using System;
using System.Collections.Generic;
using System.Text;
using SystemGeneric.DataAccess.MySQL;

namespace Sun.RDS.Sync.DataAccess
{
    public class BaseDataAccess
    {
        #region Declaration
        protected IGenericRepository repository = null;
        public const string GET_LAST_RECORD = @"SELECT LAST_INSERT_ID();";
        #endregion

        #region Constructor
        public BaseDataAccess(string connectionString)
        {
            repository = new GenericRepository(connectionString);
        }
        #endregion


    }
}
