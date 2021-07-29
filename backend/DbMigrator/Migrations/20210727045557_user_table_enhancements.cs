using Microsoft.EntityFrameworkCore.Migrations;

namespace DbMigrator.Migrations
{
    public partial class user_table_enhancements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "account");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "User",
                newSchema: "account");

            migrationBuilder.AddColumn<bool>(
                name: "HasValidPayment",
                schema: "account",
                table: "User",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasValidatedEmail",
                schema: "account",
                table: "User",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                schema: "account",
                table: "User",
                type: "character varying(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordResetToken",
                schema: "account",
                table: "User",
                type: "character varying(150)",
                maxLength: 150,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasValidPayment",
                schema: "account",
                table: "User");

            migrationBuilder.DropColumn(
                name: "HasValidatedEmail",
                schema: "account",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Password",
                schema: "account",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PasswordResetToken",
                schema: "account",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                schema: "account",
                newName: "User");
        }
    }
}
