using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using QPH_ParamsChannelsEnterprise.Core.Interfaces;
using QPH_ParamsChannelsEnterprise.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QPH_ParamsChannelsEnterprise.Infrastructure.Repositories
{
    public class AdministrationSwitchBaseRepository<T> : IRepository<T> where T : class
    {
        private readonly AdministrationSwitchContext _context;
        protected readonly DbSet<T> _entities;
        public AdministrationSwitchBaseRepository(AdministrationSwitchContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
        public IQueryable<T> GetAll() => _entities.AsQueryable<T>();
        public async Task<T> GetById(int id) => await _entities.FindAsync(id);
        public async Task<T> GetById(long id) => await _entities.FindAsync(id);
        public async Task Add(T entity) => await _entities.AddAsync(entity);
        public async Task BulkInsert(List<T> entities) => await _context.BulkInsertAsync(entities);
        public async Task Add(List<T> entities) => await _entities.AddRangeAsync(entities);
        public void Update(T entity) => _entities.Update(entity);
        public void Update(T oldEntity, T entity) => _context.Entry(oldEntity).CurrentValues.SetValues(entity);
        public async Task Delete(int id)
        {
            T entity = await GetById(id);
            _entities.Remove(entity);
        }
    }
}
