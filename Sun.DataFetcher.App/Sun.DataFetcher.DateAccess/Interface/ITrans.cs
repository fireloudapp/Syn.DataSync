using Sun.DataSync.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.DataFetcher.DateAccess.Interface
{
    public interface IQueryByIsSync<TModel>
    {
        IEnumerable<TModel> GetHandler(int isSync = 0, string limit = "15");
    }
    public interface IQueryById<TModel>
    {
        IEnumerable<TModel> GetHandler(int parentId = 0);
    }

    public interface IUpdate<TModel>
    {
        bool GetHandler(int parentId = 0, int isSync = 0);
    }
}
