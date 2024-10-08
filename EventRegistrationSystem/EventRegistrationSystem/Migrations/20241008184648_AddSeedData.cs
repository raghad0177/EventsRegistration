using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventRegistrationSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Event",
                columns: new[] { "EventId", "Capacity", "Date", "Description", "Title" },
                values: new object[,]
                {
                    { 1, 100, new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Annual technology conference focusing on software development.", "Tech Conference 2024" },
                    { 2, 50, new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "A hands-on workshop to explore AI and machine learning.", "AI Workshop" },
                    { 3, 75, new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "A summit discussing the latest trends in cybersecurity.", "Cybersecurity Summit" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: 3);
        }
    }
}
