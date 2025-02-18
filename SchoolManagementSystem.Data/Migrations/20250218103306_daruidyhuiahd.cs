using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class daruidyhuiahd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Home",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slogan",
                table: "Home",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "About",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "About",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "About",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fax",
                table: "About",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instagram",
                table: "About",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "About",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "About",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrincipalImage",
                table: "About",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrincipalMessage",
                table: "About",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrincipalName",
                table: "About",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrincipalSignature",
                table: "About",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RulesRegulation",
                table: "About",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TikTok",
                table: "About",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VisionStatement",
                table: "About",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YouTube",
                table: "About",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Home");

            migrationBuilder.DropColumn(
                name: "Slogan",
                table: "Home");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "About");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "About");

            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "About");

            migrationBuilder.DropColumn(
                name: "Fax",
                table: "About");

            migrationBuilder.DropColumn(
                name: "Instagram",
                table: "About");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "About");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "About");

            migrationBuilder.DropColumn(
                name: "PrincipalImage",
                table: "About");

            migrationBuilder.DropColumn(
                name: "PrincipalMessage",
                table: "About");

            migrationBuilder.DropColumn(
                name: "PrincipalName",
                table: "About");

            migrationBuilder.DropColumn(
                name: "PrincipalSignature",
                table: "About");

            migrationBuilder.DropColumn(
                name: "RulesRegulation",
                table: "About");

            migrationBuilder.DropColumn(
                name: "TikTok",
                table: "About");

            migrationBuilder.DropColumn(
                name: "VisionStatement",
                table: "About");

            migrationBuilder.DropColumn(
                name: "YouTube",
                table: "About");
        }
    }
}
