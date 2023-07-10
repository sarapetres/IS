using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedcartAndTickets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Movies_movieId",
                table: "Tickets");

            migrationBuilder.AlterColumn<int>(
                name: "movieId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ticketInShoppingCarts",
                columns: table => new
                {
                    ticketId = table.Column<int>(type: "int", nullable: false),
                    cartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ticketInShoppingCarts", x => new { x.cartId, x.ticketId });
                    table.ForeignKey(
                        name: "FK_ticketInShoppingCarts_ShoppingCarts_cartId",
                        column: x => x.cartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "cartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ticketInShoppingCarts_Tickets_ticketId",
                        column: x => x.ticketId,
                        principalTable: "Tickets",
                        principalColumn: "ticketId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ticketInShoppingCarts_ticketId",
                table: "ticketInShoppingCarts",
                column: "ticketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Movies_movieId",
                table: "Tickets",
                column: "movieId",
                principalTable: "Movies",
                principalColumn: "movieId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Movies_movieId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "ticketInShoppingCarts");

            migrationBuilder.AlterColumn<int>(
                name: "movieId",
                table: "Tickets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Movies_movieId",
                table: "Tickets",
                column: "movieId",
                principalTable: "Movies",
                principalColumn: "movieId");
        }
    }
}
