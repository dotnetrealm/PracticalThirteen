using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PracticalThirteen.Data.Migrations.OrganizationDB
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Designations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Designations = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    JoiningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: true),
                    DesignationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Designations_DesignationId",
                        column: x => x.DesignationId,
                        principalTable: "Designations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeesWithSalary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DOB = table.Column<DateTime>(type: "Date", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DesignationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesWithSalary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeesWithSalary_Designations_DesignationId",
                        column: x => x.DesignationId,
                        principalTable: "Designations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Designations",
                columns: new[] { "Id", "Designations" },
                values: new object[,]
                {
                    { 1, "Team Manager" },
                    { 2, "Lead Engineer" },
                    { 3, "Senior Developer" },
                    { 4, "Junior Developer" },
                    { 5, "Trainee Engineer" }
                });

            migrationBuilder.InsertData(
                table: "EmployeesWithSalary",
                columns: new[] { "Id", "Address", "DOB", "DesignationId", "FirstName", "LastName", "MiddleName", "MobileNumber", "Salary" },
                values: new object[,]
                {
                    { 1, "Rajkot", new DateTime(2002, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bhavin", "Kareliya", null, "1231231231", 999999m },
                    { 2, "Anand", new DateTime(2001, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Jil", "Patel", null, "9898989898", 999999m },
                    { 3, "Ahemedabad", new DateTime(1999, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Vipul", "Kumar", null, "1231231231", 999999m },
                    { 4, "Morbi", new DateTime(2002, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Abhi", "Dasadiya", null, "9898989898", 999999m },
                    { 5, "Rajkot", new DateTime(2001, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Jay", "Gohel", null, "1231231231", 999999m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DesignationId",
                table: "Employee",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesWithSalary_DesignationId",
                table: "EmployeesWithSalary",
                column: "DesignationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "EmployeesWithSalary");

            migrationBuilder.DropTable(
                name: "Designations");
        }
    }
}
