using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanSist.Database.Migrations
{
    public partial class VR03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Tag",
                type: "varchar(200)",
                nullable: true,
                comment: "Descrição da Tag",
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldComment: "Descrição da Tag")
                .Annotation("MySql:CharSet", "utf8")
                .OldAnnotation("MySql:CharSet", "utf8");

            migrationBuilder.CreateIndex(
                name: "UndTagNome",
                table: "Tag",
                column: "Nome",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UndTagNome",
                table: "Tag");

            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "Descricao",
                keyValue: null,
                column: "Descricao",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Tag",
                type: "varchar(200)",
                nullable: false,
                comment: "Descrição da Tag",
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldNullable: true,
                oldComment: "Descrição da Tag")
                .Annotation("MySql:CharSet", "utf8")
                .OldAnnotation("MySql:CharSet", "utf8");
        }
    }
}
