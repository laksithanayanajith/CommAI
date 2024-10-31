using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommAI.Migrations
{
    /// <inheritdoc />
    public partial class commscript1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommercialScriptInsights",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsumerInsights = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Promise = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonToBelieve = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Story = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Script = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    AgeGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandMessagingClarity = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommercialScriptInsights", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommercialScript",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsumerInsights = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Promise = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonToBelieve = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Story = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Script = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    AgeGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewsCollection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewsCreativeContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentTrendingQueries = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentTrendingQueriesCreativeContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandTrendingQueries = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandTrendingQueriesCreativeContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelatedYouTubeVideoTitleCollection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelatedYouTubeVideoTitleCreativeContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsOriginalScriptFittedWithNewsContent = table.Column<bool>(type: "bit", nullable: false),
                    IsOriginalScriptFittedWithCurrentTrendingQueries = table.Column<bool>(type: "bit", nullable: false),
                    IsOriginalScriptFittedWithBrandTrendingQueries = table.Column<bool>(type: "bit", nullable: false),
                    IsOriginalScriptFittedWithRelatedYouTubeVideoContents = table.Column<bool>(type: "bit", nullable: false),
                    IsOriginalScriptMemorable = table.Column<bool>(type: "bit", nullable: false),
                    WeakPoints = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdvertisingIdea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuggestionsCount = table.Column<int>(type: "int", nullable: false),
                    Suggestions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnhancedScript = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnhancedScriptTagLine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KeyMessagesOfEnhancedScript = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEnhancedScriptFittedWithNewsContent = table.Column<bool>(type: "bit", nullable: false),
                    IsEnhancedScriptFittedWithCurrentTrendingQueries = table.Column<bool>(type: "bit", nullable: false),
                    IsEnhancedScriptFittedWithBrandTrendingQueries = table.Column<bool>(type: "bit", nullable: false),
                    IsEnhancedScriptFittedWithRelatedYouTubeVideoContents = table.Column<bool>(type: "bit", nullable: false),
                    IsEnhancedScriptMemorable = table.Column<bool>(type: "bit", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommercialScriptInsightsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommercialScript", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommercialScript_CommercialScriptInsights_CommercialScriptInsightsId",
                        column: x => x.CommercialScriptInsightsId,
                        principalTable: "CommercialScriptInsights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommercialScriptEnhanced",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdvertisingIdea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnhancedScript = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnhancedScriptTagLine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KeyMessagesOfEnhancedScript = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommercialScriptInsightsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommercialScriptId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommercialScriptEnhanced", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommercialScriptEnhanced_CommercialScriptInsights_CommercialScriptInsightsId",
                        column: x => x.CommercialScriptInsightsId,
                        principalTable: "CommercialScriptInsights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommercialScriptEnhanced_CommercialScript_CommercialScriptId",
                        column: x => x.CommercialScriptId,
                        principalTable: "CommercialScript",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CommercialScriptSuggestion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WeakPoints = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuggestionsCount = table.Column<int>(type: "int", nullable: false),
                    Suggestions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommercialScriptInsightsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommercialScriptId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommercialScriptSuggestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommercialScriptSuggestion_CommercialScriptInsights_CommercialScriptInsightsId",
                        column: x => x.CommercialScriptInsightsId,
                        principalTable: "CommercialScriptInsights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommercialScriptSuggestion_CommercialScript_CommercialScriptId",
                        column: x => x.CommercialScriptId,
                        principalTable: "CommercialScript",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CommercialScript_CommercialScriptInsightsId",
                table: "CommercialScript",
                column: "CommercialScriptInsightsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommercialScriptEnhanced_CommercialScriptId",
                table: "CommercialScriptEnhanced",
                column: "CommercialScriptId",
                unique: true,
                filter: "[CommercialScriptId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CommercialScriptEnhanced_CommercialScriptInsightsId",
                table: "CommercialScriptEnhanced",
                column: "CommercialScriptInsightsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommercialScriptSuggestion_CommercialScriptId",
                table: "CommercialScriptSuggestion",
                column: "CommercialScriptId",
                unique: true,
                filter: "[CommercialScriptId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CommercialScriptSuggestion_CommercialScriptInsightsId",
                table: "CommercialScriptSuggestion",
                column: "CommercialScriptInsightsId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CommercialScriptEnhanced");

            migrationBuilder.DropTable(
                name: "CommercialScriptSuggestion");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CommercialScript");

            migrationBuilder.DropTable(
                name: "CommercialScriptInsights");
        }
    }
}
