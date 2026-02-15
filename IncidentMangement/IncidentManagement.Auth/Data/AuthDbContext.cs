using Microsoft.EntityFrameworkCore;
using IncidentManagement.Auth.Models;

namespace IncidentManagement.Auth.Data
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}