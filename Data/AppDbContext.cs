namespace CommanderGQL.Data
{
    using Microsoft.EntityFrameworkCore;
    using CommanderGQL.Models;

    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options): base(options)
        {
            
        }

        public DbSet<Platform> Platforms { get; set; }
    }
}