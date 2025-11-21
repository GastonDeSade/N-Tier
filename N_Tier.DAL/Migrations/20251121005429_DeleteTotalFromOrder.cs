using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace N_Tier.DAL.Migrations
{
    /// <inheritdoc />
    public partial class DeleteTotalFromOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalOrder",
                schema: "Identity",
                table: "Orders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "TotalOrder",
                schema: "Identity",
                table: "Orders",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
