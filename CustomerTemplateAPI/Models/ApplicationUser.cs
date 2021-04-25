using Microsoft.AspNetCore.Identity;

namespace CustomerTemplateAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string EmployeeCode { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public bool IsHasAvatar { get; set; }
    }
}
