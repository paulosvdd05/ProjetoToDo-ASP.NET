using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "tasks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tasks_UsuarioId",
                table: "tasks",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_usuario_UsuarioId",
                table: "tasks",
                column: "UsuarioId",
                principalTable: "usuario",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tasks_usuario_UsuarioId",
                table: "tasks");

            migrationBuilder.DropIndex(
                name: "IX_tasks_UsuarioId",
                table: "tasks");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "tasks");
        }
    }
}
