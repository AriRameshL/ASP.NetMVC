using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AudioSeller.Migrations
{
    /// <inheritdoc />
    public partial class AlterOperatorTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Operator",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Operator",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Operator_Email",
                table: "Operator",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Operator_MobileNo",
                table: "Operator",
                column: "MobileNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Operator_OperName",
                table: "Operator",
                column: "OperName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Operator_Email",
                table: "Operator");

            migrationBuilder.DropIndex(
                name: "IX_Operator_MobileNo",
                table: "Operator");

            migrationBuilder.DropIndex(
                name: "IX_Operator_OperName",
                table: "Operator");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Operator");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Operator",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
