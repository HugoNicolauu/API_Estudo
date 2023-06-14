using Desafio_React.Migrations;
using System.Reflection.Metadata.Ecma335;

namespace Desafio_React.Domain.Client
{
    public class Client
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string DataCadastro { get; private set; }
        public Contato Contato { get; private set; }
        public Endereco Endereco { get; private set; }

        public Client()
        {
            
        }

        public Client(int id,string name,Contato contato, Endereco endereco)
        {
            Id = id;
            Nome = name;
            DataCadastro = DateTime.Now.ToString("dd/MM/yyyy");
            Contato = contato;
            Endereco = endereco;

        }

        public void EditarCliente(string nome,  Contato contato, Endereco endereco)
        {
            Nome = nome;         
            Contato = contato;
            Endereco = endereco;
        }

    }
}
