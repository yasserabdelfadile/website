using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication6.Migrations
{
    public partial class succcfualltray : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Thecatogry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    discraption = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thecatogry", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Theteam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    jobtital = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Theteam", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tocontactus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titalmassag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    massag = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tocontactus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "yourdata",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_yourdata", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "thenews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tital = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    thedate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    catogryId = table.Column<int>(type: "int", nullable: false),
                    thecatogryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_thenews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_thenews_Thecatogry_thecatogryId",
                        column: x => x.thecatogryId,
                        principalTable: "Thecatogry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_thenews_thecatogryId",
                table: "thenews",
                column: "thecatogryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "thenews");

            migrationBuilder.DropTable(
                name: "Theteam");

            migrationBuilder.DropTable(
                name: "tocontactus");

            migrationBuilder.DropTable(
                name: "yourdata");

            migrationBuilder.DropTable(
                name: "Thecatogry");
        }
    }
}
