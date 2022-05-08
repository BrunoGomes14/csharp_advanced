namespace devmonkorm.Helpers
{
    public class DMFilter
    {
        public DMFilter(string name)
        {
            Name = name;
        }

        public DMFilter(string name, object value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }
        public string FieldName { get => $"@{Name.Replace(" ", "")}"; }
        public object Value { get; set; }
    }
}