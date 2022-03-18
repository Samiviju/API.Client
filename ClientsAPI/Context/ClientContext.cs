using ClientsAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace ClientsAPI.Context
{

    public class ClientContext : DbContext 
    {

        public ClientContext(DbContextOptions<ClientContext> options) : base(options)
        {
            Database.EnsureCreated(); 
        }

        public DbSet<Client> Client { get; set; }
    }
}
