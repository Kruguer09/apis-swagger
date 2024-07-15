using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ARScaffoldingJoseAFerreRico.Migrations
{
    /// <inheritdoc />
    public partial class _5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Empleados_EmpresaId",
                table: "Empleados",
                column: "EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Empresas_EmpresaId",
                table: "Empleados",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Empresas_EmpresaId",
                table: "Empleados");

            migrationBuilder.DropIndex(
                name: "IX_Empleados_EmpresaId",
                table: "Empleados");
        }
    }
}
