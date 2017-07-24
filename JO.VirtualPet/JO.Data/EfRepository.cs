using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JO.Data
{
    public partial class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly VirtualPetContext _context;
        private DbSet<T> _entities;

        public EfRepository(VirtualPetContext context)
        {
            _context = context;
        }

        public virtual T GetById(object id)
        {
            return Entities.Find(id);
        }

        public virtual void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
             
            Entities.Add(entity);
            _context.SaveChanges();
        }

        public virtual void Insert(IEnumerable<T> entities)
        {

            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            foreach (var entity in entities)
            {
                Entities.Add(entity);
            }

            _context.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
                
            _context.SaveChanges();
        }

        public virtual void Update(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }
                
            _context.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Entities.Remove(entity);
            _context.SaveChanges();
        }

        public virtual void Delete(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            foreach (var entity in entities)
            {
                Entities.Remove(entity);
            }

            _context.SaveChanges();
        }

        public virtual IQueryable<T> Table
        {
            get
            {
                return Entities;
            }
        }

        public virtual IQueryable<T> TableNoTracking
        {
            get
            {
                return Entities.AsNoTracking();
            }
        }

        protected virtual DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                {
                    Type contextType = typeof(VirtualPetContext);

                    foreach (var property in contextType.GetProperties())
                    {
                        if(property.PropertyType == typeof(DbSet<T>))
                        {
                            _entities = (DbSet<T>) property.GetValue(_context);
                        }
                    }
                }

                return _entities;
            }
        }

    }
}

