using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movvi.ApiService.Migrations
{
    /// <inheritdoc />
    public partial class Relacao_Premium_Plans : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Plan",
                table: "PremiumUsers",
                newName: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_PremiumUsers_PlanId",
                table: "PremiumUsers",
                column: "PlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_PremiumUsers_Plans_PlanId",
                table: "PremiumUsers",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PremiumUsers_Plans_PlanId",
                table: "PremiumUsers");

            migrationBuilder.DropIndex(
                name: "IX_PremiumUsers_PlanId",
                table: "PremiumUsers");

            migrationBuilder.RenameColumn(
                name: "PlanId",
                table: "PremiumUsers",
                newName: "Plan");
        }
    }
}
