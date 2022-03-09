using ClientsAPI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientsAPI.Context{

    public class ClientContext : DbContext {

        public ClientContext(DbContextOptions<ClientContext> options) : base(options)
        {
            Database.EnsureCreated(); 
        }

        public DbSet<Client> Client { get; set; }
    }
}
