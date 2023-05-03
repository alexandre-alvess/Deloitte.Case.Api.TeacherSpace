using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deloitte.Case.TeacherSpace.Infraestrutura.Migrations
{
    public partial class UsuarioAddTipoPerfil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoPerfil",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoPerfil",
                table: "Usuarios");
        }
    }
}
