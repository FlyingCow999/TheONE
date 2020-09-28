using Microsoft.EntityFrameworkCore.Migrations;

namespace Flying_Cow_TMSAPI.Migrations
{
    public partial class DB004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "o_branch",
                table: "Offer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "o_branch",
                table: "Offer");
        }
    }
}
