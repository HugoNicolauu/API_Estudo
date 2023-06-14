
using Desafio_React.EndPoints.Cliente;
using Desafio_React.Infra.Data;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

namespace Desafio_React
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration["ConnectionStrings:Desafio"];
            builder.Services.AddMySql<ApplicationDbContext>(connectionString,ServerVersion.AutoDetect(connectionString));


            builder.Services.AddAuthorization();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.MapMethods(ClientePost.Template, ClientePost.Methods, ClientePost.Handler);
            app.MapMethods(ClienteGetAll.Template, ClienteGetAll.Methods, ClienteGetAll.Handler);
            app.MapMethods(ClientePut.Template, ClientePut.Methods, ClientePut.Handler);
            app.MapMethods(ClienteDelete.Template, ClienteDelete.Methods, ClienteDelete.Handler);
            app.MapMethods(ClienteGet.Template, ClienteGet.Methods, ClienteGet.Handler);



            //app.UseExceptionHandler("/error");
            //app.Map("error", (HttpContext http) =>
            //{
            //    var error = http.Features?.Get<IExceptionHandlerFeature>()?.Error;
            //    if (error != null)
            //    {
            //        if (error is MySqlException)
            //        {
            //            return Results.Problem(title: "Database Desconectado", statusCode: 500);
            //        }
            //        else if (error is BadHttpRequestException)
            //        {
            //            return Results.Problem(title: "Erro na conversão do dado", statusCode: 500);
            //        }
            //    }
            //    return Results.Problem(title: "Erro!!", statusCode: 500);
            //});



            app.UseAuthorization();

           

            app.Run();
        }
    }
}