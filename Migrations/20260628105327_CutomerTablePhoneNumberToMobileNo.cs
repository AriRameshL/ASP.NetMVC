using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AudioSeller.Migrations
{
    /// <inheritdoc />
    public partial class CutomerTablePhoneNumberToMobileNo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Customer");

            migrationBuilder.AlterColumn<string>(
                name: "CustName",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobileNo",
                table: "Customer",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MobileNo",
                table: "Customer");

            migrationBuilder.AlterColumn<string>(
                name: "CustName",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
