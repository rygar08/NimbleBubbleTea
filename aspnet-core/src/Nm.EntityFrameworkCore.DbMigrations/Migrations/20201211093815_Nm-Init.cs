using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nm.Migrations
{
    public partial class NmInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppCupSizes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCupSizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppFlavours",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppFlavours", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppTeas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppTeas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppToppings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppToppings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppCupSizes");

            migrationBuilder.DropTable(
                name: "AppFlavours");

            migrationBuilder.DropTable(
                name: "AppTeas");

            migrationBuilder.DropTable(
                name: "AppToppings");
        }
    }
}
