using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vims_Webapi.Migrations
{
    public partial class claim_add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "damage_des",
                table: "Claim",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "damage_des",
                table: "Claim");
        }
    }
}
