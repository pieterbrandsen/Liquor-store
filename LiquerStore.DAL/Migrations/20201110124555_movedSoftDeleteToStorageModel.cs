using Microsoft.EntityFrameworkCore.Migrations;

namespace LiquerStore.DAL.Migrations
{
    public partial class movedSoftDeleteToStorageModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoftDeleted",
                table: "Whiskies");

            migrationBuilder.AddColumn<bool>(
                name: "SoftDeleted",
                table: "Storages",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoftDeleted",
                table: "Storages");

            migrationBuilder.AddColumn<bool>(
                name: "SoftDeleted",
                table: "Whiskies",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
