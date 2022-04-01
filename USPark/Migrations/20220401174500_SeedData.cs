using Microsoft.EntityFrameworkCore.Migrations;

namespace USPark.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Parks",
                columns: new[] { "ParkId", "ADA", "Activities", "Amenities", "City", "ManagedBy", "Name", "State" },
                values: new object[,]
                {
                    { 1, true, "lots", "lots", "Cody", "National Park Service", "Yellowstone", "Wyoming" },
                    { 2, true, "lots", "lots", "Gardiner", "National Park Service", "Yellowstone", "Montana" },
                    { 4, true, "hiking, camping", "lots", "Jackson", "National Park Service", "Grand Teton", "Wyoming" },
                    { 5, true, "fishing", "restrooms", "Molalla", "Bureau of Land Management", "Molalla River Recreation Area", "Oregon" },
                    { 6, true, "trail running", "", "Portland", "Portland Parks and Recreation", "Forest Park", "Oregon" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 6);
        }
    }
}
