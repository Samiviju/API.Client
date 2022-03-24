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

        public ClientController(DbClientsEF context)
        {
            this._context = context;
            this._context.Set<Client>();
        }

        [HttpGet]
        [Route("api/v1/clients")]
        public async Task<ActionResult<IEnumerable<Client>>> GetAll()
        {
            var client = await _context.Clients.ToListAsync();
            return Ok(client);
        }

        [HttpPost]
        [Route("api/v1/client")]
        public async Task<ActionResult<Client>> PostClients(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostClients), new { id = client.Id }, client);
        }

        [HttpDelete]
        [Route("api/v1/client")]
        public async Task<ActionResult<Client>> DeleteClient(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            return client;
        }

        [HttpPut]
        [Route("api/v1/client/{id}")]
        public async Task<ActionResult> PutClients(int id, Client client)
        {
            if (id != client.Id)
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
                if (client != null)
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