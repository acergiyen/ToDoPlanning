using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoPlanning.Data.Migrations
{
    /// <inheritdoc />
    public partial class developer2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Dev3");

            migrationBuilder.UpdateData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Dev4");

            migrationBuilder.UpdateData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Dev5");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Dev2");

            migrationBuilder.UpdateData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Dev2");

            migrationBuilder.UpdateData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Dev2");
        }
    }
}
