using Microsoft.EntityFrameworkCore.Migrations;

namespace EjercicioDepartamentos2.Migrations
{
    public partial class añadidoimagenEmpleado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Imagen",
                table: "Empleado",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagen",
                table: "Empleado");
        }
    }
}
