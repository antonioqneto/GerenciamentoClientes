using System.Text.Json;
using System.Text.Json.Serialization;
using GerenciamentoClientesBlazor.Services;
using GerenciamentoClientesModel;
using RestSharp;
using RestSharp.Serializers.Json;
namespace GerenciamentoClientes.Client.Services
{
	public class ClienteService : IClienteService
    {
		protected static string BaseUrl { get; set; } = "https://localhost:44300/Cliente";
		RestClient client = new (BaseUrl,configureSerialization: s => 
			s.UseSystemTextJson(new JsonSerializerOptions
			{
				ReferenceHandler = ReferenceHandler.Preserve,
				PropertyNameCaseInsensitive = true,
				WriteIndented = true,
				IncludeFields = true
			}
		)); 

	public async Task<bool> CreateCliente(Cliente cliente)
        {
			try
			{
				var request = new RestRequest(ClienteAPIConstants.CreateCliente, Method.Post);
				request.AddObject(cliente);
				var response = await client.PostAsync<bool>(request);

				return response;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				return false;
			}
		}

		public async Task<List<Cliente>> GetAllClientes()
		{
			try
			{
				var request = new RestRequest(ClienteAPIConstants.GetAllClientes, Method.Get);
				var response = await client.GetAsync<List<Cliente>>(request);

				return response;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				return null;
			}
		}

		public async Task<Cliente> GetClienteById(int clienteId)
		{
			try
			{
				var request = new RestRequest($"{ClienteAPIConstants.GetClienteById}/{clienteId}", Method.Get);
				var response = await client.GetAsync<Cliente>(request);

				return response;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				return null;
			}
		}

		public async Task<bool> UpdateCliente(Cliente cliente)
		{
			try
			{
				var request = new RestRequest(ClienteAPIConstants.UpdateCliente, Method.Put);
				request.AddObject(cliente);
				var response = await client.PutAsync<bool>(request);

				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				return false;
			}
		}
		public async Task<bool> DeleteCliente(int clienteId)
		{
			try
			{
				var request = new RestRequest($"{ClienteAPIConstants.DeleteCliente}/{clienteId}", Method.Delete);
				var response = await client.DeleteAsync<Cliente>(request);

				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				return false;
			}
		}
	}
}