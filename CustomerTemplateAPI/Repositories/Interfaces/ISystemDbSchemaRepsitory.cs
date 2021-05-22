using CustomerTemplateAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerTemplateAPI.Repositories.Interfaces
{
    public interface ISystemDbSchemaRepsitory
    {
        Task<IEnumerable<SystemTableConfig>> FindAllTableConfig();
        Task<IEnumerable<SystemTableColumnConfig>> FindAllColumnConfig();
        Task<IEnumerable<SystemTableForeingKeyConfig>> FindAllForeignKeyConfig();
    }
}
