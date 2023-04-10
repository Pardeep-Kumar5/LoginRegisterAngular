using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_Login_Register_Task.Migrations
{
    public partial class addcolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Registers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Registers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
