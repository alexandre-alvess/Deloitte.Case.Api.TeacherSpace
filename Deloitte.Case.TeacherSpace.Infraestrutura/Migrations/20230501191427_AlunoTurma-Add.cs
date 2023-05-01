using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deloitte.Case.TeacherSpace.Infraestrutura.Migrations
{
    public partial class AlunoTurmaAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professores_Pessoas_PessoaId",
                table: "Professores");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Pessoas_PessoaId",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "AlunoTurma");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_PessoaId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Professores_PessoaId",
                table: "Professores");

            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "Usuarios",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Usuarios",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Usuarios",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Turmas",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Turmas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Professores",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Pessoas",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Pessoas",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Pessoas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Disciplinas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Disciplinas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Boletins",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateTable(
                name: "AlunoTurmas",
                columns: table => new
                {
                    AlunoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TurmaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoTurmas", x => new { x.AlunoId, x.TurmaId });
                    table.ForeignKey(
                        name: "FK_AlunoTurmas_Aluno_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoTurmas_Turmas_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "Turmas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_PessoaId",
                table: "Usuarios",
                column: "PessoaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Professores_PessoaId",
                table: "Professores",
                column: "PessoaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AlunoTurmas_TurmaId",
                table: "AlunoTurmas",
                column: "TurmaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Professor_Pessoa",
                table: "Professores",
                column: "PessoaId",
                principalTable: "Pessoas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Pessoa",
                table: "Usuarios",
                column: "PessoaId",
                principalTable: "Pessoas",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professor_Pessoa",
                table: "Professores");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Pessoa",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "AlunoTurmas");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_PessoaId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Professores_PessoaId",
                table: "Professores");

            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldUnicode: false,
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Usuarios",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Turmas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldMaxLength: 80);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Turmas",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Professores",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Pessoas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Pessoas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Pessoas",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Disciplinas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Disciplinas",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Boletins",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.CreateTable(
                name: "AlunoTurma",
                columns: table => new
                {
                    AlunosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TurmasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoTurma", x => new { x.AlunosId, x.TurmasId });
                    table.ForeignKey(
                        name: "FK_AlunoTurma_Aluno_AlunosId",
                        column: x => x.AlunosId,
                        principalTable: "Aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoTurma_Turmas_TurmasId",
                        column: x => x.TurmasId,
                        principalTable: "Turmas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_PessoaId",
                table: "Usuarios",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Professores_PessoaId",
                table: "Professores",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoTurma_TurmasId",
                table: "AlunoTurma",
                column: "TurmasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Professores_Pessoas_PessoaId",
                table: "Professores",
                column: "PessoaId",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Pessoas_PessoaId",
                table: "Usuarios",
                column: "PessoaId",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
