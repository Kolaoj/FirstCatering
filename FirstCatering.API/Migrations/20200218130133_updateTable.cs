using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstCatering.API.Migrations
{
    public partial class updateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MobileNumber",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: "PaulF123",
                column: "Balance",
                value: -1.00m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MobileNumber",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: "PaulF123",
                column: "Balance",
                value: 8.00m);
        }
    }
}
