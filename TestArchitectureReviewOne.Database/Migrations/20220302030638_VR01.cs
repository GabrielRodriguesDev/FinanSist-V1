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
                name: "Entidade",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "varchar(60)", nullable: false, comment: "Nome da entidade")
                        .Annotation("MySql:CharSet", "utf8"),
                    Apelido = table.Column<string>(type: "varchar(60)", nullable: true, comment: "Apelido da entidade")
                        .Annotation("MySql:CharSet", "utf8"),
                    CriadoEm = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    AlteradoEm = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entidade", x => x.Id);
                },
                comment: "Tabela reposável por registrar as entidades")
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.CreateIndex(
                name: "unq1_entidade",
                table: "Entidade",
                column: "Nome",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entidade");
        }
    }
}
