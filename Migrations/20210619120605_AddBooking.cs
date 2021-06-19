using Microsoft.EntityFrameworkCore.Migrations;

namespace MyPlace.Migrations
{
    public partial class AddBooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "Rents",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rents_BookingId",
                table: "Rents",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rents_Bookings_BookingId",
                table: "Rents",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rents_Bookings_BookingId",
                table: "Rents");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Rents_BookingId",
                table: "Rents");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Rents");
        }
    }
}
