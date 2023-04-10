using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_Login_Register_Task.Migrations
{
    public partial class registermodelcoulmnschanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Registers");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Registers",
                newName: "Username");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Registers",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Registers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
