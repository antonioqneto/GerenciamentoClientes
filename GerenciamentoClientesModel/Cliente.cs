using System.ComponentModel.DataAnnotations;

namespace GerenciamentoClientesModel
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Length(2, 60)]
        public string Nome { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone, Length(10, 11)]
        public string Telefone { get; set; }

		public Cliente()
		{
		}

		public Cliente(int id, string nome, string email, string telefone)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }
    }

    public static class ClienteAPIConstants
    {
        public const string CreateCliente  = nameof(CreateCliente);
        public const string GetAllClientes = nameof(GetAllClientes);
        public const string GetClienteById = nameof(GetClienteById);
        public const string UpdateCliente = nameof(UpdateCliente);
        public const string DeleteCliente = nameof(DeleteCliente);
    }
}
