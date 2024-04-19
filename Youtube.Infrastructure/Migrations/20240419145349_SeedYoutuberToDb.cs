using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Youtube.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedYoutuberToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {        
            migrationBuilder.UpdateData(
                table: "Youtubers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Joined",
                value: new DateTime(2012, 1, 11, 00, 00, 00, 000, DateTimeKind.Local).AddTicks(8347));

            migrationBuilder.UpdateData(
                table: "Youtubers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Joined",
                value: new DateTime(2014, 7, 25, 00, 00, 00, 000, DateTimeKind.Local).AddTicks(8406));

            migrationBuilder.UpdateData(
                table: "Youtubers",
                keyColumn: "Id",
                keyValue: 3,
                column: "Joined",
                value: new DateTime(2010, 4, 29, 00, 00, 00, 000, DateTimeKind.Local).AddTicks(8409));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
