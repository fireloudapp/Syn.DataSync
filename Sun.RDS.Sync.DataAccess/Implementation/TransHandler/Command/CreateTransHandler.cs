using Sun.DataSync.Domain;
using Sun.RDS.Sync.DataAccess.Interface;
using Sun.RDS.Sync.DataAccess.Models;
using Sun.RDS.Sync.DataAccess.Query;
using System.Data;
using SystemGeneric.DataAccess.MySQL;

namespace Sun.RDS.Sync.DataAccess.Implementation.TransHandler
{
    public class CreateTransHandler : BaseDataAccess, ICommand<Trans>
    {
        #region Constructor
        public CreateTransHandler(string connectionString) :base(connectionString)
        {
           
        }
        #endregion

        #region Command Handler        
        public Trans CommandHandler(Trans sourceModel)
        {
            GenericParameter genericParameter = new GenericParameter
            {
                SqlCommand = TransSQL.INSERT_TRANS + GET_LAST_RECORD,
                ExecuteType = CommandType.Text
            };

            #region Parameter Settings
            genericParameter = GenericRepository.ConstructParameter<CreateTransModel, Trans>(sourceModel, new CreateTransModel(), genericParameter);
            #endregion

            var resultId = repository.ExecuteScalar<string>(genericParameter);
            //sourceModel.TransID = int.Parse(resultId); Not Required, because the primary column is not auto generated, if auto generated column just enable this line.
            return sourceModel;
        }

        #endregion
    }
}
