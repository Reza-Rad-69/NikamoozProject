using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace taskSession2.InfraStructures.Data.EF.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StatusDescription",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusDescription", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "StatusTask",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    statusDescriptionId = table.Column<int>(type: "int", nullable: false),
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    statusDate = table.Column<int>(type: "int", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusTask", x => x.id);
                    table.ForeignKey(
                        name: "FK_StatusTask_StatusDescription_statusDescriptionId",
                        column: x => x.statusDescriptionId,
                        principalTable: "StatusDescription",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StatusTask_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StatusTask_statusDescriptionId",
                table: "StatusTask",
                column: "statusDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusTask_TaskId",
                table: "StatusTask",
                column: "TaskId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StatusTask");

            migrationBuilder.DropTable(
                name: "StatusDescription");

            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
