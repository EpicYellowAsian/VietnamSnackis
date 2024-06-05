using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VietnamSnackis.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreatePost_Category_CategoryId",
                table: "CreatePost");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "CreatePost",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CreatePost_Category_CategoryId",
                table: "CreatePost",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreatePost_Category_CategoryId",
                table: "CreatePost");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "CreatePost",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CreatePost_Category_CategoryId",
                table: "CreatePost",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
