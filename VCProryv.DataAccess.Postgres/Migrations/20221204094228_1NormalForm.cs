using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VCProryv.DataAccess.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class _1NormalForm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "Volunteers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Volunteers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "Volunteers");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Volunteers");
        }
    }
}
