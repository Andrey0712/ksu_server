using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebKsu.Data.Entities;
using WebKsu.Data.Entities.Identity;

namespace WebKsu.Data
{
    public class AppEFContext : IdentityDbContext<AppUser, AppRole, long, IdentityUserClaim<long>,
        AppUserRole, IdentityUserLogin<long>,
        IdentityRoleClaim<long>, IdentityUserToken<long>>
    {
        public AppEFContext(DbContextOptions<AppEFContext> options) :
           base(options)
        {
        }
        public DbSet<BanerEntity> Baner { get; set; }
        public DbSet<RunLineEntity> RunLine { get; set; }
        public DbSet<ShowEntity> Shows { get; set; }
        public DbSet<ShowIdEntity> ShowIdEntity { get; set; }
        public DbSet<SexEntity> SexEntity { get; set; }
        public DbSet<DogClasesEntity> ClassIdEntity { get; set; }
        public DbSet<ValidateShowEntity> ValidateShowEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });


        }
    }
}
