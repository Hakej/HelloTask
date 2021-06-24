using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace HelloTask.Migrations
{
    public partial class ChangeNameOfTaskToAssignment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(name: "Tasks", schema: "dbo", newName: "Assignments", newSchema: "dbo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(name: "Assignments", schema: "dbo", newName: "Tasks", newSchema: "dbo");
        }
    }
}
