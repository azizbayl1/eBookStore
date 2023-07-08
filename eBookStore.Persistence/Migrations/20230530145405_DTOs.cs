using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eBookStore.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DTOs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SurName",
                schema: "Users",
                table: "User",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "Users",
                table: "User",
                newName: "FirstName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                schema: "Users",
                table: "User",
                newName: "SurName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                schema: "Users",
                table: "User",
                newName: "Name");
        }
    }
}
