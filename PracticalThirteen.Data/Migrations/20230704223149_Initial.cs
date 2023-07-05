using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PracticalThirteen.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    JoiningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Age", "JoiningDate", "Name" },
                values: new object[,]
                {
                    { 1, 20, new DateTime(2002, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bhavin" },
                    { 2, 23, new DateTime(1999, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vipul" },
                    { 3, 22, new DateTime(2000, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jil" },
                    { 4, 22, new DateTime(2000, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Abhi" },
                    { 5, 22, new DateTime(2000, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jay" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
