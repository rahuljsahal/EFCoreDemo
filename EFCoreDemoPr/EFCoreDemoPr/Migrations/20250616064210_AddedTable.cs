using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreDemoPr.Migrations
{
    /// <inheritdoc />
    public partial class AddedTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "BooksTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "LanguageTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageTable", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BooksTable_LanguageId",
                table: "BooksTable",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_BooksTable_LanguageTable_LanguageId",
                table: "BooksTable",
                column: "LanguageId",
                principalTable: "LanguageTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BooksTable_LanguageTable_LanguageId",
                table: "BooksTable");

            migrationBuilder.DropTable(
                name: "LanguageTable");

            migrationBuilder.DropIndex(
                name: "IX_BooksTable_LanguageId",
                table: "BooksTable");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "BooksTable");
        }
    }
}
