using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestArchitectureReviewOne.Database.Migrations
{
    public partial class VR01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "varchar(120)", nullable: false, comment: "Nome do usúario")
                        .Annotation("MySql:CharSet", "utf8"),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false, comment: "E-mail do usúario")
                        .Annotation("MySql:CharSet", "utf8"),
                    Telefone = table.Column<string>(type: "varchar(30)", nullable: false, comment: "Telefone do usúario")
                        .Annotation("MySql:CharSet", "utf8"),
                    Senha = table.Column<string>(type: "longtext", nullable: true, comment: "Senha do usúario")
                        .Annotation("MySql:CharSet", "utf8"),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    AlteradoEm = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                },
                comment: "Tabela reposável por organizar os usuários")
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.CreateIndex(
                name: "UnqUsuarioEmail",
                table: "Usuario",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
