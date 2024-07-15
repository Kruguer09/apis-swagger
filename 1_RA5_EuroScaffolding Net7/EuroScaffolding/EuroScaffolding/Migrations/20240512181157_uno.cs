using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EuroScaffolding.Migrations
{
    /// <inheritdoc />
    public partial class uno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EdFestivales",
                columns: table => new
                {
                    Identificador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Anyo = table.Column<int>(type: "int", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EdFestivales", x => x.Identificador);
                });

            migrationBuilder.CreateTable(
                name: "Canciones",
                columns: table => new
                {
                    Identificador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EdFestivalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Canciones", x => x.Identificador);
                    table.ForeignKey(
                        name: "FK_Canciones_EdFestivales_EdFestivalId",
                        column: x => x.EdFestivalId,
                        principalTable: "EdFestivales",
                        principalColumn: "Identificador",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    CancionIdentificador = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.CancionIdentificador);
                    table.ForeignKey(
                        name: "FK_Paises_Canciones_CancionIdentificador",
                        column: x => x.CancionIdentificador,
                        principalTable: "Canciones",
                        principalColumn: "Identificador",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Canciones_EdFestivalId",
                table: "Canciones",
                column: "EdFestivalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Paises");

            migrationBuilder.DropTable(
                name: "Canciones");

            migrationBuilder.DropTable(
                name: "EdFestivales");
        }
    }
}
