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
    public class SystemDbSchemaRepository : ISystemDbSchemaRepsitory
    {
        private readonly ApplicationDbContext _context;

        public SystemDbSchemaRepository(ApplicationDbContext dbContext)
        {
            this._context = dbContext;
        }

        public async Task<IEnumerable<SystemTableColumnConfig>> FindAllColumnConfig()
        {
            var results = await _context.SystemTableColumnConfigs.ToListAsync();
            return results;
        }

        public async Task<IEnumerable<SystemTableForeingKeyConfig>> FindAllForeignKeyConfig()
        {
            var results = await _context.SystemTableForeingKeyConfigs.ToListAsync();
            return results;
        }

        public async Task<IEnumerable<SystemTableConfig>> FindAllTableConfig()
        {
            var results = await _context.SystemTableConfigs.ToListAsync();
            return results;
        }
    }
}
