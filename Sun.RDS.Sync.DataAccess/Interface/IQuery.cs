using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.RDS.Sync.DataAccess.Interface
{
    public interface IQuery<TModel>
    {
        IEnumerable<TModel> GetHandler(TModel model);
    }
}
