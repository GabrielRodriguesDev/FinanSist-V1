using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanSist.Database.Migrations
{
    public partial class VRteste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DespesaTag_Despesa_DespesaId",
                table: "DespesaTag");

            migrationBuilder.AlterColumn<Guid>(
                name: "DespesaId",
                table: "DespesaTag",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Identificador da despesa",
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true,
                oldComment: "Identificador da despesa")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_DespesaTag_Despesa_DespesaId",
                table: "DespesaTag",
                column: "DespesaId",
                principalTable: "Despesa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DespesaTag_Despesa_DespesaId",
                table: "DespesaTag");

            migrationBuilder.AlterColumn<Guid>(
                name: "DespesaId",
                table: "DespesaTag",
                type: "char(36)",
                nullable: true,
                comment: "Identificador da despesa",
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldComment: "Identificador da despesa")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_DespesaTag_Despesa_DespesaId",
                table: "DespesaTag",
                column: "DespesaId",
                principalTable: "Despesa",
                principalColumn: "Id");
        }
    }
}
