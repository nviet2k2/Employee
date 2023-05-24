using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee.DataAccess.Migrations
{
    public partial class inittal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateJoined = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalInsuranceNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    StudentLoan = table.Column<int>(type: "int", nullable: false),
                    UnionMember = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Postcode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TaxYear",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YearOfTax = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxYear", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    EmployeesID = table.Column<int>(type: "int", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NiNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxYearId = table.Column<int>(type: "int", nullable: false),
                    HourlyRate = table.Column<decimal>(type: "money", nullable: false),
                    HourWorked = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ContractualEarnings = table.Column<decimal>(type: "money", nullable: false),
                    OvertimeEarnings = table.Column<decimal>(type: "money", nullable: false),
                    Tax = table.Column<decimal>(type: "money", nullable: false),
                    NIC = table.Column<decimal>(type: "money", nullable: false),
                    UnionFees = table.Column<decimal>(type: "money", nullable: true),
                    SLC = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalEarnings = table.Column<decimal>(type: "money", nullable: false),
                    TotalDeduction = table.Column<decimal>(type: "money", nullable: false),
                    Netpayment = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentRecord_Employee_EmployeesID",
                        column: x => x.EmployeesID,
                        principalTable: "Employee",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PaymentRecord_TaxYear_TaxYearId",
                        column: x => x.TaxYearId,
                        principalTable: "TaxYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentRecord_EmployeesID",
                table: "PaymentRecord",
                column: "EmployeesID");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentRecord_TaxYearId",
                table: "PaymentRecord",
                column: "TaxYearId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentRecord");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "TaxYear");
        }
    }
}
