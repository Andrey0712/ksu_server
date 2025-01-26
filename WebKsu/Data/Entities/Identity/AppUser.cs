using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebKsu.Data.Entities.Identity
{
    public class AppUser: IdentityUser<long>
    {
        [StringLength(100)]
        public string Owner { get; set; }
        [StringLength(100)]
        public string Address { get; set; }
        [StringLength(20)]
        public string Phone { get; set; }
        public virtual ICollection<AppUserRole> UserRoles { get; set; }
    }
}
