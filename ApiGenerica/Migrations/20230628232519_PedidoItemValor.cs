using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiGenerica.Migrations
{
    public partial class PedidoItemValor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Valor",
                table: "PedidoItems",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Valor",
                table: "PedidoItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
