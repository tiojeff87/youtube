using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Youtube.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddYoutuberRecords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "country",
                table: "Youtubers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "YoutuberRecords",
                columns: table => new
                {
                    Votos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YoutuberId = table.Column<int>(type: "int", nullable: false),
                    Youtuber_Trophy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YoutuberRecords", x => x.Votos);
                    table.ForeignKey(
                        name: "FK_YoutuberRecords_Youtubers_YoutuberId",
                        column: x => x.YoutuberId,
                        principalTable: "Youtubers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "YoutuberRecords",
                columns: new[] { "Votos", "YoutuberId", "Youtuber_Trophy" },
                values: new object[,]
                {
                    { 100001, 1, "silver" },
                    { 100002, 2, "silver" },
                    { 100003, 3, "silver" },
                    { 1000001, 1, "gold" },
                    { 10000003, 3, "gold" },
                    { 50000003, 3, "ruby" },
                    { 100000003, 3, "diamond" }
                });

            migrationBuilder.UpdateData(
                table: "Youtubers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Joined",
                value: new DateTime(2012, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Youtubers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Joined",
                value: new DateTime(2014, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Youtubers",
                keyColumn: "Id",
                keyValue: 3,
                column: "Joined",
                value: new DateTime(2010, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_YoutuberRecords_YoutuberId",
                table: "YoutuberRecords",
                column: "YoutuberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "YoutuberRecords");

            migrationBuilder.AlterColumn<string>(
                name: "country",
                table: "Youtubers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Youtubers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Joined",
                value: new DateTime(2024, 4, 19, 15, 53, 49, 399, DateTimeKind.Local).AddTicks(8347));

            migrationBuilder.UpdateData(
                table: "Youtubers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Joined",
                value: new DateTime(2024, 4, 19, 15, 53, 49, 399, DateTimeKind.Local).AddTicks(8406));

            migrationBuilder.UpdateData(
                table: "Youtubers",
                keyColumn: "Id",
                keyValue: 3,
                column: "Joined",
                value: new DateTime(2024, 4, 19, 15, 53, 49, 399, DateTimeKind.Local).AddTicks(8409));
        }
    }
}
