using Microsoft.EntityFrameworkCore.Migrations;

namespace timesheet.data.Migrations
{
    public partial class DBset_timesheet_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeSheet_Employees_EmployeeId",
                table: "TimeSheet");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeSheet_Tasks_TaskId",
                table: "TimeSheet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeSheet",
                table: "TimeSheet");

            migrationBuilder.RenameTable(
                name: "TimeSheet",
                newName: "TimeSheets");

            migrationBuilder.RenameIndex(
                name: "IX_TimeSheet_TaskId",
                table: "TimeSheets",
                newName: "IX_TimeSheets_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_TimeSheet_EmployeeId",
                table: "TimeSheets",
                newName: "IX_TimeSheets_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeSheets",
                table: "TimeSheets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSheets_Employees_EmployeeId",
                table: "TimeSheets",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSheets_Tasks_TaskId",
                table: "TimeSheets",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeSheets_Employees_EmployeeId",
                table: "TimeSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeSheets_Tasks_TaskId",
                table: "TimeSheets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeSheets",
                table: "TimeSheets");

            migrationBuilder.RenameTable(
                name: "TimeSheets",
                newName: "TimeSheet");

            migrationBuilder.RenameIndex(
                name: "IX_TimeSheets_TaskId",
                table: "TimeSheet",
                newName: "IX_TimeSheet_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_TimeSheets_EmployeeId",
                table: "TimeSheet",
                newName: "IX_TimeSheet_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeSheet",
                table: "TimeSheet",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSheet_Employees_EmployeeId",
                table: "TimeSheet",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSheet_Tasks_TaskId",
                table: "TimeSheet",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
