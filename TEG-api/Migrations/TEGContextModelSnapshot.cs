﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TEG_api.Data;

#nullable disable

namespace TEG_api.Migrations
{
    [DbContext(typeof(TEGContext))]
    partial class TEGContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TEG_api.Common.Models.Configuration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ChangesInGame")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("DiceId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<int>("NumberOfDices")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "DiceId" }, "IX_Configurations_DiceId");

                    b.ToTable("Configurations");
                });

            modelBuilder.Entity("TEG_api.Common.Models.Continent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("MapId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ValueOfTroops")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "MapId" }, "IX_Continents_MapId");

                    b.ToTable("Continents");
                });

            modelBuilder.Entity("TEG_api.Common.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ContinentId")
                        .HasColumnType("integer");

                    b.Property<int?>("CountryId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uuid")
                        .HasColumnName("OwnerID");

                    b.Property<int>("Troops")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex(new[] { "ContinentId" }, "IX_Countries_ContinentId");

                    b.HasIndex(new[] { "PlayerId" }, "IX_Countries_PlayerId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("TEG_api.Common.Models.DbHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Action")
                        .HasColumnType("text");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RecordId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TableName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("Timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("DbHistories");
                });

            modelBuilder.Entity("TEG_api.Common.Models.Dice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Faces")
                        .HasColumnType("integer");

                    b.Property<decimal?>("Probability")
                        .HasPrecision(5, 2)
                        .HasColumnType("numeric(5,2)");

                    b.Property<int>("Value")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Dices");
                });

            modelBuilder.Entity("TEG_api.Common.Models.Map", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Maps");
                });

            modelBuilder.Entity("TEG_api.Common.Models.Match", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreationDateUTC")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("EndDateUTC")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("MapId")
                        .HasColumnType("integer");

                    b.Property<int>("MatchConfigId")
                        .HasColumnType("integer");

                    b.Property<int>("MatchStatus")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset?>("SaveDateUTC")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Winner")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "MapId" }, "IX_Matchs_MapId");

                    b.HasIndex(new[] { "MatchConfigId" }, "IX_Matchs_MatchConfigId");

                    b.ToTable("Matchs");
                });

            modelBuilder.Entity("TEG_api.Common.Models.MatchConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ConfigurationId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ConfigurationId" }, "IX_MatchConfigs_ConfigurationId");

                    b.ToTable("MatchConfigs");
                });

            modelBuilder.Entity("TEG_api.Common.Models.Mission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("DifficultyType")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Missions");
                });

            modelBuilder.Entity("TEG_api.Common.Models.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "UserId" }, "IX_Players_UserId");

                    b.HasIndex(new[] { "UserId" }, "Players_Users_UserId")
                        .IsUnique();

                    b.ToTable("Players");
                });

            modelBuilder.Entity("TEG_api.Common.Models.PlayerGameSetup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<Guid>("MatchId")
                        .HasColumnType("uuid");

                    b.Property<int>("MissionId")
                        .HasColumnType("integer");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uuid");

                    b.Property<int>("TeamId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "MatchId" }, "IX_PlayerGameSetup_MatchId");

                    b.HasIndex(new[] { "MissionId" }, "IX_PlayerGameSetup_MissionId");

                    b.HasIndex(new[] { "PlayerId" }, "IX_PlayerGameSetup_PlayerId");

                    b.HasIndex(new[] { "TeamId" }, "IX_Players_TeamId");

                    b.ToTable("PlayerGameSetup", (string)null);
                });

            modelBuilder.Entity("TEG_api.Common.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("TEG_api.Common.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TEG_api.Common.Models.Configuration", b =>
                {
                    b.HasOne("TEG_api.Common.Models.Dice", "Dice")
                        .WithMany("Configurations")
                        .HasForeignKey("DiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dice");
                });

            modelBuilder.Entity("TEG_api.Common.Models.Continent", b =>
                {
                    b.HasOne("TEG_api.Common.Models.Map", "Map")
                        .WithMany("Continents")
                        .HasForeignKey("MapId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Map");
                });

            modelBuilder.Entity("TEG_api.Common.Models.Country", b =>
                {
                    b.HasOne("TEG_api.Common.Models.Continent", "Continent")
                        .WithMany("Countries")
                        .HasForeignKey("ContinentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TEG_api.Common.Models.Country", null)
                        .WithMany("BorderingCountries")
                        .HasForeignKey("CountryId");

                    b.HasOne("TEG_api.Common.Models.Player", null)
                        .WithMany("Countries")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Continent");
                });

            modelBuilder.Entity("TEG_api.Common.Models.Match", b =>
                {
                    b.HasOne("TEG_api.Common.Models.Map", "Map")
                        .WithMany("Matches")
                        .HasForeignKey("MapId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TEG_api.Common.Models.MatchConfig", "MatchConfig")
                        .WithMany("Matches")
                        .HasForeignKey("MatchConfigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Map");

                    b.Navigation("MatchConfig");
                });

            modelBuilder.Entity("TEG_api.Common.Models.MatchConfig", b =>
                {
                    b.HasOne("TEG_api.Common.Models.Configuration", "Configuration")
                        .WithMany("MatchConfigs")
                        .HasForeignKey("ConfigurationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Configuration");
                });

            modelBuilder.Entity("TEG_api.Common.Models.Player", b =>
                {
                    b.HasOne("TEG_api.Common.Models.User", "User")
                        .WithOne("Player")
                        .HasForeignKey("TEG_api.Common.Models.Player", "UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TEG_api.Common.Models.PlayerGameSetup", b =>
                {
                    b.HasOne("TEG_api.Common.Models.Match", "Match")
                        .WithMany("PlayerGameSetups")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TEG_api.Common.Models.Mission", "Mission")
                        .WithMany("PlayerGameSetups")
                        .HasForeignKey("MissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TEG_api.Common.Models.Player", "Player")
                        .WithMany("PlayerGameSetups")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TEG_api.Common.Models.Team", "Team")
                        .WithMany("PlayerGameSetups")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Match");

                    b.Navigation("Mission");

                    b.Navigation("Player");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("TEG_api.Common.Models.Configuration", b =>
                {
                    b.Navigation("MatchConfigs");
                });

            modelBuilder.Entity("TEG_api.Common.Models.Continent", b =>
                {
                    b.Navigation("Countries");
                });

            modelBuilder.Entity("TEG_api.Common.Models.Country", b =>
                {
                    b.Navigation("BorderingCountries");
                });

            modelBuilder.Entity("TEG_api.Common.Models.Dice", b =>
                {
                    b.Navigation("Configurations");
                });

            modelBuilder.Entity("TEG_api.Common.Models.Map", b =>
                {
                    b.Navigation("Continents");

                    b.Navigation("Matches");
                });

            modelBuilder.Entity("TEG_api.Common.Models.Match", b =>
                {
                    b.Navigation("PlayerGameSetups");
                });

            modelBuilder.Entity("TEG_api.Common.Models.MatchConfig", b =>
                {
                    b.Navigation("Matches");
                });

            modelBuilder.Entity("TEG_api.Common.Models.Mission", b =>
                {
                    b.Navigation("PlayerGameSetups");
                });

            modelBuilder.Entity("TEG_api.Common.Models.Player", b =>
                {
                    b.Navigation("Countries");

                    b.Navigation("PlayerGameSetups");
                });

            modelBuilder.Entity("TEG_api.Common.Models.Team", b =>
                {
                    b.Navigation("PlayerGameSetups");
                });

            modelBuilder.Entity("TEG_api.Common.Models.User", b =>
                {
                    b.Navigation("Player");
                });
#pragma warning restore 612, 618
        }
    }
}
