using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoApp.Migrations
{
    public partial class InitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToDos",
                columns: table => new
                {
                    ToDoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Note = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    IsDone = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDos", x => x.ToDoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDos");
        }
    }
}
