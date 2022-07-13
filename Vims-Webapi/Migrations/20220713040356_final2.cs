using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vims_Webapi.Migrations
{
    public partial class final2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Initial_policy_no",
                table: "renew_policy",
                newName: "Initial_policy_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Initial_policy_Id",
                table: "renew_policy",
                newName: "Initial_policy_no");
        }
    }
}
