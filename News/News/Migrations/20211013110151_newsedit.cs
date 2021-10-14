using Microsoft.EntityFrameworkCore.Migrations;

namespace News.Migrations
{
    public partial class newsedit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NewsStatus",
                table: "News",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewsStatus",
                table: "News");
        }
    }
}
