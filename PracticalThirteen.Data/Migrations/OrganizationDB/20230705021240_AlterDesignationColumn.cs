using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticalThirteen.Data.Migrations.OrganizationDB
{
    /// <inheritdoc />
    public partial class AlterDesignationColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Designations",
                table: "Designations",
                newName: "DesignationName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DesignationName",
                table: "Designations",
                newName: "Designations");
        }
    }
}
