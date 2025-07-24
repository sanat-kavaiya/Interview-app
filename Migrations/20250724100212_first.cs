using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myApp.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _= migrationBuilder.CreateTable(
                name: "CompanyDetail",
                columns: table => new
                {
                    Company_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Company_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company_Adresss = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyDetail", x => x.Company_id);
                });

           _=  migrationBuilder.CreateTable(
                name: "EmployeDetail",
                columns: table => new
                {
                    EmpId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeDetail", x => x.EmpId);
                });

            _= migrationBuilder.CreateTable(
                name: "StudentDetail",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Company_id = table.Column<int>(type: "int", nullable: false),
                    EmpId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentDetail", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_StudentDetail_CompanyDetail_Company_id",
                        column: x => x.Company_id,
                        principalTable: "CompanyDetail",
                        principalColumn: "Company_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentDetail_EmployeDetail_EmpId",
                        column: x => x.EmpId,
                        principalTable: "EmployeDetail",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Cascade);
                });

            _= migrationBuilder.CreateIndex(
                name: "IX_StudentDetail_Company_id",
                table: "StudentDetail",
                column: "Company_id");

            _= migrationBuilder.CreateIndex(
                name: "IX_StudentDetail_EmpId",
                table: "StudentDetail",
                column: "EmpId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _= migrationBuilder.DropTable(
                name: "StudentDetail");

            _= migrationBuilder.DropTable(
                name: "CompanyDetail");

            _= migrationBuilder.DropTable(
                name: "EmployeDetail");
        }
    }
}
