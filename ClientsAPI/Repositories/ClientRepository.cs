using ClientsAPI.Model;

namespace ClientsAPI.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly IClientRepository _clientRepository;
        public ClientRepository(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public Task<Client> Create(Client client)
        {
            _clientRepository.Create(client);
            
        }

        public Task Delete(string cpf)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Client>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Client> Get(string cpf)
        {
            throw new NotImplementedException();
        }

        public Task Update(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
