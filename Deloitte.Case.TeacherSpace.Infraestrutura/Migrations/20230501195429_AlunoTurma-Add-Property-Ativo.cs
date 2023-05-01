using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deloitte.Case.TeacherSpace.Infraestrutura.Migrations
{
    public partial class AlunoTurmaAddPropertyAtivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "AlunoTurmas",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
