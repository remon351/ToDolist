using Microsoft.EntityFrameworkCore;
using ToDolist.Models;

namespace ToDolist.data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<list> lists { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true, true)
            .Build()
            .GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(builder);
        }
    }
}
