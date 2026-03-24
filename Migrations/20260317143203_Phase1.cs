using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagment.Migrations
{
    /// <inheritdoc />
    public partial class Phase1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "UserId", "Email", "Password", "UserName" },
                values: new object[] { 1, "shiv@gmail.com", "admin@321", "Shivam kumar" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "UserId",
                keyValue: 1);
        }
    }
}
