using ClientsAPI.Model;
using ClientsAPI.Util;
using Microsoft.EntityFrameworkCore;

namespace ClientsAPI.Context
{
    public class DbClientsEF : DbContext
    {
        public DbClientsEF(DbContextOptions<DbClientsEF> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(AppSettings.GetConnectionString());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(c =>
            {
                c.ToTable("Client");
                c.HasKey(k => k.Id);
            });
        }
    }
}