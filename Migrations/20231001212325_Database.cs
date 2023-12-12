using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class Database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cohort",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Periods = table.Column<int>(type: "INTEGER", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Modality = table.Column<int>(type: "INTEGER", nullable: false),
                    HasAgreement = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cohort", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Leader",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leader", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Program",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Modality = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Program", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Document = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expense",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Total = table.Column<double>(type: "REAL", nullable: false),
                    CohortModelId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expense", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expense_Cohort_CohortModelId",
                        column: x => x.CohortModelId,
                        principalTable: "Cohort",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    LeaderId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProgramModelId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teacher_Leader_LeaderId",
                        column: x => x.LeaderId,
                        principalTable: "Leader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teacher_Program_ProgramModelId",
                        column: x => x.ProgramModelId,
                        principalTable: "Program",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Percentage = table.Column<decimal>(type: "TEXT", nullable: false),
                    Cost = table.Column<decimal>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    StudentModelId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discount_Student_StudentModelId",
                        column: x => x.StudentModelId,
                        principalTable: "Student",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RegistrationModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    CohortModelId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistrationModel_Cohort_CohortModelId",
                        column: x => x.CohortModelId,
                        principalTable: "Cohort",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RegistrationModel_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FixedExpense",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Criterion = table.Column<string>(type: "TEXT", nullable: false),
                    UnitValue = table.Column<decimal>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    TypeCost = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FixedExpense", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FixedExpense_Expense_Id",
                        column: x => x.Id,
                        principalTable: "Expense",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecurrentCost",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UnitName = table.Column<string>(type: "TEXT", nullable: false),
                    HourlyRate = table.Column<decimal>(type: "TEXT", nullable: false),
                    NumberHours = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecurrentCost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecurrentCost_Expense_Id",
                        column: x => x.Id,
                        principalTable: "Expense",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceExpense",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ServiceName = table.Column<string>(type: "TEXT", nullable: false),
                    ServiceType = table.Column<string>(type: "TEXT", nullable: false),
                    ServiceCost = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceExpense", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceExpense_Expense_Id",
                        column: x => x.Id,
                        principalTable: "Expense",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecialExpense",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TypeService = table.Column<string>(type: "TEXT", nullable: false),
                    DescriptionService = table.Column<string>(type: "TEXT", nullable: false),
                    PercentageService = table.Column<decimal>(type: "TEXT", nullable: false),
                    CostService = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialExpense", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecialExpense_Expense_Id",
                        column: x => x.Id,
                        principalTable: "Expense",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TravelExpense",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Destination = table.Column<string>(type: "TEXT", nullable: false),
                    NumberPeople = table.Column<int>(type: "INTEGER", nullable: false),
                    TransportCost = table.Column<decimal>(type: "TEXT", nullable: false),
                    TravelCost = table.Column<decimal>(type: "TEXT", nullable: false),
                    NumberTravel = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelExpense", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TravelExpense_Expense_Id",
                        column: x => x.Id,
                        principalTable: "Expense",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubjectModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Modality = table.Column<int>(type: "INTEGER", nullable: false),
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false),
                    RegistrationModelId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectModel_RegistrationModel_RegistrationModelId",
                        column: x => x.RegistrationModelId,
                        principalTable: "RegistrationModel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SubjectModel_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeneralExpense",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralExpense", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneralExpense_FixedExpense_Id",
                        column: x => x.Id,
                        principalTable: "FixedExpense",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OtherExpense",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherExpense", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtherExpense_FixedExpense_Id",
                        column: x => x.Id,
                        principalTable: "FixedExpense",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OtherServiceNonTeachingStaff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UnitCostService = table.Column<decimal>(type: "TEXT", nullable: false),
                    QuantityService = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherServiceNonTeachingStaff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtherServiceNonTeachingStaff_ServiceExpense_Id",
                        column: x => x.Id,
                        principalTable: "ServiceExpense",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OtherServiceTeachingStaff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DescriptionService = table.Column<string>(type: "TEXT", nullable: false),
                    TeacherName = table.Column<string>(type: "TEXT", nullable: false),
                    NumberHoursService = table.Column<int>(type: "INTEGER", nullable: false),
                    CostHourlyService = table.Column<decimal>(type: "TEXT", nullable: false),
                    TypeCostService = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherServiceTeachingStaff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtherServiceTeachingStaff_ServiceExpense_Id",
                        column: x => x.Id,
                        principalTable: "ServiceExpense",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvestmentExpense",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestmentExpense", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvestmentExpense_SpecialExpense_Id",
                        column: x => x.Id,
                        principalTable: "SpecialExpense",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransferExpense",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferExpense", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransferExpense_SpecialExpense_Id",
                        column: x => x.Id,
                        principalTable: "SpecialExpense",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Discount_StudentModelId",
                table: "Discount",
                column: "StudentModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_CohortModelId",
                table: "Expense",
                column: "CohortModelId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationModel_CohortModelId",
                table: "RegistrationModel",
                column: "CohortModelId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationModel_StudentId",
                table: "RegistrationModel",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectModel_RegistrationModelId",
                table: "SubjectModel",
                column: "RegistrationModelId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectModel_TeacherId",
                table: "SubjectModel",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_LeaderId",
                table: "Teacher",
                column: "LeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_ProgramModelId",
                table: "Teacher",
                column: "ProgramModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.DropTable(
                name: "GeneralExpense");

            migrationBuilder.DropTable(
                name: "InvestmentExpense");

            migrationBuilder.DropTable(
                name: "OtherExpense");

            migrationBuilder.DropTable(
                name: "OtherServiceNonTeachingStaff");

            migrationBuilder.DropTable(
                name: "OtherServiceTeachingStaff");

            migrationBuilder.DropTable(
                name: "RecurrentCost");

            migrationBuilder.DropTable(
                name: "SubjectModel");

            migrationBuilder.DropTable(
                name: "TransferExpense");

            migrationBuilder.DropTable(
                name: "TravelExpense");

            migrationBuilder.DropTable(
                name: "FixedExpense");

            migrationBuilder.DropTable(
                name: "ServiceExpense");

            migrationBuilder.DropTable(
                name: "RegistrationModel");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "SpecialExpense");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Leader");

            migrationBuilder.DropTable(
                name: "Program");

            migrationBuilder.DropTable(
                name: "Expense");

            migrationBuilder.DropTable(
                name: "Cohort");
        }
    }
}
