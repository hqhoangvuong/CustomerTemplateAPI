using CustomerTemplateAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerTemplateAPI.Repositories.Interfaces
{
    public interface ISystemMasterConfigRepository
    {
        IEnumerable<SystemMasterConfig> FindAll();
        Task<SystemMasterConfig> FindById(int id);
        Task<SystemMasterConfig> Modify(SystemMasterConfig updatedConfig);
        Task<SystemMasterConfig> FindByName(string configName);
    }
}
