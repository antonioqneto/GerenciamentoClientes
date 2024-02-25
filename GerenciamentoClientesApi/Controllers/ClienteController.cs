using GerenciamentoClientesApi.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoClientesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;
        private GerenciamentoClientesContext _db;
        public ClienteController(ILogger<ClienteController> logger, GerenciamentoClientesContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpPost(ClienteAPIConstants.CreateCliente)]
        public async Task<ActionResult> CreateCliente([FromForm] Cliente cliente)
        {
            try
            {
                await _db.Database.BeginTransactionAsync();

                _db.Clientes.Add(cliente);

                var result = await _db.SaveChangesAsync();

                await _db.Database.CommitTransactionAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                await _db.Database.RollbackTransactionAsync();
                throw ex;
            }
        }

        [HttpGet(ClienteAPIConstants.GetAllClientes)]
		[Produces("application/json")]
        public async Task<ActionResult<List<Cliente>>> GetAllClientes()
        {
            try
            {
                var result = await _db.Clientes
                    .AsNoTracking()
                    .ToListAsync();

                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet(ClienteAPIConstants.GetClienteById + "/{clienteId}")]
        public async Task<ActionResult> GetClienteById(int clienteId)
        {
            try
            {
				var result = await _db.Clientes
                    .Where(cliente => cliente.Id == clienteId)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut(ClienteAPIConstants.UpdateCliente)]
        public async Task<bool> UpdateCliente([FromForm] Cliente cliente)
        {
            try
            {
                await _db.Database.BeginTransactionAsync();

                await _db.Clientes.AddAsync(cliente);

                _db.Clientes.Update(cliente);

				var result = await _db.SaveChangesAsync();

                await _db.Database.CommitTransactionAsync();

                return true;
            }
            catch (Exception)
            {
                await _db.Database.RollbackTransactionAsync();
                throw;
            }
        }

        [HttpDelete(ClienteAPIConstants.DeleteCliente + "/{clienteId}")]
        public async Task<bool> DeleteCliente(int clienteId)
        {
            try
            {
                await _db.Database.BeginTransactionAsync();

                var cliente = await _db.Clientes.Where(x => x.Id == clienteId).FirstOrDefaultAsync();
                
                _db.Clientes.Remove(cliente);
                _db.SaveChanges();

                await _db.Database.CommitTransactionAsync();

                return true;
            }
            catch (Exception)
            {
                await _db.Database.RollbackTransactionAsync();
                throw;
            }
        }
    }
}
