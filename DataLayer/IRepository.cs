using System.Collections.Generic;

namespace DataLayer
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        void Create(T obj);
        void Update(T obj);
        T GetById(int id);
        void Delete(T obj);
        void SaveContext();
    }
}
