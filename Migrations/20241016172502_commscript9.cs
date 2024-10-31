using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommAI.Migrations
{
    /// <inheritdoc />
    public partial class commscript9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NewsKeyWords",
                table: "CommercialScript",
                newName: "NewsCreativeContentBasedNews");

            migrationBuilder.AddColumn<string>(
                name: "NewsCreativeContentBasedNews",
                table: "CommercialScriptEnhanced",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewsCreativeContentBasedNews",
                table: "CommercialScriptEnhanced");

            migrationBuilder.RenameColumn(
                name: "NewsCreativeContentBasedNews",
                table: "CommercialScript",
                newName: "NewsKeyWords");
        }
    }
}
