using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AudioSeller.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AudioMaster",
                columns: table => new
                {
                    AudioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AudioName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoverImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rate = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudioMaster", x => x.AudioId);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PinCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Purchase",
                columns: table => new
                {
                    TranNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TranDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AudioId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Pieces = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Cancel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CanceledTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.TranNo);
                    table.ForeignKey(
                        name: "FK_Purchase_AudioMaster_AudioId",
                        column: x => x.AudioId,
                        principalTable: "AudioMaster",
                        principalColumn: "AudioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchase_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_AudioId",
                table: "Purchase",
                column: "AudioId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_CustomerId",
                table: "Purchase",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Purchase");

            migrationBuilder.DropTable(
                name: "AudioMaster");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
