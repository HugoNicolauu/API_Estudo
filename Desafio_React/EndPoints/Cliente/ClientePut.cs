using Desafio_React.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_React.EndPoints.Cliente
{
    public class ClientePut
    {
        public static string Template => "/cliente/{id:int}";
        public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
        public static Delegate Handler => Action;
        public static IResult Action([FromRoute] int id,ClienteRequest clienteRequest,ApplicationDbContext context)
        {
            var cliente = context.Clientes.Where(c=> c.Id==id).FirstOrDefault();
            if(cliente == null) 
            {
                return Results.NotFound();
            }
            var endereco = context.Enderecos.Where(e => e.ClientId == cliente.Id).First();
            var contato = context.Contatos.Where(con => con.Id == cliente.Id).First();

            endereco.EditarEndereco(clienteRequest.Endcep, clienteRequest.Endnumero);
            contato.EditarContato(clienteRequest.contTipo, clienteRequest.contTexto);


            cliente.EditarCliente(clienteRequest.nome, contato, endereco);

            context.SaveChanges();

            return Results.Created($"/cliente/{cliente.Id}", cliente.Id);




        }
    }
}
