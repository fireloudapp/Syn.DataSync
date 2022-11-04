using Sun.DataSync.Domain;
using Sun.RDS.Sync.DataAccess.Interface;
using Sun.RDS.Sync.DataAccess.Models;
using Sun.RDS.Sync.DataAccess.Query;
using System.Data;
using SystemGeneric.DataAccess.MySQL;

namespace Sun.RDS.Sync.DataAccess.Implementation.TransHandler
{    
    public class CreateTransDetailHandler : BaseDataAccess, ICommand<TransDetail>
    {
        #region Constructor
        public CreateTransDetailHandler(string connectionString) : base(connectionString)
        {

        }
        #endregion

        #region Command Handler        
        public TransDetail CommandHandler(TransDetail sourceModel)
        {
            GenericParameter genericParameter = new GenericParameter
            {
                SqlCommand = TransSQL.INSERT_TRANSDETAIL + GET_LAST_RECORD,
                ExecuteType = CommandType.Text
            };

            #region Parameter Settings
            genericParameter = GenericRepository.ConstructParameter<CreateTransDetailModel, TransDetail>(sourceModel, new CreateTransDetailModel(), genericParameter);
            #endregion

            repository.ExecuteScalar<string>(genericParameter);
            return sourceModel;
        }

        #endregion
    }
}
