using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Data.Migrations
{
    public partial class UpdateUniqueKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Sections_Name_Number_Email",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Schools_Name_Number_Email",
                table: "Schools");

            migrationBuilder.DropIndex(
                name: "IX_Employees_Identity_Mobile1_Email",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Departments_Name_Number_Email",
                table: "Departments");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_Email",
                table: "Sections",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sections_Name",
                table: "Sections",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sections_Number",
                table: "Sections",
                column: "Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schools_Email",
                table: "Schools",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schools_Name",
                table: "Schools",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schools_Number",
                table: "Schools",
                column: "Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Email",
                table: "Employees",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Identity",
                table: "Employees",
                column: "Identity",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Mobile1",
                table: "Employees",
                column: "Mobile1",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Email",
                table: "Departments",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Name",
                table: "Departments",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Number",
                table: "Departments",
                column: "Number",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Sections_Email",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Sections_Name",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Sections_Number",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Schools_Email",
                table: "Schools");

            migrationBuilder.DropIndex(
                name: "IX_Schools_Name",
                table: "Schools");

            migrationBuilder.DropIndex(
                name: "IX_Schools_Number",
                table: "Schools");

            migrationBuilder.DropIndex(
                name: "IX_Employees_Email",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_Identity",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_Mobile1",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Departments_Email",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_Name",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_Number",
                table: "Departments");

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
    }
}
