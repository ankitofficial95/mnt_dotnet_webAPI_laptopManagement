using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mnt_weApi_LaptopManagement_Code_First.Migrations
{
    /// <inheritdoc />
    public partial class two : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    empId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isLaptopAssigned = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.empId);
                });

            migrationBuilder.CreateTable(
                name: "Laptops",
                columns: table => new
                {
                    laptopId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    serialNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modelNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    operatingSystem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ram = table.Column<int>(type: "int", nullable: false),
                    battery = table.Column<bool>(type: "bit", nullable: false),
                    mic = table.Column<bool>(type: "bit", nullable: false),
                    keyBoard = table.Column<bool>(type: "bit", nullable: false),
                    mouse = table.Column<bool>(type: "bit", nullable: false),
                    speaker = table.Column<bool>(type: "bit", nullable: false),
                    charger = table.Column<bool>(type: "bit", nullable: false),
                    isAssigned = table.Column<bool>(type: "bit", nullable: false),
                    storage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laptops", x => x.laptopId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeLaptopMappings",
                columns: table => new
                {
                    empId = table.Column<int>(type: "int", nullable: false),
                    laptopId = table.Column<int>(type: "int", nullable: false),
                    isReturned = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeLaptopMappings", x => new { x.empId, x.laptopId });
                    table.ForeignKey(
                        name: "FK_EmployeeLaptopMappings_Employees_empId",
                        column: x => x.empId,
                        principalTable: "Employees",
                        principalColumn: "empId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeLaptopMappings_Laptops_laptopId",
                        column: x => x.laptopId,
                        principalTable: "Laptops",
                        principalColumn: "laptopId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLaptopMappings_empId",
                table: "EmployeeLaptopMappings",
                column: "empId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLaptopMappings_laptopId",
                table: "EmployeeLaptopMappings",
                column: "laptopId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeLaptopMappings");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Laptops");
        }
    }
}
