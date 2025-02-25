﻿using Microsoft.AspNetCore.Identity;

namespace WebKsu.Data.Entities.Identity
{
    public class AppUserRole:IdentityUserRole<long>
    {
        public virtual AppUser User { get; set; }
        public virtual AppRole Role { get; set; }
    }
}