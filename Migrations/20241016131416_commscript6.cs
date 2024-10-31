using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommAI.Migrations
{
    /// <inheritdoc />
    public partial class commscript6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RelatedYouTubeVideoTitleCreativeContent",
                table: "CommercialScript",
                newName: "TrendingYouTubeVideoTitleCreativeContent");

            migrationBuilder.RenameColumn(
                name: "RelatedYouTubeVideoTitleCollection",
                table: "CommercialScript",
                newName: "TrendingYouTubeVideoTitleCollection");

            migrationBuilder.AddColumn<string>(
                name: "NewsKeyWords",
                table: "CommercialScript",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewsKeyWords",
                table: "CommercialScript");

            migrationBuilder.RenameColumn(
                name: "TrendingYouTubeVideoTitleCreativeContent",
                table: "CommercialScript",
                newName: "RelatedYouTubeVideoTitleCreativeContent");

            migrationBuilder.RenameColumn(
                name: "TrendingYouTubeVideoTitleCollection",
                table: "CommercialScript",
                newName: "RelatedYouTubeVideoTitleCollection");
        }
    }
}
