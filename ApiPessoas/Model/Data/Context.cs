using Microsoft.EntityFrameworkCore;

namespace ApiPessoas.Model.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<Pessoa> Pessoa { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>().HasData(new Pessoa
            {
                Id = 1,
                Nome = "Bruce Wayne",
                TipoPessoa = Enum.TipoPessoa.PF,
                TipoFuncao = Enum.TipoFuncao.Emissor,
                Documento = "00000000000",
                Endereco = "Gotham City",
                Telefone = "1140028921",
                Email = "bruce@email.com"
            });
            modelBuilder.Entity<Pessoa>().HasData(new Pessoa
            {
                Id = 2,
                Nome = "Industrias Wayne",
                TipoPessoa = Enum.TipoPessoa.PJ,
                TipoFuncao = Enum.TipoFuncao.Beneficiario,
                Documento = "00000000000001",
                Endereco = "Gotham City",
                Telefone = "1140028922",
                Email = "industrueswayne@email.com"
            });

        }
    }
}
