using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VCProryv.DataAccess.Postgres.Migrations;

/// <inheritdoc />
public partial class InitialCreate : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Activities",
            columns: table => new
            {
                Id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Name = table.Column<string>(type: "text", nullable: false),
                Degree = table.Column<string>(type: "text", nullable: false),
                Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Activities", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Volunteers",
            columns: table => new
            {
                Id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Name = table.Column<string>(type: "text", nullable: false),
                Institute = table.Column<string>(type: "text", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Volunteers", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "ActivityVolunteer",
            columns: table => new
            {
                ActivitiesId = table.Column<int>(type: "integer", nullable: false),
                VolunteersId = table.Column<int>(type: "integer", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ActivityVolunteer", x => new { x.ActivitiesId, x.VolunteersId });
                table.ForeignKey(
                    name: "FK_ActivityVolunteer_Activities_ActivitiesId",
                    column: x => x.ActivitiesId,
                    principalTable: "Activities",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_ActivityVolunteer_Volunteers_VolunteersId",
                    column: x => x.VolunteersId,
                    principalTable: "Volunteers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_ActivityVolunteer_VolunteersId",
            table: "ActivityVolunteer",
            column: "VolunteersId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "ActivityVolunteer");

        migrationBuilder.DropTable(
            name: "Activities");

        migrationBuilder.DropTable(
            name: "Volunteers");
    }
}
