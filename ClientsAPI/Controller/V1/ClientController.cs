using ClientsAPI.Context;
using ClientsAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClientsAPI.Controller.V1
{
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly DbClientsEF _context;
        private DbSet<Client> clientCtx;

        public ClientController(DbClientsEF context)
        {
            this._context = context;
            this._context.Set<Client>();
        }

        [HttpGet]
        [Route("api/v1/client")]
        public async Task<IActionResult> GetAll()
        {
            var res = await clientCtx.ToListAsync();
            return Ok(res);
        }

        [HttpPost]
        [Route("api/v1/client")]
        public async Task<ActionResult<Client>> PostClients(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClient", new { cpf = client.Cpf }, client);
        }

        [HttpDelete]
        [Route("api/v1/client")]
        public async Task<ActionResult<Client>> DeleteClient(string cpf)
        {
            var client = await _context.Clients.FindAsync(cpf);
            if (client == null)
            {
                return BadRequest();
            }

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        [Route("api/v1/client/{cpf}")]
        public async Task<ActionResult> PutClients(string cpf, Client client)
        {
            if (cpf != client.Cpf)
            {
                return BadRequest();
            }

            _context.Entry(client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (cpf != client.Cpf)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }
    }
}