using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.RDS.Sync.DataAccess.Interface
{
    public interface IQueryById<TModel>
    {
        TModel GetHandler(long id);
    }
}
