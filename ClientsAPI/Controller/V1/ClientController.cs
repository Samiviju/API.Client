using ClientsAPI.Model;
using ClientsAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientsAPI.Controller.V1
{

    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;
        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpGet]
        [Route("api/v1/client")]
        public async Task<IEnumerable<Client>> GetClients()
        {
            return await _clientRepository.Get();
        }

        [HttpGet]
        [Route("api/v1/client/{cpf}")]
        public async Task<ActionResult<Client>> GetClientsCpf(string cpf)
        {
            return await _clientRepository.Get(cpf);
        }

        [HttpPost]
        [Route("api/v1/client")]
        public async Task<ActionResult<Client>> PostClients([FromBody] Client client)
        {
            var newClient = await _clientRepository.Create(client);
            return newClient;
        }

        [HttpDelete]
        [Route("api/v1/client")]
        public async Task<ActionResult> DeleteClient(string cpf)
        {
            var clienteDelete = await _clientRepository.Get(cpf);

            if (clienteDelete != null)
                await _clientRepository.Delete(clienteDelete.Cpf);

            return null;
             
        }

        [HttpPut]
        [Route("api/v1/client")]
        public async Task<ActionResult> PutClients(string cpf, [FromBody] Client client)
        {
            if (cpf == client.Cpf)
                await _clientRepository.Update(client);

            return null;

            
        }
        


    }
}
