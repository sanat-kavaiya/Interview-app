using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myApp.Migrations
{
    /// <inheritdoc />
    public partial class secondbuild : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _= migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "StudentDetail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            _= migrationBuilder.AddColumn<string>(
                name: "StudentName",
                table: "StudentDetail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _= migrationBuilder.DropColumn(
                name: "Password",
                table: "StudentDetail");

            _= migrationBuilder.DropColumn(
                name: "StudentName",
                table: "StudentDetail");
        }
    }
}
