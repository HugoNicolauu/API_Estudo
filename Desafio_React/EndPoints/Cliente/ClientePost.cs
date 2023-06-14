using Desafio_React.Infra.Data;
using Desafio_React.Domain.Client;

namespace Desafio_React.EndPoints.Cliente
{
    public class ClientePost
    {
        public static string Template => "/cliente";
        public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
        public static Delegate Handler => Action;
        public static IResult Action(ClienteRequest clienteRequest, ApplicationDbContext context, HttpContext http)
        {
            var contato = new Contato(clienteRequest.id, clienteRequest.contTipo, clienteRequest.contTexto);
            var endereco = new Endereco(clienteRequest.id,clienteRequest.Endcep,clienteRequest.Endnumero);
            var cliente = new Client(clienteRequest.id,clienteRequest.nome,contato, endereco);

            context.Clientes.Add(cliente);          
            context.SaveChanges();
            return Results.Created($"/cliente/{cliente.Id}", cliente.Id);
        }
    }
}
