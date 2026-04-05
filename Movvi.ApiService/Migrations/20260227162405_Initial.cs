using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movvi.ApiService.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Tenant_TenantId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_TenantId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Tenant",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tenant_UserId",
                table: "Tenant",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tenant_User_UserId",
                table: "Tenant",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tenant_User_UserId",
                table: "Tenant");

            migrationBuilder.DropIndex(
                name: "IX_Tenant_UserId",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Tenant");

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_User_TenantId",
                table: "User",
                column: "TenantId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Tenant_TenantId",
                table: "User",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
