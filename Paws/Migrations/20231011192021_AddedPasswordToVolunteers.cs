using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Paws.Migrations
{
    /// <inheritdoc />
    public partial class AddedPasswordToVolunteers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Volunteers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Volunteers");
        }
    }
}
