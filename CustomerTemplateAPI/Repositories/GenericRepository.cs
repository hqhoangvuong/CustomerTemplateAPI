using CustomerTemplateAPI.Data;
using CustomerTemplateAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerTemplateAPI.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private ApplicationDbContext context;
        private DbSet<T> entities;

        public GenericRepository(ApplicationDbContext context)
        {
            this.context = context;
            this.entities = context.Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return context.Set<T>().AsNoTracking();
        }

        public virtual async Task<T> GetItemById(object[] parameters)
        {
            var result = await entities.FindAsync(parameters);
            if(result != null)
                context.Entry(result).State = EntityState.Detached;
            return result;
        }

        public virtual async Task<T> Create(T item)
        {
            EntityEntry<T> entityEntry = context.Set<T>().Add(item);
            await context.SaveChangesAsync();
            return entityEntry.Entity;
        }

        public async Task<T> Update(T item)
        {
            entities.Attach(item);
            context.Entry(item).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return item;
        }

        public async virtual Task<int> Delete(object id)
        {
            T entityToDelete = await entities.FindAsync(id);
            var effectedRecords = await Delete(entityToDelete);
            return effectedRecords;
        }

        public async virtual Task<int> Delete(T entityToDelete)
        {
            context.Set<T>().Remove(entityToDelete);

            return await context.SaveChangesAsync();
        }
    }
}
