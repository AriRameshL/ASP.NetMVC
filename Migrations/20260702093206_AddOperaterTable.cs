using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AudioSeller.Migrations
{
    /// <inheritdoc />
    public partial class AddOperaterTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Operator",
                columns: table => new
                {
                    OperCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DOB = table.Column<DateOnly>(type: "date", nullable: false),
                    Active = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operator", x => x.OperCode);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Operator");
        }
    }
}
