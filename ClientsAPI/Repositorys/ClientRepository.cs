using ClientsAPI.Context;
using ClientsAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace ClientsAPI.Repositories
{
    public class ClientRepository : IClientRepository
    {
        public readonly DbClientsEF _context;
        public ClientRepository(DbClientsEF context)
        {
            _context = context;
        }

        public async Task<Client> Create(Client client)
        {
            _context.Client.Add(client);
            await _context.SaveChangesAsync();

            return client;
            
        }

        public async Task Delete(string cpf)
        {
            var clientDelete = await _context.Client.FindAsync(cpf);
            _context.Client.Remove(clientDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Client>> Get()
        {
            return await _context.Client.ToListAsync();
        }

        public async Task<Client> Get(string cpf)
        {
            return await _context.Client.FindAsync(cpf);
        }

        public async Task Update(Client client)
        {
            _context.Entry(client).State = EntityState.Modified;
            await _context.SaveChangesAsync(); 
        }
    }
}
