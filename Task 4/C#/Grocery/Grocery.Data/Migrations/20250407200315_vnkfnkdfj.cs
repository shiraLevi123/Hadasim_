using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Grocery.Data.Migrations
{
    public partial class vnkfnkdfj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentStock",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentStock",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
