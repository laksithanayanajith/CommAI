﻿// <auto-generated />
using System;
using CommAI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CommAI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241016062431_commscript4")]
    partial class commscript4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CommAI.Models.CommercialScript", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AdvertisingIdea")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AgeGroup")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrandName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrandTrendingQueries")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrandTrendingQueriesCreativeContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CommercialScriptInsightsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConsumerInsights")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrentTrendingQueries")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrentTrendingQueriesCreativeContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("EnhancedScript")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnhancedScriptTagLine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsEnhancedScriptFittedWithBrandTrendingQueries")
                        .HasColumnType("bit");

                    b.Property<bool>("IsEnhancedScriptFittedWithCurrentTrendingQueries")
                        .HasColumnType("bit");

                    b.Property<bool>("IsEnhancedScriptFittedWithNewsContent")
                        .HasColumnType("bit");

                    b.Property<bool>("IsEnhancedScriptFittedWithRelatedYouTubeVideoContents")
                        .HasColumnType("bit");

                    b.Property<bool>("IsEnhancedScriptMemorable")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOriginalScriptFittedWithBrandTrendingQueries")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOriginalScriptFittedWithCurrentTrendingQueries")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOriginalScriptFittedWithNewsContent")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOriginalScriptFittedWithRelatedYouTubeVideoContents")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOriginalScriptMemorable")
                        .HasColumnType("bit");

                    b.Property<string>("KeyMessagesOfEnhancedScript")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NewsCollection")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NewsCreativeContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Promise")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReasonToBelieve")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RelatedYouTubeVideoTitleCollection")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RelatedYouTubeVideoTitleCreativeContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Script")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Story")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Suggestions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SuggestionsCount")
                        .HasColumnType("int");

                    b.Property<string>("WeakPoints")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CommercialScriptInsightsId")
                        .IsUnique();

                    b.ToTable("CommercialScript");
                });

            modelBuilder.Entity("CommAI.Models.CommercialScriptEnhanced", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AdvertisingIdea")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CommercialScriptId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CommercialScriptInsightsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EnhancedScript")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnhancedScriptTagLine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KeyMessagesOfEnhancedScript")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CommercialScriptId")
                        .IsUnique()
                        .HasFilter("[CommercialScriptId] IS NOT NULL");

                    b.HasIndex("CommercialScriptInsightsId")
                        .IsUnique();

                    b.ToTable("CommercialScriptEnhanced");
                });

            modelBuilder.Entity("CommAI.Models.CommercialScriptInsights", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AgeGroup")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrandName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConsumerInsights")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Promise")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReasonToBelieve")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Script")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Story")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdentityUserId");

                    b.ToTable("CommercialScriptInsights");
                });

            modelBuilder.Entity("CommAI.Models.CommercialScriptSuggestion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CommercialScriptId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CommercialScriptInsightsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Suggestions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SuggestionsCount")
                        .HasColumnType("int");

                    b.Property<string>("WeakPoints")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CommercialScriptId")
                        .IsUnique()
                        .HasFilter("[CommercialScriptId] IS NOT NULL");

                    b.HasIndex("CommercialScriptInsightsId")
                        .IsUnique();

                    b.ToTable("CommercialScriptSuggestion");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CommAI.Models.CommercialScript", b =>
                {
                    b.HasOne("CommAI.Models.CommercialScriptInsights", "CommercialScriptInsight")
                        .WithOne("CommercialScript")
                        .HasForeignKey("CommAI.Models.CommercialScript", "CommercialScriptInsightsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CommercialScriptInsight");
                });

            modelBuilder.Entity("CommAI.Models.CommercialScriptEnhanced", b =>
                {
                    b.HasOne("CommAI.Models.CommercialScript", "CommercialScript")
                        .WithOne("CommercialScriptEnhanced")
                        .HasForeignKey("CommAI.Models.CommercialScriptEnhanced", "CommercialScriptId");

                    b.HasOne("CommAI.Models.CommercialScriptInsights", "CommercialScriptInsights")
                        .WithOne("CommercialScriptEnhanced")
                        .HasForeignKey("CommAI.Models.CommercialScriptEnhanced", "CommercialScriptInsightsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CommercialScript");

                    b.Navigation("CommercialScriptInsights");
                });

            modelBuilder.Entity("CommAI.Models.CommercialScriptInsights", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserId");

                    b.Navigation("IdentityUser");
                });

            modelBuilder.Entity("CommAI.Models.CommercialScriptSuggestion", b =>
                {
                    b.HasOne("CommAI.Models.CommercialScript", "CommercialScript")
                        .WithOne("CommercialScriptSuggestion")
                        .HasForeignKey("CommAI.Models.CommercialScriptSuggestion", "CommercialScriptId");

                    b.HasOne("CommAI.Models.CommercialScriptInsights", "CommercialScriptInsights")
                        .WithOne("CommercialScriptSuggestion")
                        .HasForeignKey("CommAI.Models.CommercialScriptSuggestion", "CommercialScriptInsightsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CommercialScript");

                    b.Navigation("CommercialScriptInsights");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CommAI.Models.CommercialScript", b =>
                {
                    b.Navigation("CommercialScriptEnhanced");

                    b.Navigation("CommercialScriptSuggestion");
                });

            modelBuilder.Entity("CommAI.Models.CommercialScriptInsights", b =>
                {
                    b.Navigation("CommercialScript");

                    b.Navigation("CommercialScriptEnhanced");

                    b.Navigation("CommercialScriptSuggestion");
                });
#pragma warning restore 612, 618
        }
    }
}
