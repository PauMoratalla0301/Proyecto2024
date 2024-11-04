using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto2024.DB.Migrations
{
    /// <inheritdoc />
    public partial class PrimeraRelacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdPedido",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PedidoId",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_PedidoId",
                table: "Clientes",
                column: "PedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Pedidos_PedidoId",
                table: "Clientes",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Pedidos_PedidoId",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_PedidoId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "IdPedido",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "PedidoId",
                table: "Clientes");
        }
    }
}
