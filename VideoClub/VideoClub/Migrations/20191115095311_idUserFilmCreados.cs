using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoClub.Migrations
{
    public partial class idUserFilmCreados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFilm_Film_FilmId",
                table: "UserFilm");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFilm_User_UserId",
                table: "UserFilm");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserFilm",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FilmId",
                table: "UserFilm",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFilm_Film_FilmId",
                table: "UserFilm",
                column: "FilmId",
                principalTable: "Film",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFilm_User_UserId",
                table: "UserFilm",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFilm_Film_FilmId",
                table: "UserFilm");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFilm_User_UserId",
                table: "UserFilm");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserFilm",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "FilmId",
                table: "UserFilm",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_UserFilm_Film_FilmId",
                table: "UserFilm",
                column: "FilmId",
                principalTable: "Film",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFilm_User_UserId",
                table: "UserFilm",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
