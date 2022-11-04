using Sun.DataSync.Domain;
using Sun.RDS.Sync.DataAccess.Interface;
using Sun.RDS.Sync.DataAccess.Models;
using Sun.RDS.Sync.DataAccess.Query;
using System.Data;
using SystemGeneric.DataAccess.MySQL;

namespace Sun.RDS.Sync.DataAccess.Implementation.TransHandler.Command
{
    public class DeleteTransDetailHandler : BaseDataAccess, ICommand<TransDetail>
    {
        #region Constructor
        public DeleteTransDetailHandler(string connectionString) : base(connectionString)
        {

        }
        #endregion

        #region Command Handler        
        public TransDetail CommandHandler(TransDetail sourceModel)
        {
            GenericParameter genericParameter = new GenericParameter
            {
                SqlCommand = TransSQL.DELETE_TRANSDETAIL,
                ExecuteType = CommandType.Text
            };

            #region Filter Parameter
            genericParameter.InputParameters.Add("@TransID", sourceModel.TransID);
            #endregion            

            repository.ExecuteScalar<string>(genericParameter);
            return sourceModel;
        }

        #endregion
    }
}
