using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Taskato.Migrations
{
    public partial class SeedDataForPriorityAndTasksTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Priorities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Priority 1" },
                    { 2, "Priority 2" },
                    { 3, "Priority 3" },
                    { 4, "Priority 4" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedDate", "Description", "IsCompleted", "Name", "PriorityId", "TaskDate" },
                values: new object[] { 2, new DateTime(2021, 5, 10, 10, 50, 39, 329, DateTimeKind.Local).AddTicks(9213), null, false, "Work", 3, new DateTime(2021, 5, 10, 10, 50, 39, 329, DateTimeKind.Local).AddTicks(9227) });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedDate", "Description", "IsCompleted", "Name", "PriorityId", "TaskDate" },
                values: new object[] { 1, new DateTime(2021, 5, 10, 10, 50, 39, 325, DateTimeKind.Local).AddTicks(9905), null, false, "Learning", 4, new DateTime(2021, 5, 10, 10, 50, 39, 329, DateTimeKind.Local).AddTicks(8383) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Priorities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Priorities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Priorities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Priorities",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
