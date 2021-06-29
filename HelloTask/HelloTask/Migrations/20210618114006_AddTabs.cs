using Microsoft.EntityFrameworkCore.Migrations;

namespace HelloTask.Migrations
{
    public partial class AddTabs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TabId",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Tabs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tabs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TabId",
                table: "Tasks",
                column: "TabId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Tabs_TabId",
                table: "Tasks",
                column: "TabId",
                principalTable: "Tabs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Tabs_TabId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "Tabs");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_TabId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "TabId",
                table: "Tasks");
        }
    }
}
