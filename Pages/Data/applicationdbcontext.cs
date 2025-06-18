using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using aspnetproject.Models;

namespace aspnetproject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {}

        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Availability> Availabilities { get; set; }
    }
}