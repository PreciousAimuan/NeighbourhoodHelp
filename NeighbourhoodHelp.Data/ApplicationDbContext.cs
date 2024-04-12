using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NeighbourhoodHelp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighbourhoodHelp.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        
        public virtual DbSet<Errand> Errands { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<AppUser> appUsers { get; set; }
        public virtual DbSet<Agent> agents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUser>()
                .HasMany(u => u.Agents)
                .WithMany(a => a.AppUsers)
                .UsingEntity<Dictionary<string, object>>(
                    "AgentAppUser",
                    a => a.HasOne<Agent>().WithMany().HasForeignKey("AgentId"),
                    u => u.HasOne<AppUser>().WithMany().HasForeignKey("AppUserId"),
                    // Configure additional properties
                    a =>
                    {
                        a.Property<DateTime>("JoinedAt").HasDefaultValueSql("CURRENT_TIMESTAMP");
                    }
                );
        }


    }
}
