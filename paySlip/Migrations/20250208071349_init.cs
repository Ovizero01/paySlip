using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace paySlip.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DueAmount",
                table: "StudentFees");

            migrationBuilder.RenameColumn(
                name: "StudentName",
                table: "StudentFees",
                newName: "TransactionId");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "StudentFees",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "RollNumber",
                table: "StudentFees",
                newName: "Course");

            migrationBuilder.RenameColumn(
                name: "PaidAmount",
                table: "StudentFees",
                newName: "AmountPaid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "StudentFees",
                newName: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TransactionId",
                table: "StudentFees",
                newName: "StudentName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "StudentFees",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "Course",
                table: "StudentFees",
                newName: "RollNumber");

            migrationBuilder.RenameColumn(
                name: "AmountPaid",
                table: "StudentFees",
                newName: "PaidAmount");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "StudentFees",
                newName: "Id");

            migrationBuilder.AddColumn<decimal>(
                name: "DueAmount",
                table: "StudentFees",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
