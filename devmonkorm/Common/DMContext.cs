using System;
using System.Data.Common;
using System.Linq;

namespace devmonkorm.Common
{
    public abstract class DMContext
    {
        protected DbConnection Database;

        public DMContext(DMContextOptions options)
        {           
            Database = options.Connection;
            LoadDMSet();
        }

        private void LoadDMSet()
        {
            var type = GetType();
            var properties = type.GetProperties()
                .Where(w => w.PropertyType.FullName.Contains("DMSet"))
                .ToList();

            foreach (var p in properties)
            {
                var typeGeneric = typeof(DMSetMySql<>);
                var typeInstance = p.PropertyType.GetGenericArguments();
                var instance = typeGeneric.MakeGenericType(typeInstance);
                
                p.SetValue(this, Activator.CreateInstance(instance, Database));
            }
        }

        public void Add<T>(T entity) where T : new()
        {
            // Buscar tabela do mesmo tipo que a entidade passada
            // Fazer insert
        }

        public void Update<T>(T entity) where T : new()
        {
            // Buscar tabela do mesmo tipo que a entidade passada
            // Fazer update
        }

        public void Remove<T>(T entity) where T : new()
        {
            // Buscar tabela do mesmo tipo que a entidade passada
            // Fazer delete
        }
    }
}