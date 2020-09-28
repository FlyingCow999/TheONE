using Microsoft.EntityFrameworkCore.Migrations;

namespace Flying_Cow_TMSAPI.Migrations
{
    public partial class Db007 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "r_EndPlace",
                table: "Route");

            migrationBuilder.DropColumn(
                name: "r_StratPlace",
                table: "Route");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "r_EndPlace",
                table: "Route",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "r_StratPlace",
                table: "Route",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
