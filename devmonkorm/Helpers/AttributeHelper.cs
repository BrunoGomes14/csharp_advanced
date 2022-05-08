using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using devmonkorm.Attributes;

namespace devmonkorm.Helpers
{
    public static class AttributeHelper
    {
        public static DMTable GetDMTable(Type type) => type.GetCustomAttributes()
            .OfType<DMTable>()
            .FirstOrDefault();

        public static List<Tuple<DMColumn, PropertyInfo>> GetDMColumns(Type type)
        {
            return type.GetProperties()
                .Where(w => w.GetCustomAttribute<DMColumn>() != null)
                .Select(s => new Tuple<DMColumn, PropertyInfo>(s.GetCustomAttribute<DMColumn>(), s))
                .ToList();
        }

        public static Tuple<DMColumn, PropertyInfo> GetDMColumn(Type type, string propertyName)
        {
            return type.GetProperties()
                .Where(w => w.Name == propertyName && w.GetCustomAttribute<DMColumn>() != null)
                .Select(s => new Tuple<DMColumn, PropertyInfo>(s.GetCustomAttribute<DMColumn>(), s))
                .FirstOrDefault();
        }

        public static Tuple<DMKey, PropertyInfo> GetDMKey(Type type)
        {
            return type.GetProperties()
                .Where(w => w.GetCustomAttribute<DMKey>() != null)
                .Select(s => new Tuple<DMKey, PropertyInfo>(s.GetCustomAttribute<DMKey>(), s))
                .FirstOrDefault();
        }
    }
}