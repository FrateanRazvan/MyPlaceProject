using Microsoft.EntityFrameworkCore.Migrations;

namespace MyPlace.Migrations
{
    public partial class updateProgrammes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_programmes",
                table: "programmes");

            migrationBuilder.RenameTable(
                name: "programmes",
                newName: "Programmes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Programmes",
                table: "Programmes",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Programmes",
                table: "Programmes");

            migrationBuilder.RenameTable(
                name: "Programmes",
                newName: "programmes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_programmes",
                table: "programmes",
                column: "id");
        }
    }
}
