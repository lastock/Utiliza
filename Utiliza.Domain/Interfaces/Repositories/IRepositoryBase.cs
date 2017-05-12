using System.Collections.Generic;

namespace Utiliza.Domain.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        int Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Dispose();
    }
}
