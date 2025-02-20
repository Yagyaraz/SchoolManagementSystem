using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class newmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chapter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChapterTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subject = table.Column<int>(type: "int", nullable: false),
                    Class = table.Column<int>(type: "int", nullable: false),
                    LearningHours = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chapter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoursePlan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subject = table.Column<int>(type: "int", nullable: false),
                    Class = table.Column<int>(type: "int", nullable: false),
                    TeachingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TeachingDuration = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Credits = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpectedOutcome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursePlan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LessonPlan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeachingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TeachingDuration = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Class = table.Column<int>(type: "int", nullable: false),
                    Section = table.Column<int>(type: "int", nullable: false),
                    Subject = table.Column<int>(type: "int", nullable: false),
                    Chapter = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    TeachingMethods = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpectedOutcome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonPlan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LessonPlanCourseFile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonPlanId = table.Column<int>(type: "int", nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonPlanCourseFile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LessonPlanTeachingMaterial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonPlanId = table.Column<int>(type: "int", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonPlanTeachingMaterial", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeachingMethod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeachingMethod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseFile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoursePlanId = table.Column<int>(type: "int", nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LessonPlanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseFile_CoursePlan_CoursePlanId",
                        column: x => x.CoursePlanId,
                        principalTable: "CoursePlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseFile_LessonPlan_LessonPlanId",
                        column: x => x.LessonPlanId,
                        principalTable: "LessonPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeachingMaterial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoursePlanId = table.Column<int>(type: "int", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LessonPlanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeachingMaterial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeachingMaterial_CoursePlan_CoursePlanId",
                        column: x => x.CoursePlanId,
                        principalTable: "CoursePlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeachingMaterial_LessonPlan_LessonPlanId",
                        column: x => x.LessonPlanId,
                        principalTable: "LessonPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseFile_CoursePlanId",
                table: "CourseFile",
                column: "CoursePlanId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseFile_LessonPlanId",
                table: "CourseFile",
                column: "LessonPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_TeachingMaterial_CoursePlanId",
                table: "TeachingMaterial",
                column: "CoursePlanId");

            migrationBuilder.CreateIndex(
                name: "IX_TeachingMaterial_LessonPlanId",
                table: "TeachingMaterial",
                column: "LessonPlanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chapter");

            migrationBuilder.DropTable(
                name: "CourseFile");

            migrationBuilder.DropTable(
                name: "LessonPlanCourseFile");

            migrationBuilder.DropTable(
                name: "LessonPlanTeachingMaterial");

            migrationBuilder.DropTable(
                name: "TeachingMaterial");

            migrationBuilder.DropTable(
                name: "TeachingMethod");

            migrationBuilder.DropTable(
                name: "CoursePlan");

            migrationBuilder.DropTable(
                name: "LessonPlan");
        }
    }
}
