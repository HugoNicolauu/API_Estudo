
using Desafio_React.Infra.Data;
using Newtonsoft.Json;
using System.Net;

namespace Desafio_React.Domain.Client
{
    public class Endereco
    {
        public string Cep { get; private set; }
        public string Logradouro { get; private set; }
        public string Cidade { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public int ClientId { get; set; }

        public Endereco()
        {

        }



        public Endereco(int id,string cep, string numero)
        {
            var endereco = CepSearch.GetCep(cep);

            Cep = cep;
            ClientId = id;
            Logradouro = endereco.Logradouro;
            Cidade = endereco.Localidade;
            Complemento = endereco.Complemento;
            Numero = numero;



        }
        public void EditarEndereco(string cep, string numero)
        {
            var endereco = CepSearch.GetCep(cep);

            Cep = cep;
            Logradouro = endereco.Logradouro;
            Cidade = endereco.Localidade;
            Complemento = endereco.Complemento;
            Numero = numero;



        }
    }


}
