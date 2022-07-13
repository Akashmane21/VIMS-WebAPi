using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vims_Webapi.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Claim",
                columns: table => new
                {
                    claim_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    claim_amount = table.Column<int>(type: "int", nullable: false),
                    claim_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    custid = table.Column<int>(type: "int", nullable: false),
                    vehid = table.Column<int>(type: "int", nullable: false),
                    policyid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claim", x => x.claim_id);
                });

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    custid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    phone_no = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    address = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.custid);
                });

            migrationBuilder.CreateTable(
                name: "payment_info",
                columns: table => new
                {
                    pay_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    payment_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    paid_amount = table.Column<int>(type: "int", nullable: false),
                    custid = table.Column<int>(type: "int", nullable: false),
                    policyid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment_info", x => x.pay_id);
                });

            migrationBuilder.CreateTable(
                name: "policy",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    premium_amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    gst_amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    total_amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    renew_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    policyid = table.Column<int>(type: "int", nullable: false),
                    custid = table.Column<int>(type: "int", nullable: false),
                    vehid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_policy", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "renew_policy",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Initial_policy_no = table.Column<int>(type: "int", nullable: false),
                    renew_amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    gst_amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    total_amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Next_renew_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    vehid = table.Column<int>(type: "int", nullable: false),
                    custid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_renew_policy", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "vehicle_info",
                columns: table => new
                {
                    vehid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    regi_no = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    veh_chassis_no = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    Veh_engine_no = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    purchase_year = table.Column<int>(type: "int", nullable: false),
                    model = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    custid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicle_info", x => x.vehid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Claim");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "payment_info");

            migrationBuilder.DropTable(
                name: "policy");

            migrationBuilder.DropTable(
                name: "renew_policy");

            migrationBuilder.DropTable(
                name: "vehicle_info");
        }
    }
}
