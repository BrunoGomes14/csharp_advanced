using System;

namespace devmonkorm.Attributes
{
    public class DMTable : Attribute
    {
        public string TableName { get; set; }

        public DMTable(string tableName)
        {
            this.TableName = tableName;
        }
    }
}