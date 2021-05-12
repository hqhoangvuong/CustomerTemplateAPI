using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CustomerTemplateAPI.Models
{
    public class ApplicationUser : IdentityUser<string>
    {
        public string EmployeeCode { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public bool IsHasAvatar { get; set; }

        public virtual ICollection<IdentityUserRole<string>> UserRoles { get; set; }
    }
}
