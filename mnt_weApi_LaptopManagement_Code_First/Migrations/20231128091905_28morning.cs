using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mnt_weApi_LaptopManagement_Code_First.Migrations
{
    /// <inheritdoc />
    public partial class _28morning : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    empId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isLaptopAssigned = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.empId);
                });

            migrationBuilder.CreateTable(
                name: "laptops",
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
                    storage = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_laptops", x => x.laptopId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeLaptopMappings",
                columns: table => new
                {
                    mappingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    laptopId = table.Column<int>(type: "int", nullable: false),
                    empId = table.Column<int>(type: "int", nullable: false),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeLaptopMappings", x => x.mappingId);
                    table.ForeignKey(
                        name: "FK_EmployeeLaptopMappings_employees_empId",
                        column: x => x.empId,
                        principalTable: "employees",
                        principalColumn: "empId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeLaptopMappings_laptops_laptopId",
                        column: x => x.laptopId,
                        principalTable: "laptops",
                        principalColumn: "laptopId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLaptopMappings_empId",
                table: "EmployeeLaptopMappings",
                column: "empId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLaptopMappings_laptopId",
                table: "EmployeeLaptopMappings",
                column: "laptopId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeLaptopMappings");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "laptops");
        }
    }
}
