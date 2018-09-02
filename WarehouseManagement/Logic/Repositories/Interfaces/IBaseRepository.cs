using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagement.Repositories.Logic.Interfaces
{
    public interface IBaseRepository<T>
        where T : class
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        void Delete(T item);
        void Save();
        void Dispose();
    }
}
