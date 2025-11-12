using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PRN232_PE_FA25_NguyenKhanhTin.Migrations
{
    /// <inheritdoc />
    public partial class InitPosts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CreatedAt", "Description", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 11, 12, 17, 7, 18, 609, DateTimeKind.Utc).AddTicks(3604), "Minimal API + HTML", null, "Hello PRN232" },
                    { 2, new DateTime(2025, 11, 12, 17, 7, 18, 609, DateTimeKind.Utc).AddTicks(3605), "Connected to Supabase/Postgres", "https://picsum.photos/seed/p1/400/240", "Deploy Render" },
                    { 3, new DateTime(2025, 11, 12, 17, 7, 18, 609, DateTimeKind.Utc).AddTicks(3606), "A→Z / Z→A + search by name", "https://picsum.photos/seed/p2/400/240", "Search & Sort" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
