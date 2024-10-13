using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDolist.Migrations
{
    /// <inheritdoc />
    public partial class add : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "student_Lists");

            migrationBuilder.AddColumn<int>(
                name: "studentId",
                table: "lists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_lists_studentId",
                table: "lists",
                column: "studentId");

            migrationBuilder.AddForeignKey(
                name: "FK_lists_students_studentId",
                table: "lists",
                column: "studentId",
                principalTable: "students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lists_students_studentId",
                table: "lists");

            migrationBuilder.DropIndex(
                name: "IX_lists_studentId",
                table: "lists");

            migrationBuilder.DropColumn(
                name: "studentId",
                table: "lists");

            migrationBuilder.CreateTable(
                name: "student_Lists",
                columns: table => new
                {
                    studentId = table.Column<int>(type: "int", nullable: false),
                    listId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student_Lists", x => new { x.studentId, x.listId });
                    table.ForeignKey(
                        name: "FK_student_Lists_lists_listId",
                        column: x => x.listId,
                        principalTable: "lists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_student_Lists_students_studentId",
                        column: x => x.studentId,
                        principalTable: "students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_student_Lists_listId",
                table: "student_Lists",
                column: "listId");
        }
    }
}
