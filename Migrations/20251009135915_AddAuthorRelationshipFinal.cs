using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ciordas_Maya_Lab2.Migrations
{
    /// <inheritdoc />
    public partial class AddAuthorRelationshipFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Author",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Author",
                newName: "ID");
        }
    }
}
