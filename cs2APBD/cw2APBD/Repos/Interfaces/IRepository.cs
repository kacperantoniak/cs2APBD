using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw2APBD.Repos.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        T? GetById(string id);
        List<T> GetAll();
        void Update(T entity);
        void Delete(string id);
    }
}
