using Desafio_React.Domain.Client;
using Newtonsoft.Json;
using System.Net;

namespace Desafio_React.Infra.Data
{
    public class CepSearch
    {
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }

        public CepSearch()
        {
            
        }

        public static CepSearch GetCep(string cep)
        {
            var url = $"https://viacep.com.br/ws/{cep}/json/";
            using (var client = new WebClient())
            {
                var json = client.DownloadString(url);
                Console.WriteLine(json);
                var cepSearch = JsonConvert.DeserializeObject<CepSearch>(json);

                cepSearch.Cep = cep;
                return cepSearch;
            }
        }
    }
}
