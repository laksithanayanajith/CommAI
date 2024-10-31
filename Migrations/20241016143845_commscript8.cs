using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommAI.Migrations
{
    /// <inheritdoc />
    public partial class commscript8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "CommercialScriptInsights",
                newName: "ProductOrServiceName");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "CommercialScript",
                newName: "ProductOrServiceName");

            migrationBuilder.AddColumn<string>(
                name: "GenderGroup",
                table: "CommercialScriptInsights",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductOrService",
                table: "CommercialScriptInsights",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductOrServiceDescription",
                table: "CommercialScriptInsights",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GenderGroup",
                table: "CommercialScript",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductOrService",
                table: "CommercialScript",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductOrServiceDescription",
                table: "CommercialScript",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GenderGroup",
                table: "CommercialScriptInsights");

            migrationBuilder.DropColumn(
                name: "ProductOrService",
                table: "CommercialScriptInsights");

            migrationBuilder.DropColumn(
                name: "ProductOrServiceDescription",
                table: "CommercialScriptInsights");

            migrationBuilder.DropColumn(
                name: "GenderGroup",
                table: "CommercialScript");

            migrationBuilder.DropColumn(
                name: "ProductOrService",
                table: "CommercialScript");

            migrationBuilder.DropColumn(
                name: "ProductOrServiceDescription",
                table: "CommercialScript");

            migrationBuilder.RenameColumn(
                name: "ProductOrServiceName",
                table: "CommercialScriptInsights",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "ProductOrServiceName",
                table: "CommercialScript",
                newName: "Gender");
        }
    }
}
