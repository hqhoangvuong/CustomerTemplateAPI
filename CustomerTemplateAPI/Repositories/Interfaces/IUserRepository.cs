using CustomerTemplateAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerTemplateAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<ApplicationUser> CreateAsync(ApplicationUser entity, string password = null);
        Task<ApplicationUser> ValidateUserAsync(string email, string password);
        Task UpdatePasswordAsync(ApplicationUser entity, string password);
    }
}
