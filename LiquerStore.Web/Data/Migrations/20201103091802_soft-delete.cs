using Microsoft.EntityFrameworkCore.Migrations;

namespace LiquerStore.Web.Data.Migrations
{
    public partial class softdelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_whiskies",
                table: "whiskies");

            migrationBuilder.RenameTable(
                name: "whiskies",
                newName: "Whiskies");

            migrationBuilder.AddColumn<bool>(
                name: "softDeleted",
                table: "Whiskies",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Whiskies",
                table: "Whiskies",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Whiskies",
                table: "Whiskies");

            migrationBuilder.DropColumn(
                name: "softDeleted",
                table: "Whiskies");

            migrationBuilder.RenameTable(
                name: "Whiskies",
                newName: "whiskies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_whiskies",
                table: "whiskies",
                column: "Id");
        }
    }
}
