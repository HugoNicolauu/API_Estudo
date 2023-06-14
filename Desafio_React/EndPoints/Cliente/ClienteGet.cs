using Desafio_React.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Desafio_React.EndPoints.Cliente
{
    public class ClienteGet
    {
        public static string Template => "/cliente/{name}";
        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
        public static Delegate Handler => Action;
        public static IResult Action([FromRoute] string name, ApplicationDbContext context)
        {
            var Clientes = context.Clientes.Where(c=> c.Nome.Contains(name) || c.Nome == name)
                .Include(c => c.Contato).Include(c => c.Endereco).OrderBy(c => c.Nome).ToList();

            var Response = Clientes.ToList().Select(c => new ClienteResponse(c.Nome, c.DataCadastro,
                c.Contato.Tipo, c.Contato.Texto,
                c.Endereco.Cep, c.Endereco.Logradouro, c.Endereco.Cidade, c.Endereco.Numero, c.Endereco.Complemento));

            return Results.Ok(Response);

        }
    }
}
