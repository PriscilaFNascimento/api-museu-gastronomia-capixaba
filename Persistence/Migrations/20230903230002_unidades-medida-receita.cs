using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class unidadesmedidareceita : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("alter table public.\"Receitas\" alter column \"TempoPreparo\" drop default, alter column \"TempoPreparo\" type numeric(6,3) using (\"TempoPreparo\"::numeric(6,3)), alter column \"TempoPreparo\" set default 0");

            migrationBuilder.Sql("alter table public.\"Receitas\" alter column \"Rendimento\" drop default, alter column \"Rendimento\" type numeric(6,3) using (\"Rendimento\"::numeric(6,3)), alter column \"Rendimento\" set default 0");
            
            migrationBuilder.Sql("alter table public.\"Receitas\" alter column \"Porcao\" drop default, alter column \"Porcao\" type numeric(6,3) using (\"Porcao\"::numeric(6,3)), alter column \"Porcao\" set default 0");
           
            //migrationBuilder.AlterColumn<decimal>(
            //    name: "TempoPreparo",
            //    table: "Receitas",
            //    type: "numeric",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "text");

            //migrationBuilder.AlterColumn<decimal>(
            //    name: "Rendimento",
            //    table: "Receitas",
            //    type: "numeric",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "text");

            //migrationBuilder.AlterColumn<decimal>(
            //    name: "Porcao",
            //    table: "Receitas",
            //    type: "numeric",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "character varying(50)",
            //    oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "UnidadeMedidaPorcao",
                table: "Receitas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnidadeMedidaRendimento",
                table: "Receitas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnidadeTempoPreparo",
                table: "Receitas",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnidadeMedidaPorcao",
                table: "Receitas");

            migrationBuilder.DropColumn(
                name: "UnidadeMedidaRendimento",
                table: "Receitas");

            migrationBuilder.DropColumn(
                name: "UnidadeTempoPreparo",
                table: "Receitas");

            migrationBuilder.AlterColumn<string>(
                name: "TempoPreparo",
                table: "Receitas",
                type: "text",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<string>(
                name: "Rendimento",
                table: "Receitas",
                type: "text",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<string>(
                name: "Porcao",
                table: "Receitas",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");
        }
    }
}
