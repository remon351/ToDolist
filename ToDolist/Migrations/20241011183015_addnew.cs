using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDolist.Migrations
{
    /// <inheritdoc />
    public partial class addnew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lists_students_studentId",
                table: "lists");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropIndex(
                name: "IX_lists_studentId",
                table: "lists");

            migrationBuilder.DropColumn(
                name: "studentId",
                table: "lists");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "lists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "lists");

            migrationBuilder.AddColumn<int>(
                name: "studentId",
                table: "lists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.Id);
                });

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
    }
}
