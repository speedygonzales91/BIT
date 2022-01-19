using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BIT_DataAccess.Migrations
{
    public partial class AddNavigationIdField_CommentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NavigationId",
                table: "Comments",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NavigationId",
                table: "Comments");
        }
    }
}
