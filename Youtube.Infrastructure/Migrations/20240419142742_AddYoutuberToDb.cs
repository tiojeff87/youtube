using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Youtube.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddYoutuberToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Youtubers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subscribers = table.Column<int>(type: "int", nullable: false),
                    videos = table.Column<int>(type: "int", nullable: false),
                    views = table.Column<int>(type: "int", nullable: false),
                    Joined = table.Column<DateTime>(type: "datetime2", nullable: false),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Youtubers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Youtubers",
                columns: new[] { "Id", "CreatedDate", "Joined", "Name", "Subscribers", "UpdatedDate", "country", "videos", "views" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2012, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wuant", 3690000, null, "Portugal", 1596, 1342325614 },
                    { 2, null, new DateTime(2014, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Toshiruz", 616000, null, "Brazil", 1482, 124672906 },
                    { 3, null, new DateTime(2010, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wuant", 111000000, null, "Sweden", 4760, 292766664 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Youtubers");
        }
    }
}
