using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace N_Tier.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddImagesForProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image2",
                schema: "Identity",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image3",
                schema: "Identity",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image4",
                schema: "Identity",
                table: "Products",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image2",
                schema: "Identity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Image3",
                schema: "Identity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Image4",
                schema: "Identity",
                table: "Products");
        }
    }
}
