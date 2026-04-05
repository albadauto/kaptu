using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movvi.ApiService.Migrations
{
    /// <inheritdoc />
    public partial class NomeEmpresaUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EnterpriseName",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnterpriseName",
                table: "User");
        }
    }
}
