using Microsoft.AspNetCore.Identity;

namespace ExamProject.Models
{
    public class AppUser:IdentityUser
    {
        public string FullName { get;set; }
    }
}
