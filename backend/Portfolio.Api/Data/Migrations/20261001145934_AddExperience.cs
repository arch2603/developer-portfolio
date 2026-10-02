using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddExperience : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "experiences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Company = table.Column<string>(type: "character varying(160)", maxLength: 160, nullable: false),
                    Role = table.Column<string>(type: "character varying(160)", maxLength: 160, nullable: false),
                    Location = table.Column<string>(type: "character varying(160)", maxLength: 160, nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    IsCurrent = table.Column<bool>(type: "boolean", nullable: false),
                    Summary = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false),
                    IsPublished = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_experiences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "experience_highlights",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ExperienceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_experience_highlights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_experience_highlights_experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "experiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "experience_technologies",
                columns: table => new
                {
                    ExperienceId = table.Column<Guid>(type: "uuid", nullable: false),
                    TechnologyId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_experience_technologies", x => new { x.ExperienceId, x.TechnologyId });
                    table.ForeignKey(
                        name: "FK_experience_technologies_experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "experiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_experience_technologies_technologies_TechnologyId",
                        column: x => x.TechnologyId,
                        principalTable: "technologies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_experience_highlights_ExperienceId_DisplayOrder",
                table: "experience_highlights",
                columns: new[] { "ExperienceId", "DisplayOrder" });

            migrationBuilder.CreateIndex(
                name: "IX_experience_technologies_TechnologyId",
                table: "experience_technologies",
                column: "TechnologyId");

            migrationBuilder.CreateIndex(
                name: "IX_experiences_IsPublished_DisplayOrder",
                table: "experiences",
                columns: new[] { "IsPublished", "DisplayOrder" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "experience_highlights");

            migrationBuilder.DropTable(
                name: "experience_technologies");

            migrationBuilder.DropTable(
                name: "experiences");
        }
    }
}
