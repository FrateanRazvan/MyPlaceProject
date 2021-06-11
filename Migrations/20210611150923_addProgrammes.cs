using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyPlace.Migrations
{
    public partial class addProgrammes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "programmes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    room = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    max_participants = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    start_programme = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_programme = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_programmes", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "programmes");
        }
    }
}
