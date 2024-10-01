using Store.Muhanad.Core;
using Store.Muhanad.Core.Entities;
using Store.Muhanad.Core.Repositories.Contract;
using Store.Muhanad.Repository.Data.Contexts;
using Store.Muhanad.Repository.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Muhanad.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext _context;
        private Hashtable repositories;

        public UnitOfWork(StoreDbContext context)
        {
            _context = context;
            repositories = new Hashtable();
        }

        public async Task<int> CompleteAsync()
        {
           return await _context.SaveChangesAsync();
        }

        public IGenericRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            
           var type = typeof(TEntity).Name;
            if(!repositories.ContainsKey(type))
            {
                var repository = new GenericRepository<TEntity,TKey>(_context);
                repositories[type] = repository;
            }
            return repositories[type] as IGenericRepository<TEntity,TKey>;
        }
    }
}
