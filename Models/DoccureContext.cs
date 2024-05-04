
using Microsoft.EntityFrameworkCore;

namespace Versioning.Models
{
    public class DoccureContext : DbContext
    {
        public DoccureContext(DbContextOptions<DoccureContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Specialization>()
                .HasMany(c => c.Doctors)
                .WithOne(a => a.Specialization)
                .HasForeignKey(a => a.SpecializationId);

            modelBuilder.Seed();
        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Specialization> Specialists { get; set; }
    }
}