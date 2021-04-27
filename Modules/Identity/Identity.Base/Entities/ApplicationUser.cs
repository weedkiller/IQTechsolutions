// ReSharper disable VirtualMemberCallInConstructor

using Microsoft.AspNetCore.Identity;

namespace Identity.Base.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public UserInfo UserInfo { get; set; }
    }
}