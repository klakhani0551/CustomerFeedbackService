using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerFeedbackService.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCustomerFeedbackModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "CustomerFeedbacks",
                newName: "Ratings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ratings",
                table: "CustomerFeedbacks",
                newName: "Rating");
        }
    }
}
