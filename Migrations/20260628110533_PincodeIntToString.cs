using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AudioSeller.Migrations
{
    /// <inheritdoc />
    public partial class PincodeIntToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PinCode",
                table: "Customer",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 6);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PinCode",
                table: "Customer",
                type: "int",
                maxLength: 6,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(6)",
                oldMaxLength: 6,
                oldNullable: true);
        }
    }
}
