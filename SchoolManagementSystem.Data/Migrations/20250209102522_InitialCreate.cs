using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PreviousSchoolDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PreviousSchoolName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreviousSchoolLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreviousSchoolUniversity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreviousSchoolType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreviousSchoolSymbolNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreviousSchoolRegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreviousSchoolPassedYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreviousSchoolPercentage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreviousSchoolDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentUniqueId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentName_Nep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DOB_AD = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DOB_BS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BloodGroup = table.Column<int>(type: "int", nullable: true),
                    StudentImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    AdmittedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdmittedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateddBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "StudentAcademicInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Class = table.Column<int>(type: "int", nullable: false),
                    Section = table.Column<int>(type: "int", nullable: false),
                    AdmittedYear = table.Column<int>(type: "int", nullable: false),
                    ClassRollNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SymbolNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Team = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Coaching = table.Column<bool>(type: "bit", nullable: true),
                    TransportationMode = table.Column<int>(type: "int", nullable: true),
                    TeaBreakfast = table.Column<bool>(type: "bit", nullable: true),
                    LunchSnacks = table.Column<bool>(type: "bit", nullable: true),
                    Vegetarian = table.Column<bool>(type: "bit", nullable: true),
                    EnrollmentType = table.Column<int>(type: "int", nullable: true),
                    IEMISNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAcademicInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentAccountInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastInsertedId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentIDUnique = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentPreviousCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusRoute = table.Column<int>(type: "int", nullable: false),
                    BusStop = table.Column<int>(type: "int", nullable: false),
                    BusRouteEvening = table.Column<int>(type: "int", nullable: false),
                    BusStopEvening = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAccountInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentAddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermanentProvince = table.Column<int>(type: "int", nullable: true),
                    PermanentDistrict = table.Column<int>(type: "int", nullable: true),
                    PermanentMunicipality = table.Column<int>(type: "int", nullable: true),
                    PermanentAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentProvince = table.Column<int>(type: "int", nullable: true),
                    CurrentDistrict = table.Column<int>(type: "int", nullable: true),
                    CurrentMunicipality = table.Column<int>(type: "int", nullable: true),
                    CurrentAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAddress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentOtherDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Religion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ethnicity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Citizenship = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DifferentlyAbled = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentOtherDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentParentsDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherOccupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherCell = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherOccupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherCell = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuardianName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuardianRelation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuardianImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuardianCell = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentParentsDetails", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PreviousSchoolDetails");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "StudentAcademicInfo");

            migrationBuilder.DropTable(
                name: "StudentAccountInfo");

            migrationBuilder.DropTable(
                name: "StudentAddress");

            migrationBuilder.DropTable(
                name: "StudentOtherDetails");

            migrationBuilder.DropTable(
                name: "StudentParentsDetails");
        }
    }
}
