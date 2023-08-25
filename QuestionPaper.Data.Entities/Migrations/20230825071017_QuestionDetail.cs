using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuestionPaper.Data.Entities.Migrations
{
    /// <inheritdoc />
    public partial class QuestionDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "questionDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    questionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questionDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "subQuestions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subQuestionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numberOfQuestion = table.Column<int>(type: "int", nullable: true),
                    timeLimit = table.Column<int>(type: "int", nullable: true),
                    questionDetails_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subQuestions", x => x.id);
                    table.ForeignKey(
                        name: "FK_subQuestions_questionDetails_questionDetails_id",
                        column: x => x.questionDetails_id,
                        principalTable: "questionDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_subQuestions_questionDetails_id",
                table: "subQuestions",
                column: "questionDetails_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "subQuestions");

            migrationBuilder.DropTable(
                name: "questionDetails");
        }
    }
}
