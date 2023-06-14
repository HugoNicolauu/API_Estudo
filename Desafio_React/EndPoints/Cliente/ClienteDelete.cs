using Desafio_React.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Desafio_React.EndPoints.Cliente
{
    public class ClienteDelete
    {

        public static string Template => "/cliente/{id:int}";
        public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
        public static Delegate Handler => Action;
        public static IResult Action([FromRoute] int id, ApplicationDbContext context)
        {
            var cliente = context.Clientes.Where(c => c.Id == id).FirstOrDefault();

            if (cliente == null)
            {
                return Results.NotFound();
            }
            var endereco = context.Enderecos.Where(e => e.ClientId == cliente.Id).First();
            var contato = context.Contatos.Where(con => con.Id == cliente.Id).First();

            context.Enderecos.Remove(endereco);
            context.Contatos.Remove(contato);
            context.Clientes.Remove(cliente);

            context.SaveChanges();
            return Results.NoContent();

            
        }
    }
}
