using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace razorproject.Migrations
{
    /// <inheritdoc />
    public partial class AddPasswordToLoginDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "LoginDetails",
                newName: "Password");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "LoginDetails",
                newName: "Email");
        }
    }
}
