using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.DataFetcher.DateAccess.SQLText
{
    public static class TransSQL
    {
        #region GET Query
        public const string GET_BYSYNC = " SELECT * FROM trans WHERE IsSync=@IsSync order by TransDate desc Limit #Limit#;";
        public const string GET_BY_TRANSID = " SELECT * from transdetail WHERE TransID = @TransID;";
        #endregion

        #region DML Query
        public const string UPDATE_SYNC = " UPDATE trans SET IsSync = 1 WHERE TransID = @TransID;";
        #endregion
    }
}
