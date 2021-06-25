using Microsoft.EntityFrameworkCore.Migrations;

namespace HelloTask.Migrations
{
    public partial class AddBoards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BoardId",
                table: "Tabs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tabs_BoardId",
                table: "Tabs",
                column: "BoardId");
            
            migrationBuilder.AddForeignKey(
                name: "FK_Tabs_Boards_BoardId",
                table: "Tabs",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tabs_Boards_BoardId",
                table: "Tabs");

            migrationBuilder.DropTable(
                name: "Boards");

            migrationBuilder.DropIndex(
                name: "IX_Tabs_BoardId",
                table: "Tabs");

            migrationBuilder.DropColumn(
                name: "BoardId",
                table: "Tabs");
        }
    }
}
