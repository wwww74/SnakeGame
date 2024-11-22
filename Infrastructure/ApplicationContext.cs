using Microsoft.EntityFrameworkCore;
using Snake.Models;

namespace Snake.Infrastructure
{
    public class ApplicationContext : DbContext
    {
        public DbSet<ScoresModel> Scores => Set<ScoresModel>();
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) => Database.EnsureCreated();
    }
}
