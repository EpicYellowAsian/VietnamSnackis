using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VietnamSnackis.Migrations
{
    /// <inheritdoc />
    public partial class Third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreatePost_Category_CategoryId",
                table: "CreatePost");

            migrationBuilder.DropForeignKey(
                name: "FK_CreatePost_SubCategory_SubCategoryId",
                table: "CreatePost");

            migrationBuilder.DropIndex(
                name: "IX_CreatePost_CategoryId",
                table: "CreatePost");

            migrationBuilder.DropIndex(
                name: "IX_CreatePost_SubCategoryId",
                table: "CreatePost");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CreatePost_CategoryId",
                table: "CreatePost",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CreatePost_SubCategoryId",
                table: "CreatePost",
                column: "SubCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CreatePost_Category_CategoryId",
                table: "CreatePost",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CreatePost_SubCategory_SubCategoryId",
                table: "CreatePost",
                column: "SubCategoryId",
                principalTable: "SubCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
