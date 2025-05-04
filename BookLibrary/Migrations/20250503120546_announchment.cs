using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BookLibrary.Migrations
{
    /// <inheritdoc />
    public partial class announchment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Books_BookId1",
                table: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_BookId1",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "BookId1",
                table: "CartItems");

            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Message = table.Column<string>(type: "text", nullable: false),
                    StartTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.AddColumn<Guid>(
                name: "BookId1",
                table: "CartItems",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_BookId1",
                table: "CartItems",
                column: "BookId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Books_BookId1",
                table: "CartItems",
                column: "BookId1",
                principalTable: "Books",
                principalColumn: "BookId");
        }
    }
}
