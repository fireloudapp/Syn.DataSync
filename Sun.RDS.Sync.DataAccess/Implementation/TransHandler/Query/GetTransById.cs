using Sun.DataSync.Domain;
using Sun.RDS.Sync.DataAccess.Interface;
using Sun.RDS.Sync.DataAccess.Models;
using Sun.RDS.Sync.DataAccess.Query;
using System.Data;
using SystemGeneric.DataAccess.MySQL;

namespace Sun.RDS.Sync.DataAccess.Implementation.TransHandler.Query
{
    public class GetTransById : BaseDataAccess, IQueryById<Trans>
    {
        #region Constructor
        public GetTransById(string connectionString) : base(connectionString)
        {

        }
        #endregion

        #region Execute Query
        public Trans GetHandler(long id)
        {
            GenericParameter genericParameter = new GenericParameter
            {
                SqlCommand = TransSQL.GET_BY_ID,
                ExecuteType = CommandType.Text
            };
            #region Filter Parameter
            genericParameter.InputParameters.Add("@TransID", id);
            #endregion

            var dataModel = repository.ExecuteScalar<Trans>(genericParameter);
            return dataModel;
        }
        #endregion
    }
}
