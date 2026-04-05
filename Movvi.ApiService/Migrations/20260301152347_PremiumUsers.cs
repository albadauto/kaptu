using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movvi.ApiService.Migrations
{
    /// <inheritdoc />
    public partial class PremiumUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Plan",
                table: "Tenant");

            migrationBuilder.AddColumn<bool>(
                name: "IsPremium",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "PremiumUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Plan = table.Column<int>(type: "int", nullable: false),
                    NextPayment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastPayment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PremiumUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PremiumUsers_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PremiumUsers_UserId",
                table: "PremiumUsers",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PremiumUsers");

            migrationBuilder.DropColumn(
                name: "IsPremium",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "Plan",
                table: "Tenant",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
