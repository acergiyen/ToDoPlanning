using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ToDoPlanning.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDeveloperNavigation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeveloperId",
                table: "TaskItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Developer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developer", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_DeveloperId",
                table: "TaskItems",
                column: "DeveloperId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_Developer_DeveloperId",
                table: "TaskItems",
                column: "DeveloperId",
                principalTable: "Developer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_Developer_DeveloperId",
                table: "TaskItems");

            migrationBuilder.DropTable(
                name: "Developer");

            migrationBuilder.DropIndex(
                name: "IX_TaskItems_DeveloperId",
                table: "TaskItems");

            migrationBuilder.DropColumn(
                name: "DeveloperId",
                table: "TaskItems");
        }
    }
}
