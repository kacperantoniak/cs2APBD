using cw2APBD.Domain;
using cw2APBD.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw2APBD.Repos
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly List<T> _storage = new();

        public virtual void Add(T entity)
        {
            _storage.Add(entity);
        }

        public virtual T? GetById(string id)
        {
            return _storage.FirstOrDefault(e => e.Id == id);
        }

        public virtual List<T> GetAll() => _storage.ToList();

        public virtual void Update(T entity)
        {
            int index = _storage.FindIndex(e => e.Id == entity.Id);
            if (index >= 0)
            {
                _storage[index] = entity;
            }
        }

        public virtual void Delete(string id)
        {
            T? entity = GetById(id);
            if (entity == null)
            {
                throw new InvalidOperationException($"Entity with Id {id} could not be found");
            }
            else
            {
                _storage.Remove(entity);
            }
        }
    }
}
