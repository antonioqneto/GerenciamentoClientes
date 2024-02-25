namespace GerenciamentoClientesBlazor.Services
{
	public interface IClienteService
	{
		Task<bool> CreateCliente(Cliente cliente);
		Task<List<Cliente>> GetAllClientes();
		Task<Cliente> GetClienteById(int clienteId);
		Task<bool> UpdateCliente(Cliente cliente);
		Task<bool> DeleteCliente(int clienteId);
	}
}
