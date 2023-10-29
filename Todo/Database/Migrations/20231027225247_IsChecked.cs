using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDo.Database.Migrations
{
    /// <inheritdoc />
    public partial class IsChecked : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Checked",
                table: "Todos",
                newName: "IsChecked");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsChecked",
                table: "Todos",
                newName: "Checked");
        }
    }
}
