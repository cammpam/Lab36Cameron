using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Lab36Cameron.Migrations
{
    public partial class listAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContributorsId",
                table: "SongItem",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContributorsId1",
                table: "SongItem",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FeatId",
                table: "SongItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Contributors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contributors", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SongItem_ContributorsId",
                table: "SongItem",
                column: "ContributorsId");

            migrationBuilder.CreateIndex(
                name: "IX_SongItem_ContributorsId1",
                table: "SongItem",
                column: "ContributorsId1");

            migrationBuilder.AddForeignKey(
                name: "FK_SongItem_Contributors_ContributorsId",
                table: "SongItem",
                column: "ContributorsId",
                principalTable: "Contributors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SongItem_Contributors_ContributorsId1",
                table: "SongItem",
                column: "ContributorsId1",
                principalTable: "Contributors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SongItem_Contributors_ContributorsId",
                table: "SongItem");

            migrationBuilder.DropForeignKey(
                name: "FK_SongItem_Contributors_ContributorsId1",
                table: "SongItem");

            migrationBuilder.DropTable(
                name: "Contributors");

            migrationBuilder.DropIndex(
                name: "IX_SongItem_ContributorsId",
                table: "SongItem");

            migrationBuilder.DropIndex(
                name: "IX_SongItem_ContributorsId1",
                table: "SongItem");

            migrationBuilder.DropColumn(
                name: "ContributorsId",
                table: "SongItem");

            migrationBuilder.DropColumn(
                name: "ContributorsId1",
                table: "SongItem");

            migrationBuilder.DropColumn(
                name: "FeatId",
                table: "SongItem");
        }
    }
}
