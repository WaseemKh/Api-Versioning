using Microsoft.EntityFrameworkCore;


namespace Versioning.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Specialization>().HasData(
        new Specialization { Id = 1, Name = "Pediatrics" },
        new Specialization { Id = 2, Name = "Orthopedics" },
        new Specialization { Id = 3, Name = "Dermatology" },
        new Specialization { Id = 4, Name = "Cardiology" },
        new Specialization { Id = 5, Name = "Neurology" });

            modelBuilder.Entity<Doctor>().HasData(
        new Doctor { Id = 1, SpecializationId = 1, Name = "Dr. Alice Smith", Description = "Pediatrician with 10 years of experience.", IsAvailable = true },
        new Doctor { Id = 2, SpecializationId = 1, Name = "Dr. Bob Johnson", Description = "Expert in childhood nutrition and wellness.", IsAvailable = true },
        new Doctor { Id = 3, SpecializationId = 2, Name = "Dr. Chris Lee", Description = "Orthopedic surgeon specializing in sports injuries.", IsAvailable = true },
        new Doctor { Id = 4, SpecializationId = 2, Name = "Dr. David Park", Description = "Focuses on joint replacement and recovery.", IsAvailable = false },
        new Doctor { Id = 5, SpecializationId = 3, Name = "Dr. Emma Lopez", Description = "Dermatologist with a focus on chronic skin conditions.", IsAvailable = true },
        new Doctor { Id = 6, SpecializationId = 3, Name = "Dr. Fiona Chen", Description = "Specializes in cosmetic dermatology treatments.", IsAvailable = true },
        new Doctor { Id = 7, SpecializationId = 4, Name = "Dr. George Kirov", Description = "Cardiologist, expert in heart disease management.", IsAvailable = true },
        new Doctor { Id = 8, SpecializationId = 4, Name = "Dr. Henry Ford", Description = "Experienced in invasive cardiology procedures.", IsAvailable = false },
        new Doctor { Id = 9, SpecializationId = 5, Name = "Dr. Iris Watson", Description = "Neurologist, dealing with disorders such as epilepsy.", IsAvailable = true },
        new Doctor { Id = 10, SpecializationId = 5, Name = "Dr. John Davis", Description = "Specializes in pediatric neurology.", IsAvailable = true }
    );
        }
    }
}
