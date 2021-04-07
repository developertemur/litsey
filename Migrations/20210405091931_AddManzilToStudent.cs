using Microsoft.EntityFrameworkCore.Migrations;

namespace litsey.Migrations
{
    public partial class AddManzilToStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Manzil",
                table: "Student",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Manzil",
                table: "Student");
        }
    }
}
