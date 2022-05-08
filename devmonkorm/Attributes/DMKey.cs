using System;

namespace devmonkorm.Attributes
{
    public class DMKey : DMColumn
    {
        public DMKey(string field) 
            : base (field) { }

        public bool AutoIncrement { get; set; } = true;
    }
}