using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPessoas.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PessoaTb",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TipoPessoa = table.Column<int>(type: "int", nullable: false),
                    TipoFuncao = table.Column<int>(type: "int", nullable: false),
                    Documento = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaTb", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "PessoaTb",
                columns: new[] { "Id", "Documento", "Email", "Endereco", "Nome", "Telefone", "TipoFuncao", "TipoPessoa" },
                values: new object[] { 1L, "00000000000", "bruce@email.com", "Gotham City", "Bruce Wayne", "1140028921", 0, 0 });

            migrationBuilder.InsertData(
                table: "PessoaTb",
                columns: new[] { "Id", "Documento", "Email", "Endereco", "Nome", "Telefone", "TipoFuncao", "TipoPessoa" },
                values: new object[] { 2L, "00000000000001", "industrueswayne@email.com", "Gotham City", "Industrias Wayne", "1140028922", 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PessoaTb");
        }
    }
}
