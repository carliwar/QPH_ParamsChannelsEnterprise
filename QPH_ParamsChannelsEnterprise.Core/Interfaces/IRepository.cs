using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QPH_ParamsChannelsEnterprise.Core.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        Task<T> GetById(int id);
        Task<T> GetById(long id);
        Task Add(T entity);
        Task Add(List<T> entities);
        Task BulkInsert(List<T> entities);
        void Update(T entity);
        void Update(T oldEntity, T entity);
        Task Delete(int id);
    }
}
