using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class minorChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Movies_movieId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "filmID",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "movieId",
                table: "Tickets",
                newName: "movieID");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_movieId",
                table: "Tickets",
                newName: "IX_Tickets_movieID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Movies_movieID",
                table: "Tickets",
                column: "movieID",
                principalTable: "Movies",
                principalColumn: "movieId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Movies_movieID",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "movieID",
                table: "Tickets",
                newName: "movieId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_movieID",
                table: "Tickets",
                newName: "IX_Tickets_movieId");

            migrationBuilder.AddColumn<int>(
                name: "filmID",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Movies_movieId",
                table: "Tickets",
                column: "movieId",
                principalTable: "Movies",
                principalColumn: "movieId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
