using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BIT_DataAccess.Migrations
{
    public partial class CommentFilesTáblaÁtnevezés : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MyProperty",
                table: "MyProperty");

            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "MyProperty");

            migrationBuilder.RenameTable(
                name: "MyProperty",
                newName: "CommentFiles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentFiles",
                table: "CommentFiles",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CommentFiles_CommentId",
                table: "CommentFiles",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentFiles_FileId",
                table: "CommentFiles",
                column: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentFiles_Comments_CommentId",
                table: "CommentFiles",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentFiles_Files_FileId",
                table: "CommentFiles",
                column: "FileId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentFiles_Comments_CommentId",
                table: "CommentFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentFiles_Files_FileId",
                table: "CommentFiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentFiles",
                table: "CommentFiles");

            migrationBuilder.DropIndex(
                name: "IX_CommentFiles_CommentId",
                table: "CommentFiles");

            migrationBuilder.DropIndex(
                name: "IX_CommentFiles_FileId",
                table: "CommentFiles");

            migrationBuilder.RenameTable(
                name: "CommentFiles",
                newName: "MyProperty");

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "MyProperty",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyProperty",
                table: "MyProperty",
                column: "Id");
        }
    }
}
