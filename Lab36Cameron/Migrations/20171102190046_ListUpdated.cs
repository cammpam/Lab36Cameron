using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Lab36Cameron.Migrations
{
    public partial class ListUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SongItem_Contributors_ContributorsId1",
                table: "SongItem");

            migrationBuilder.DropIndex(
                name: "IX_SongItem_ContributorsId1",
                table: "SongItem");

            migrationBuilder.DropColumn(
                name: "ContributorsId1",
                table: "SongItem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContributorsId1",
                table: "SongItem",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SongItem_ContributorsId1",
                table: "SongItem",
                column: "ContributorsId1");

            migrationBuilder.AddForeignKey(
                name: "FK_SongItem_Contributors_ContributorsId1",
                table: "SongItem",
                column: "ContributorsId1",
                principalTable: "Contributors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
