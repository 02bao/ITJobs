﻿// <auto-generated />
using System;
using System.Collections.Generic;
using ITJobs.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ITJobs.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240413091012_3")]
    partial class _3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.2.24128.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ITJobs.Models.Application", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("JobsId")
                        .HasColumnType("bigint");

                    b.Property<string>("Letter")
                        .HasColumnType("text");

                    b.Property<long?>("ResumesId")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("UsersId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("JobsId");

                    b.HasIndex("ResumesId");

                    b.HasIndex("UsersId");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("ITJobs.Models.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("CompaniesId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CompaniesId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ITJobs.Models.Company", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Industry")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("size")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("ITJobs.Models.CompanyPost", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int?>("ApplicationCount")
                        .HasColumnType("integer");

                    b.Property<List<string>>("Comment")
                        .HasColumnType("text[]");

                    b.Property<long>("CompaniesId")
                        .HasColumnType("bigint");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Experience")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("ExpirationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Field")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<int?>("Like")
                        .HasColumnType("integer");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NamePost")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Parent")
                        .HasColumnType("integer");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Salary")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("Timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("WorkingMode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CompaniesId");

                    b.ToTable("CompanyPosts");
                });

            modelBuilder.Entity("ITJobs.Models.Job", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("CategoriesId")
                        .HasColumnType("bigint");

                    b.Property<long>("CompaniesId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Experience")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Field")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NameJob")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Requirements")
                        .HasColumnType("text");

                    b.Property<string>("Salary")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CategoriesId");

                    b.HasIndex("CompaniesId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("ITJobs.Models.JobSearch", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("CompaniesId")
                        .HasColumnType("bigint");

                    b.Property<string>("Experience_Level")
                        .HasColumnType("text");

                    b.Property<string>("Filed")
                        .HasColumnType("text");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Salary_Range")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("UsersId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CompaniesId");

                    b.HasIndex("UsersId");

                    b.ToTable("JobSearches");
                });

            modelBuilder.Entity("ITJobs.Models.Notification", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("ApplicationsId")
                        .HasColumnType("bigint");

                    b.Property<long>("CompaniesId")
                        .HasColumnType("bigint");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<bool>("ReadStatus")
                        .HasColumnType("boolean");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("UsersId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationsId");

                    b.HasIndex("CompaniesId");

                    b.HasIndex("UsersId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("ITJobs.Models.Resume", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Certifications")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Educartion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Experience")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<List<string>>("GitHubRepository")
                        .HasColumnType("text[]");

                    b.Property<string>("Skill")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserProfilesId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("UserProfilesId");

                    b.ToTable("Resume");
                });

            modelBuilder.Entity("ITJobs.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ITJobs.Models.UserPost", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<List<string>>("Comment")
                        .HasColumnType("text[]");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<string>("JobField")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("JobStyle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("Like")
                        .HasColumnType("bigint");

                    b.Property<string>("NamePost")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Parent")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("Timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserProfilesId")
                        .HasColumnType("bigint");

                    b.Property<string>("WokingMode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("UserProfilesId");

                    b.ToTable("UserPosts");
                });

            modelBuilder.Entity("ITJobs.Models.UserProfiles", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Avatar")
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("GitHub")
                        .HasColumnType("text");

                    b.Property<string>("Linkedin")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("ITJobs.Models.Application", b =>
                {
                    b.HasOne("ITJobs.Models.Job", "Jobs")
                        .WithMany()
                        .HasForeignKey("JobsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITJobs.Models.Resume", "Resumes")
                        .WithMany()
                        .HasForeignKey("ResumesId");

                    b.HasOne("ITJobs.Models.User", "Users")
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Jobs");

                    b.Navigation("Resumes");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("ITJobs.Models.Category", b =>
                {
                    b.HasOne("ITJobs.Models.Company", "Companies")
                        .WithMany("Categories")
                        .HasForeignKey("CompaniesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Companies");
                });

            modelBuilder.Entity("ITJobs.Models.Company", b =>
                {
                    b.HasOne("ITJobs.Models.User", "User")
                        .WithMany("Companies")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ITJobs.Models.CompanyPost", b =>
                {
                    b.HasOne("ITJobs.Models.Company", "Companies")
                        .WithMany("CompanyPosts")
                        .HasForeignKey("CompaniesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Companies");
                });

            modelBuilder.Entity("ITJobs.Models.Job", b =>
                {
                    b.HasOne("ITJobs.Models.Category", "Categories")
                        .WithMany("Jobs")
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITJobs.Models.Company", "Companies")
                        .WithMany("Jobs")
                        .HasForeignKey("CompaniesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categories");

                    b.Navigation("Companies");
                });

            modelBuilder.Entity("ITJobs.Models.JobSearch", b =>
                {
                    b.HasOne("ITJobs.Models.Company", "Companies")
                        .WithMany()
                        .HasForeignKey("CompaniesId");

                    b.HasOne("ITJobs.Models.User", "Users")
                        .WithMany()
                        .HasForeignKey("UsersId");

                    b.Navigation("Companies");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("ITJobs.Models.Notification", b =>
                {
                    b.HasOne("ITJobs.Models.Application", "Applications")
                        .WithMany()
                        .HasForeignKey("ApplicationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITJobs.Models.Company", "Companies")
                        .WithMany()
                        .HasForeignKey("CompaniesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITJobs.Models.User", "Users")
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Applications");

                    b.Navigation("Companies");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("ITJobs.Models.Resume", b =>
                {
                    b.HasOne("ITJobs.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITJobs.Models.UserProfiles", "UserProfiles")
                        .WithMany()
                        .HasForeignKey("UserProfilesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("UserProfiles");
                });

            modelBuilder.Entity("ITJobs.Models.UserPost", b =>
                {
                    b.HasOne("ITJobs.Models.User", "User")
                        .WithMany("UserPosts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITJobs.Models.UserProfiles", "UserProfiles")
                        .WithMany()
                        .HasForeignKey("UserProfilesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("UserProfiles");
                });

            modelBuilder.Entity("ITJobs.Models.UserProfiles", b =>
                {
                    b.HasOne("ITJobs.Models.User", "User")
                        .WithMany("UserProfiles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ITJobs.Models.Category", b =>
                {
                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("ITJobs.Models.Company", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("CompanyPosts");

                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("ITJobs.Models.User", b =>
                {
                    b.Navigation("Companies");

                    b.Navigation("UserPosts");

                    b.Navigation("UserProfiles");
                });
#pragma warning restore 612, 618
        }
    }
}
