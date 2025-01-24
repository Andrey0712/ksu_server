using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebKsu.Data.Entities.Identity
{
    public class AppUser: IdentityUser<long>
    {
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(20)]
        public string Phone { get; set; }
        public virtual ICollection<AppUserRole> UserRoles { get; set; }
    }
}
