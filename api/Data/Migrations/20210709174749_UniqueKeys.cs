using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Data.Migrations
{
    public partial class UniqueKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Sections",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Sections",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Sections",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Sections",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Sections",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Departments",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Departments",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Departments",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Departments",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sections_Name_Number_Email",
                table: "Sections",
                columns: new[] { "Name", "Number", "Email" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schools_Name_Number_Email",
                table: "Schools",
                columns: new[] { "Name", "Number", "Email" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OtherSchools_Name",
                table: "OtherSchools",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_Title",
                table: "Jobs",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Grades_Name",
                table: "Grades",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Identity_Mobile1_Email",
                table: "Employees",
                columns: new[] { "Identity", "Mobile1", "Email" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Name_Number_Email",
                table: "Departments",
                columns: new[] { "Name", "Number", "Email" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Sections_Name_Number_Email",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Schools_Name_Number_Email",
                table: "Schools");

            migrationBuilder.DropIndex(
                name: "IX_OtherSchools_Name",
                table: "OtherSchools");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_Title",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Grades_Name",
                table: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_Employees_Identity_Mobile1_Email",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Departments_Name_Number_Email",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Departments");
        }
    }
}
