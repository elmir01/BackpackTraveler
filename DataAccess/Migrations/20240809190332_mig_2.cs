using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TravelToCategories_CategoryId",
                table: "TravelToCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelToCategories_TravelId",
                table: "TravelToCategories",
                column: "TravelId");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelToCategories_Categories_CategoryId",
                table: "TravelToCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelToCategories_Travels_TravelId",
                table: "TravelToCategories",
                column: "TravelId",
                principalTable: "Travels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TravelToCategories_Categories_CategoryId",
                table: "TravelToCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelToCategories_Travels_TravelId",
                table: "TravelToCategories");

            migrationBuilder.DropIndex(
                name: "IX_TravelToCategories_CategoryId",
                table: "TravelToCategories");

            migrationBuilder.DropIndex(
                name: "IX_TravelToCategories_TravelId",
                table: "TravelToCategories");
        }
    }
}
