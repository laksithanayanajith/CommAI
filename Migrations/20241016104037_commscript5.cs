using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommAI.Migrations
{
    /// <inheritdoc />
    public partial class commscript5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NumberOfWeakPoints",
                table: "CommercialScriptSuggestion",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OriginalScript",
                table: "CommercialScriptSuggestion",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OriginalScript",
                table: "CommercialScriptEnhanced",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfWeakPoints",
                table: "CommercialScriptSuggestion");

            migrationBuilder.DropColumn(
                name: "OriginalScript",
                table: "CommercialScriptSuggestion");

            migrationBuilder.DropColumn(
                name: "OriginalScript",
                table: "CommercialScriptEnhanced");
        }
    }
}
