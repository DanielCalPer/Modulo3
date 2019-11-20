using Microsoft.EntityFrameworkCore.Migrations;

namespace EjercicioDepartamentos2.Migrations
{
    public partial class modelosactualizados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmpleadoId",
                table: "Departamento",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Departamento_EmpleadoId",
                table: "Departamento",
                column: "EmpleadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departamento_Empleado_EmpleadoId",
                table: "Departamento",
                column: "EmpleadoId",
                principalTable: "Empleado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departamento_Empleado_EmpleadoId",
                table: "Departamento");

            migrationBuilder.DropIndex(
                name: "IX_Departamento_EmpleadoId",
                table: "Departamento");

            migrationBuilder.DropColumn(
                name: "EmpleadoId",
                table: "Departamento");
        }
    }
}
