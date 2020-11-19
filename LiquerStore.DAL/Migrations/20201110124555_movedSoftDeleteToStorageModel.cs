using Microsoft.EntityFrameworkCore.Migrations;

namespace LiquerStore.DAL.Migrations
{
    public partial class movedSoftDeleteToStorageModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "SoftDeleted",
                "Whiskies");

            migrationBuilder.AddColumn<bool>(
                "SoftDeleted",
                "Storages",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "SoftDeleted",
                "Storages");

            migrationBuilder.AddColumn<bool>(
                "SoftDeleted",
                "Whiskies",
                "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}