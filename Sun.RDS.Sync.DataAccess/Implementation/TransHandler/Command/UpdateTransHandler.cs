using Sun.DataSync.Domain;
using Sun.RDS.Sync.DataAccess.Interface;
using Sun.RDS.Sync.DataAccess.Models;
using Sun.RDS.Sync.DataAccess.Query;
using System.Data;
using SystemGeneric.DataAccess.MySQL;

namespace Sun.RDS.Sync.DataAccess.Implementation.TransHandler.Command
{
    public class UpdateTransHandler : BaseDataAccess, ICommand<Trans>
    {
        #region Constructor
        public UpdateTransHandler(string connectionString) : base(connectionString)
        {

        }
        #endregion

        #region Command Handler        
        public Trans CommandHandler(Trans sourceModel)
        {
            GenericParameter genericParameter = new GenericParameter
            {
                SqlCommand = TransSQL.UPDATE_TRANS ,
                ExecuteType = CommandType.Text
            };

            #region Parameter Settings
            genericParameter = GenericRepository.ConstructParameter<UpdateTransModel, Trans>(sourceModel, new UpdateTransModel(), genericParameter);
            #endregion

            repository.ExecuteCommand(genericParameter);
            return sourceModel;
        }

        #endregion
    }
}
