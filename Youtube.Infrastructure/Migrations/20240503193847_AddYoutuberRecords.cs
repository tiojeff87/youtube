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
                    Youtuber_Trophy = table.Column<int>(type: "int", nullable: false),
                    YoutuberId = table.Column<int>(type: "int", nullable: false),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YoutuberRecords", x => x.Youtuber_Trophy);
                    table.ForeignKey(
                        name: "FK_YoutuberRecords_Youtubers_YoutuberId",
                        column: x => x.YoutuberId,
                        principalTable: "Youtubers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "YoutuberRecords",
                columns: new[] { "Youtuber_Trophy", "SpecialDetails", "YoutuberId" },
                values: new object[,]
                {
                    { 100001, "Some special details for this record", 1 },
                    { 100002, "Some special details for this record", 2 },
                    { 100003, "Some special details for this record", 3 },
                    { 1000003, "Some special details for this record", 3 },
                    { 1000001, "Some special details for this record", 1 },
                    { 10000003, "Some special details for this record", 3 },
                    { 50000003, "Some special details for this record", 3 }
                });

            migrationBuilder.UpdateData(
                table: "Youtubers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Joined",
                value: new DateTime(2024, 5, 3, 17, 29, 57, 50, DateTimeKind.Local).AddTicks(5784));

            migrationBuilder.UpdateData(
                table: "Youtubers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Joined",
                value: new DateTime(2024, 5, 3, 17, 29, 57, 50, DateTimeKind.Local).AddTicks(5842));

            migrationBuilder.UpdateData(
                table: "Youtubers",
                keyColumn: "Id",
                keyValue: 3,
                column: "Joined",
                value: new DateTime(2024, 5, 3, 17, 29, 57, 50, DateTimeKind.Local).AddTicks(5845));

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
