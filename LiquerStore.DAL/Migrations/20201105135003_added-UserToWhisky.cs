using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LiquerStore.DAL.Migrations
{
    public partial class addedUserToWhisky : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "Whiskies");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Age",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "UserToWhiskies",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    WhiskyId = table.Column<int>(nullable: false),
                    Reserved = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToWhiskies", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserToWhiskies");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Whiskies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Age",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
