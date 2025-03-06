using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Прокошин_Кирилл_ЭФБО_07_23.Migrations
{
    /// <inheritdoc />
    public partial class fixedCap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_authorid",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Genres_genreid",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_authorid",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_genreid",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "ISBN",
                table: "Books",
                newName: "isbn");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isbn",
                table: "Books",
                newName: "ISBN");

            migrationBuilder.CreateIndex(
                name: "IX_Books_authorid",
                table: "Books",
                column: "authorid");

            migrationBuilder.CreateIndex(
                name: "IX_Books_genreid",
                table: "Books",
                column: "genreid");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_authorid",
                table: "Books",
                column: "authorid",
                principalTable: "Authors",
                principalColumn: "authorid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Genres_genreid",
                table: "Books",
                column: "genreid",
                principalTable: "Genres",
                principalColumn: "genreid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
