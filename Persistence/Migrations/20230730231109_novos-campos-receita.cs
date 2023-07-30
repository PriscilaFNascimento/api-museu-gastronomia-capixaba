using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class novoscamposreceita : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ValorDiario",
                table: "InformacoesNutricionais",
                newName: "PercentualValorDiario");

            migrationBuilder.AddColumn<string>(
                name: "Rendimento",
                table: "Receitas",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TempoPreparo",
                table: "Receitas",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rendimento",
                table: "Receitas");

            migrationBuilder.DropColumn(
                name: "TempoPreparo",
                table: "Receitas");

            migrationBuilder.RenameColumn(
                name: "PercentualValorDiario",
                table: "InformacoesNutricionais",
                newName: "ValorDiario");
        }
    }
}
