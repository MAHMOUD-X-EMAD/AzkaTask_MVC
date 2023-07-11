using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class LastVVVV : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Vacation_VacationId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_VacationId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "VacationId",
                table: "Employee");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VacationId",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
