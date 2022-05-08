using System;

namespace devmonkorm.Attributes
{
    public class DMColumn : Attribute
    {
        public string FieldName { get; set; }

        public DMColumn(string field)
        {
            this.FieldName = field;
        }

        public bool Required { get; set; }
        public string TypeField { get; set; }    
    }
}