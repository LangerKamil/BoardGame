using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GamesRental.Infrastructure.Migrations
{
    public partial class Adding_RentalStatus_Model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RentalDate",
                table: "Rentals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "RentalStatusId",
                table: "Rentals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReturnDate",
                table: "Rentals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "RentalStatuses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalStatuses", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_RentalStatusId",
                table: "Rentals",
                column: "RentalStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_RentalStatuses_RentalStatusId",
                table: "Rentals",
                column: "RentalStatusId",
                principalTable: "RentalStatuses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_RentalStatuses_RentalStatusId",
                table: "Rentals");

            migrationBuilder.DropTable(
                name: "RentalStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_RentalStatusId",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "RentalDate",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "RentalStatusId",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "ReturnDate",
                table: "Rentals");
        }
    }
}
