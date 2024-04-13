using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITJobs.Migrations
{
    /// <inheritdoc />
    public partial class _8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Jobid",
                table: "Notifications",
                newName: "Applied");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Applied",
                table: "Notifications",
                newName: "Jobid");
        }
    }
}
