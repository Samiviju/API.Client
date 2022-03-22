using ClientsAPI.Model;

namespace ClientsAPI.Repositories
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> Get();

        Task<Client> Get(string cpf);

        Task<Client> Create(Client client);

        Task Update(Client client);

        Task Delete(string cpf);
    }
}