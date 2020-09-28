using Microsoft.EntityFrameworkCore.Migrations;

namespace Flying_Cow_TMSAPI.Migrations
{
    public partial class Db006 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ciid",
                table: "Carrier_Profit");

            migrationBuilder.AddColumn<int>(
                name: "oid",
                table: "Carrier_Profit",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "oid",
                table: "Carrier_Profit");

            migrationBuilder.AddColumn<int>(
                name: "ciid",
                table: "Carrier_Profit",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
