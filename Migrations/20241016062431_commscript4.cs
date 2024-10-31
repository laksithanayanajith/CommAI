using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommAI.Migrations
{
    /// <inheritdoc />
    public partial class commscript4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrandMessagingClarity",
                table: "CommercialScriptInsights");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BrandMessagingClarity",
                table: "CommercialScriptInsights",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
