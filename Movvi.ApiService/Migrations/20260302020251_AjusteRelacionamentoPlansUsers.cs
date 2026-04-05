using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movvi.ApiService.Migrations
{
    /// <inheritdoc />
    public partial class AjusteRelacionamentoPlansUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_PlanId",
                table: "User");

            migrationBuilder.CreateIndex(
                name: "IX_User_PlanId",
                table: "User",
                column: "PlanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_PlanId",
                table: "User");

            migrationBuilder.CreateIndex(
                name: "IX_User_PlanId",
                table: "User",
                column: "PlanId",
                unique: true);
        }
    }
}
