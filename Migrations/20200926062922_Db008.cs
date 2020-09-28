using Microsoft.EntityFrameworkCore.Migrations;

namespace Flying_Cow_TMSAPI.Migrations
{
    public partial class Db008 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ifid",
                table: "Abnormal");

            migrationBuilder.AddColumn<string>(
                name: "coid",
                table: "Abnormal",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "coid",
                table: "Abnormal");

            migrationBuilder.AddColumn<string>(
                name: "ifid",
                table: "Abnormal",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
