using Microsoft.EntityFrameworkCore.Migrations;

namespace LiquerStore.Web.Data.Migrations
{
    public partial class Softdeletenamechange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "softDeleted",
                table: "Whiskies",
                newName: "SoftDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SoftDeleted",
                table: "Whiskies",
                newName: "softDeleted");
        }
    }
}
