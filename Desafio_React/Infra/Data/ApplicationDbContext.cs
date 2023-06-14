using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Desafio_React.Domain.Client;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio_React.Infra.Data
{
    public class ApplicationDbContext:IdentityDbContext<IdentityUser>
    {
        public DbSet<Client> Clientes { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public ApplicationDbContext()
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder) 
        {
            base.OnModelCreating(builder);

            builder.Entity<Client>().Property(c=> c.Nome).HasMaxLength(255);
            builder.Entity<Client>().Property(c=> c.Nome).IsRequired();


            builder.Entity<Endereco>().HasKey(c => c.ClientId);
            



        }




    }
}
