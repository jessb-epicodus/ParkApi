using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace USParkAPI.Migrations
{
    public partial class ReestablishInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parks",
                columns: table => new
                {
                    ParkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    City = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    State = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    ManagedBy = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Activities = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Amenities = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    ADA = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parks", x => x.ParkId);
                });

            migrationBuilder.InsertData(
                table: "Parks",
                columns: new[] { "ParkId", "ADA", "Activities", "Amenities", "City", "ManagedBy", "Name", "State" },
                values: new object[,]
                {
                    { 1, true, "lots", "lots", "Cody", "National Park Service", "Yellowstone", "Wyoming" },
                    { 2, true, "lots", "lots", "Gardiner", "National Park Service", "Yellowstone", "Montana" },
                    { 3, true, "hiking, camping", "lots", "Jackson", "National Park Service", "Grand Teton", "Wyoming" },
                    { 4, true, "fishing", "restrooms", "Molalla", "Bureau of Land Management", "Molalla River Recreation Area", "Oregon" },
                    { 5, true, "trail running", "", "Portland", "Portland Parks and Recreation", "Forest Park", "Oregon" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parks");
        }
    }
}
