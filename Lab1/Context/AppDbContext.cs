using Microsoft.EntityFrameworkCore;
using Models;

namespace Lab1.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Parameters> Parameters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Documents\\oidt.mdf;Integrated Security=True;Connect Timeout=30");
        }
    }
}