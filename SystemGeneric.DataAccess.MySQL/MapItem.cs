using System;
using System.Collections.Generic;
using System.Text;

namespace SystemGeneric.DataAccess.MySQL
{
    public enum DataRetriveTypeEnum
    {
        FirstOrDefault,
        List
    }

    public class MapItem
    {
        public Type Type { get; private set; }
        public DataRetriveTypeEnum DataRetriveType { get; private set; }
        public string PropertyName { get; private set; }

        public MapItem(Type type, DataRetriveTypeEnum dataRetriveType, string propertyName)
        {
            Type = type;
            DataRetriveType = dataRetriveType;
            PropertyName = propertyName;
        }
    }
}
