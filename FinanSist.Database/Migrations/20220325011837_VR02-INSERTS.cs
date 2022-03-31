using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanSist.Database.Migrations
{
    public partial class VR02INSERTS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO `Usuario` (`Id`, `Nome`, `Email`, `Telefone`, `Senha`, `TokenSenha`, `TokenSenhaValidade`, `Ativo`, `ExigirNovaSenha`, `CriadoEm`, `AlteradoEm`, `Permissao`) VALUES ('fc6c1e16-d82d-4c82-9662-f9637bdc06fd', 'UserSystem', 'user@finansist.com.br', '1111111111', 'AB9SN9i1IdIp1dVdYsQ3jPOzdgWfSnMw44ZjCrx0M+ZREdzybv8FkzUFhZnwXdhAaA==', NULL, NULL, 1, 0, CURRENT_TIMESTAMP(), NULL, 'Padrao');");
            migrationBuilder.Sql("INSERT INTO `Usuario` (`Id`, `Nome`, `Email`, `Telefone`, `Senha`, `TokenSenha`, `TokenSenhaValidade`, `Ativo`, `ExigirNovaSenha`, `CriadoEm`, `AlteradoEm`, `Permissao`) VALUES ('4a58865e-eabb-403e-b9ab-e4017fa9b2bd', 'Administrador', 'administrador@finansist.com.br', '1111111111', 'AHdb916qt4eaqHXbPsFjhzNmnx4eYnnPM1s6qN0nAdxPZULba7nKtSw9jqwyXeWGVw==', NULL, NULL, 1, 0, CURRENT_TIMESTAMP(), NULL, 'Administrador');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
