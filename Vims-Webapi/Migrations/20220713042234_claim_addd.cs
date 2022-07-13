using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vims_Webapi.Migrations
{
    public partial class claim_addd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "is_approved",
                table: "Claim",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_approved",
                table: "Claim");
        }
    }
}
