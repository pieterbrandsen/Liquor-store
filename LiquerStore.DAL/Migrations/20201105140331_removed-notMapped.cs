﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace LiquerStore.DAL.Migrations
{
    public partial class removednotMapped : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Whiskies",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "Whiskies");
        }
    }
}