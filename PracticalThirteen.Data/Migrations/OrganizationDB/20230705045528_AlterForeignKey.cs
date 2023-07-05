using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticalThirteen.Data.Migrations.OrganizationDB
{
    /// <inheritdoc />
    public partial class AlterForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "EmployeesWithSalary",
                keyColumn: "Id",
                keyValue: 1,
                column: "DOB",
                value: new DateTime(2002, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "EmployeesWithSalary",
                keyColumn: "Id",
                keyValue: 2,
                column: "DOB",
                value: new DateTime(2001, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "EmployeesWithSalary",
                keyColumn: "Id",
                keyValue: 4,
                column: "DOB",
                value: new DateTime(2002, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "EmployeesWithSalary",
                keyColumn: "Id",
                keyValue: 1,
                column: "DOB",
                value: new DateTime(2002, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "EmployeesWithSalary",
                keyColumn: "Id",
                keyValue: 2,
                column: "DOB",
                value: new DateTime(2001, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "EmployeesWithSalary",
                keyColumn: "Id",
                keyValue: 4,
                column: "DOB",
                value: new DateTime(2002, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
