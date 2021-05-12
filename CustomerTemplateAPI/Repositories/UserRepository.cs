using CustomerTemplateAPI.Exceptions;
using CustomerTemplateAPI.Models;
using CustomerTemplateAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerTemplateAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public Task<ApplicationUser> CreateAsync(ApplicationUser entity, string password = null)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePasswordAsync(ApplicationUser entity, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<ApplicationUser> ValidateUserAsync(string email, string password)
        {
            if (email == null)
                throw new ArgumentNullException(nameof(email));

            var entity = await _userManager.FindByEmailAsync(email);
            if (entity == null || !await _userManager.CheckPasswordAsync(entity, password))
                throw new ModelStateException(nameof(password), "Invalid username or password");

            return entity;
        }
    }
}
