using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CiberStore.Migrations
{
    public partial class CreateNewColumnDeliveryInClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeliveryAddress",
                table: "client",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryAddress",
                table: "client");
        }
    }
}
