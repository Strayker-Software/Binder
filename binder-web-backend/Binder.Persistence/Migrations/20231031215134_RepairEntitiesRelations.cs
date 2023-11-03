using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Binder.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RepairEntitiesRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoTasks_Tables_DefaultTableId",
                table: "ToDoTasks");

            migrationBuilder.DropIndex(
                name: "IX_ToDoTasks_DefaultTableId",
                table: "ToDoTasks");

            migrationBuilder.DropColumn(
                name: "DefaultTableId",
                table: "ToDoTasks");

            migrationBuilder.AddColumn<int>(
                name: "TableId",
                table: "ToDoTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ToDoTasks_TableId",
                table: "ToDoTasks",
                column: "TableId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoTasks_Tables_TableId",
                table: "ToDoTasks",
                column: "TableId",
                principalTable: "Tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoTasks_Tables_TableId",
                table: "ToDoTasks");

            migrationBuilder.DropIndex(
                name: "IX_ToDoTasks_TableId",
                table: "ToDoTasks");

            migrationBuilder.DropColumn(
                name: "TableId",
                table: "ToDoTasks");

            migrationBuilder.AddColumn<int>(
                name: "DefaultTableId",
                table: "ToDoTasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ToDoTasks_DefaultTableId",
                table: "ToDoTasks",
                column: "DefaultTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoTasks_Tables_DefaultTableId",
                table: "ToDoTasks",
                column: "DefaultTableId",
                principalTable: "Tables",
                principalColumn: "Id");
        }
    }
}
