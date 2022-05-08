using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using apiwithpomelo.Entities;
using System;

namespace apiwithpomelo.Repositories 
{
    internal abstract class Repository<T> : IDisposable where T : class
    {
        protected readonly mysql_17753_devmonkContext _context;

        public Repository(mysql_17753_devmonkContext context)
        {
            _context = context;
        }

        public virtual void Add(T entity)
        {
            _context.Add(entity);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _context.Set<T>()
                .AsNoTracking()
                .ToList();
        }

        public virtual void Update(T entity)
        {
            _context.Update(entity);
        }

        public virtual void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public virtual T Get(object pk)
        {
            return _context.Find<T>(pk);
        }

        public void Commit() => _context.SaveChanges();

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}