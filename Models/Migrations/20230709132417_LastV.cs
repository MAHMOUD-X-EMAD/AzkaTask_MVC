using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class LastV : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Vacation_VacationId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Vacation_EmployeeId",
                table: "Vacation");

            migrationBuilder.DropIndex(
                name: "IX_Employee_VacationId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "VacationId",
                table: "Employee");

            migrationBuilder.CreateIndex(
                name: "IX_Vacation_EmployeeId",
                table: "Vacation",
                column: "EmployeeId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Vacation_EmployeeId",
                table: "Vacation");

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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
