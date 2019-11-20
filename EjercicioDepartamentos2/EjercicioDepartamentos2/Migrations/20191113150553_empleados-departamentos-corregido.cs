using Microsoft.EntityFrameworkCore.Migrations;

namespace EjercicioDepartamentos2.Migrations
{
    public partial class empleadosdepartamentoscorregido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoId",
                table: "Empleado",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_DepartamentoId",
                table: "Empleado",
                column: "DepartamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_Departamento_DepartamentoId",
                table: "Empleado",
                column: "DepartamentoId",
                principalTable: "Departamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_Departamento_DepartamentoId",
                table: "Empleado");

            migrationBuilder.DropIndex(
                name: "IX_Empleado_DepartamentoId",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "DepartamentoId",
                table: "Empleado");

            migrationBuilder.AddColumn<int>(
                name: "EmpleadoId",
                table: "Departamento",
                type: "int",
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
    }
}
