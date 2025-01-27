using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace intranet_somacou.Models
{
    using System.Data.Entity;
    using System.Reflection.Emit;

    public class AppDbContext:DbContext
    {
        public AppDbContext() : base("DefaultConnection") { }
        public DbSet <RegisterDto> Users { get;set; }
        public DbSet <IncidentDto> Incidents { get;set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure la relation entre IncidentDto et RegisterDto
            modelBuilder.Entity<IncidentDto>()
                .HasOne(i => i.User) // IncidentDto a un utilisateur
                .WithMany() // RegisterDto peut avoir plusieurs incidents
                .HasForeignKey(i => i.UserId); // Clé étrangère UserId

            base.OnModelCreating(modelBuilder);
        }
    }
}