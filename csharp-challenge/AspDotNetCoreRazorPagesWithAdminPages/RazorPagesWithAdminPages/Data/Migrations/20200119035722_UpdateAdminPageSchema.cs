using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesWithAdminPages.Data.Migrations
{
    public partial class UpdateAdminPageSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfTodoIsIncompleted",
                table: "AdminPage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfTodoIsIncompleted",
                table: "AdminPage",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
