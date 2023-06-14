using Desafio_React.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Desafio_React.EndPoints.Cliente
{
    public class ClienteGetAll
    {
        public static string Template => "/cliente";
        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
        public static Delegate Handler => Action;
        public static IResult Action(ApplicationDbContext context)
        {
            var Clientes = context.Clientes.Include(c=> c.Contato).Include(c=> c.Endereco).OrderBy(c=> c.Nome).ToList();
            var Response = Clientes.ToList().Select(c => new ClienteResponse(c.Nome, c.DataCadastro, 
                c.Contato.Tipo, c.Contato.Texto, 
                c.Endereco.Cep, c.Endereco.Logradouro, c.Endereco.Cidade, c.Endereco.Numero, c.Endereco.Complemento));

            return Results.Ok(Response);

        }
    }
}
