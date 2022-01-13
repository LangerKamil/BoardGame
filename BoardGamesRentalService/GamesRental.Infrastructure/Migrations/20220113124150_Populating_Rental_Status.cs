using Microsoft.EntityFrameworkCore.Migrations;

namespace GamesRental.Infrastructure.Migrations
{
    public partial class Populating_Rental_Status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("RentalStatuses","Status","Rented");
            migrationBuilder.InsertData("RentalStatuses","Status","Returned");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
