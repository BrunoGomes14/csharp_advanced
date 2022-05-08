using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;

namespace devmonkorm.Common
{
    public abstract class DMSet<T> : IEnumerable<T>
        where T : class, new()
    {
        protected DbConnection Database;

        public DMSet(DbConnection database)
        {
            Database = database;
        }

        public abstract int Remove(T entity);

        public abstract T Add(T entity);

        public abstract T Update(T entity);

        public abstract IEnumerable<T> Where(Expression<Func<T, bool>> predicate);

        public abstract IEnumerable<T> OrderBy<TOrderBy>(Expression<Func<T, TOrderBy>> expression);

        public abstract IEnumerable<T> ToList();

        protected abstract List<T> ExecuteQuery();

        protected abstract int ExecuteCommand();

        public abstract IEnumerator<T> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}