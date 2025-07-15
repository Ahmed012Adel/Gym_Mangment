using Gym.Mangment.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYMMAngment.Presistente.Data
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>(entity =>
            {
                entity.HasMany(e => e.Classes)
                      .WithOne(e => e.Trainer);

                entity.HasMany(e => e.MembersAttend)
                      .WithMany(e => e.Member);

                entity.HasMany(e => e.Subscripes)
                      .WithOne(e => e.Member)
                      .HasForeignKey(e => e.MemberId);
            });
            builder.Entity<GYMClasses>(G=>
            {
                G.HasOne(T=>T.Trainer)
                 .WithMany(T => T.Classes)
                 .HasForeignKey(F => F.TrainerId)
                 .OnDelete(DeleteBehavior.Cascade);
                G.HasMany(M => M.Member)
                .WithMany(M => M.MembersAttend)
                 ;
            });
        }

        public DbSet<Subscription> subscriptions { get; set; }
        public DbSet<GYMClasses> Classes { get; set; }

    }
}
