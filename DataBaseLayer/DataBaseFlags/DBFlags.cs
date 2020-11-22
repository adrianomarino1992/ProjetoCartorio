using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLayer.DataBaseFlags
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Property)]
    public class DBFlags : Attribute
    {
        public bool PrimaryKey { get; set; } = false;
        public Type ForeignKey { get; set; }
        public string DataBaseValueType { get; set; }
        public bool Save { get; set; } = true;
        public object DefaultValue { get; set; }
        public bool IsNullable { get; set; } = true;
        public bool Private { get; set; } = false;
        public bool Unique { get; set; } = false;
        public bool UseDefaultNames { get; set; } = false;
        public string ColumnName { get; set; }
        public string TableName { get; set; }
        public string SchemaName { get; set; }


    }
}
