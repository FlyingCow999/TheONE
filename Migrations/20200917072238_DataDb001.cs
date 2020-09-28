using Microsoft.EntityFrameworkCore.Migrations;

namespace Flying_Cow_TMSAPI.Migrations
{
    public partial class DataDb001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "r_EndPlace",
                table: "Route",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "r_StratPlace",
                table: "Route",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "r_EndPlace",
                table: "Route");

            migrationBuilder.DropColumn(
                name: "r_StratPlace",
                table: "Route");
        }
    }
}
