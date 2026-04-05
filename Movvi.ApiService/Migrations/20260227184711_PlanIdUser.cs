using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movvi.ApiService.Migrations
{
    /// <inheritdoc />
    public partial class PlanIdUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Plan",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Plan",
                table: "User");
        }
    }
}
