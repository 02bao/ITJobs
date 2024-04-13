using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITJobs.Migrations
{
    /// <inheritdoc />
    public partial class _5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Applied",
                table: "Notifications");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Applied",
                table: "Notifications",
                type: "bigint",
                nullable: true);
        }
    }
}
