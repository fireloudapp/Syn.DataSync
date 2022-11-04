using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.RDS.Sync.DataAccess.Interface
{
    public interface ICommand<TModel>
    {
        TModel CommandHandler(TModel model);
    }
}
