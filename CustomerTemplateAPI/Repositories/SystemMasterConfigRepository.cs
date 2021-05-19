using CustomerTemplateAPI.Data;
using CustomerTemplateAPI.Models;
using CustomerTemplateAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerTemplateAPI.Repositories
{
    public class SystemMasterConfigRepository : GenericRepository<SystemMasterConfig>, ISystemMasterConfigRepository
    {
        private readonly ApplicationDbContext context;

        public SystemMasterConfigRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<SystemMasterConfig> FindAll()
        {
            return GetAll().AsQueryable();
        }

        public async Task<SystemMasterConfig> FindById(int id)
        {
            object[] parameters = new object[1];
            parameters[0] = id;

            return await GetItemById(parameters);
        }

        public async Task<SystemMasterConfig> Modify(SystemMasterConfig updatedConfig)
        {
            updatedConfig.ModifiedDate = DateTime.UtcNow;
            return await Update(updatedConfig);
        }

        public async Task<SystemMasterConfig> FindByName(string configName)
        {
            return await GetAll().AsQueryable().FirstOrDefaultAsync(t => t.ConfigName == configName);
        }
    }
}
