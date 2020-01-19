using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesWithAdminPages.Data.Migrations
{
    public partial class CreateAdminPageSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminPage",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    NumberOfTodoIsIncompleted = table.Column<int>(nullable: false),
                    MaxTodoIsIncompleted = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminPage", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_AdminPage_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminPage");
        }
    }
}
