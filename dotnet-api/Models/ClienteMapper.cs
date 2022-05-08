using apiwithpomelo.Entities;

namespace apiwithpomelo.Models
{
    // Mapeamento da TbCliente para Cliente
    public partial class Cliente 
    {
        public static implicit operator TbCliente(Cliente cliente)
        {
            return new TbCliente()
            {
                IdCliente = cliente.Id,
                NmCliente = cliente.Nome,
                DsEmail = cliente.Email,
                DsCpf = cliente.CPF,
                DsEndereco = cliente.Endereco,
                DsTelefone = cliente.Telefone,
                DtNascimento = cliente.Nascimento
            };
        }

        public static implicit operator Cliente(TbCliente cliente)
        {
            return new Cliente()
            {
                CPF = cliente.DsCpf,
                Email = cliente.DsEmail,
                Endereco = cliente.DsEndereco,
                Nascimento = cliente.DtNascimento,
                Nome = cliente.NmCliente,
                Telefone = cliente.DsTelefone,
                Id = cliente.IdCliente
            };;
        }
    }
}