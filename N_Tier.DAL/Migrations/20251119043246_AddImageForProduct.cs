using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace N_Tier.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddImageForProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                schema: "Identity",
                table: "Products",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                schema: "Identity",
                table: "Products");
        }
    }
}
