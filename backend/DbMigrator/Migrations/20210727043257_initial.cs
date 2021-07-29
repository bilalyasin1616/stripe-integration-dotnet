using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DbMigrator.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    City = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Phone = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    Email = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    AddressLine1 = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    AddressLine2 = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    State = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    Postal = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    CountryId = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    Image = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    StripeCustomerId = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp", nullable: false),
                    CreatedByName = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    DateLastUpdated = table.Column<DateTime>(type: "timestamp", nullable: false),
                    LastUpdateByName = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    LastUpdatedById = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
