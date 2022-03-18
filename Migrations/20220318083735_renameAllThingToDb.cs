using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Migrations
{
    public partial class renameAllThingToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AttchmentUrl",
                table: "Comment",
                newName: "Content");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Comment",
                newName: "AttchmentUrl");
        }
    }
}
