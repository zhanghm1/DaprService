using Microsoft.EntityFrameworkCore.Migrations;

namespace DaprTest.EFCore.Admins.migrations
{
    public partial class appclient_secertfalse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "RequireClientSecret",
                table: "ApplicationClients",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequireClientSecret",
                table: "ApplicationClients");
        }
    }
}
