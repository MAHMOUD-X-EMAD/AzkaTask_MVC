using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class LastVVV : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Vacation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VacationId",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vacation_EmployeeId",
                table: "Vacation",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_VacationId",
                table: "Employee",
                column: "VacationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Vacation_VacationId",
                table: "Employee",
                column: "VacationId",
                principalTable: "Vacation",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacation_Employee_EmployeeId",
                table: "Vacation",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Vacation_VacationId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacation_Employee_EmployeeId",
                table: "Vacation");

            migrationBuilder.DropIndex(
                name: "IX_Vacation_EmployeeId",
                table: "Vacation");

            migrationBuilder.DropIndex(
                name: "IX_Employee_VacationId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Vacation");

            migrationBuilder.DropColumn(
                name: "VacationId",
                table: "Employee");
        }
    }
}
