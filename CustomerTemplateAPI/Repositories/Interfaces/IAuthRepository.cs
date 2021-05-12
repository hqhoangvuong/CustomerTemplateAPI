using CustomerTemplateAPI.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CustomerTemplateAPI.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Task<JwtSecurityToken> GetJwtTokenAsync(ApplicationUser user, params Claim[] extraClaims);
    }
}
