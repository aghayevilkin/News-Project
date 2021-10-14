using Microsoft.EntityFrameworkCore.Migrations;

namespace News.Migrations
{
    public partial class EditNewsCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_NewsCategories_CategoryId",
                table: "News");

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

            migrationBuilder.AddForeignKey(
                name: "FK_News_NewsSubCategories_CategoryId",
                table: "News",
                column: "CategoryId",
                principalTable: "NewsSubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_NewsCategories_NewsCategoryId",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_News_NewsSubCategories_CategoryId",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_News_NewsCategoryId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "NewsCategoryId",
                table: "News");

            migrationBuilder.AddForeignKey(
                name: "FK_News_NewsCategories_CategoryId",
                table: "News",
                column: "CategoryId",
                principalTable: "NewsCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
