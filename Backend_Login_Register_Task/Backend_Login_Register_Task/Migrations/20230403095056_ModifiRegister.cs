using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_Login_Register_Task.Migrations
{
    public partial class ModifiRegister : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Registers");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Registers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "Registers",
                newName: "FirstName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Registers",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Registers",
                newName: "PostalCode");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Registers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
