using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAboutProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "about_profiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Heading = table.Column<string>(type: "character varying(160)", maxLength: 160, nullable: false),
                    Introduction = table.Column<string>(type: "character varying(600)", maxLength: 600, nullable: false),
                    Biography = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "character varying(160)", maxLength: 160, nullable: false),
                    Availability = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    UpdatedUtc = table.Column<DateTime>(type: "timestamptz", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_about_profiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "about_capabilities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AboutProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(160)", maxLength: 160, nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_about_capabilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_about_capabilities_about_profiles_AboutProfileId",
                        column: x => x.AboutProfileId,
                        principalTable: "about_profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_about_capabilities_AboutProfileId_DisplayOrder",
                table: "about_capabilities",
                columns: new[] { "AboutProfileId", "DisplayOrder" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "about_capabilities");

            migrationBuilder.DropTable(
                name: "about_profiles");
        }
    }
}
