using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommAI.Migrations
{
    /// <inheritdoc />
    public partial class commscript2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "CommercialScript");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "CommercialScriptInsights",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommercialScriptInsights_IdentityUserId",
                table: "CommercialScriptInsights",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommercialScriptInsights_AspNetUsers_IdentityUserId",
                table: "CommercialScriptInsights",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommercialScriptInsights_AspNetUsers_IdentityUserId",
                table: "CommercialScriptInsights");

            migrationBuilder.DropIndex(
                name: "IX_CommercialScriptInsights_IdentityUserId",
                table: "CommercialScriptInsights");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "CommercialScriptInsights");

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "CommercialScript",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
