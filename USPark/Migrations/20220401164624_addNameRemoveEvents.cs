using Microsoft.EntityFrameworkCore.Migrations;

namespace USPark.Migrations
{
    public partial class addNameRemoveEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Events",
                table: "Parks",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Parks",
                newName: "Events");
        }
    }
}
