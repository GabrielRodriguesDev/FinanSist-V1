using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanSist.Database.Migrations
{
    public partial class VR01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "varchar(120)", nullable: false, comment: "Nome da categoria")
                        .Annotation("MySql:CharSet", "utf8"),
                    Tipo = table.Column<string>(type: "varchar(1)", nullable: false, comment: "Gerenciador de estado que define qual é o tipo da categoria, sendo eles: 0 [Receita] e 1 [Despesa]")
                        .Annotation("MySql:CharSet", "utf8"),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    AlteradoEm = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                },
                comment: "Tabela reposável pelos registros das categorias")
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.CreateTable(
                name: "Entidade",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "varchar(120)", nullable: false, comment: "Nome da entidade")
                        .Annotation("MySql:CharSet", "utf8"),
                    Descricao = table.Column<string>(type: "varchar(200)", nullable: false, comment: "Descrição da entidade")
                        .Annotation("MySql:CharSet", "utf8"),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    AlteradoEm = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entidade", x => x.Id);
                },
                comment: "Tabela reposável pelos registros das entidades")
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "varchar(120)", nullable: false, comment: "Nome da Tag")
                        .Annotation("MySql:CharSet", "utf8"),
                    Descricao = table.Column<string>(type: "varchar(200)", nullable: false, comment: "Descrição da Tag")
                        .Annotation("MySql:CharSet", "utf8"),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    AlteradoEm = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "varchar(120)", nullable: false, comment: "Nome do usuário")
                        .Annotation("MySql:CharSet", "utf8"),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false, comment: "E-mail do usuário")
                        .Annotation("MySql:CharSet", "utf8"),
                    Telefone = table.Column<string>(type: "varchar(30)", nullable: false, comment: "Telefone do usuário")
                        .Annotation("MySql:CharSet", "utf8"),
                    Senha = table.Column<string>(type: "LONGTEXT", nullable: true, comment: "Senha do usuário")
                        .Annotation("MySql:CharSet", "utf8"),
                    TokenSenha = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    TokenSenhaValidade = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ExigirNovaSenha = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Permissao = table.Column<string>(type: "varchar(20)", nullable: false, comment: "Permissão do usuário, sendo elas: Administrador e Padrao")
                        .Annotation("MySql:CharSet", "utf8"),
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
                name: "UnqEntidadeNome",
                table: "Entidade",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UnqUsuarioEmail",
                table: "Usuario",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Entidade");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
