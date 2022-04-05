using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioBackEnd.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sensor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Altura = table.Column<string>(nullable: true),
                    Largura = table.Column<string>(nullable: true),
                    Comprimento = table.Column<string>(nullable: true),
                    TensaoBateria = table.Column<double>(nullable: false),
                    Marca = table.Column<int>(nullable: false),
                    Tipo = table.Column<int>(nullable: false),
                    UltimaMedicao = table.Column<string>(nullable: true),
                    Localizacao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensor", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sensor");
        }
    }
}
