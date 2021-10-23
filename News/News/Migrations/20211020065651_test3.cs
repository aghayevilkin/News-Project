using Microsoft.EntityFrameworkCore.Migrations;

namespace News.Migrations
{
    public partial class test3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_NewsCategories_NewsCategoryId",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_News_NewsCategoryId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "NewsCategoryId",
                table: "News");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NewsCategoryId",
                table: "News",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_News_NewsCategoryId",
                table: "News",
                column: "NewsCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_NewsCategories_NewsCategoryId",
                table: "News",
                column: "NewsCategoryId",
                principalTable: "NewsCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
