﻿// <auto-generated />
using System;
using JobFinder.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JobFinder.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.31")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("JobFinder.Infrastructure.Data.Models.Application", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Application identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ApplicantId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("AppliedAt")
                        .HasColumnType("datetime2")
                        .HasComment("Date of application");

                    b.Property<string>("CoverLetter")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasComment("Application cover letter");

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.Property<string>("ResumeURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Applicant resume URL");

                    b.HasKey("Id");

                    b.HasIndex("ApplicantId");

                    b.HasIndex("JobId");

                    b.ToTable("Applications");

                    b.HasComment("Applications table");
                });

            modelBuilder.Entity("JobFinder.Infrastructure.Data.Models.AppRole", b =>
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

            modelBuilder.Entity("JobFinder.Infrastructure.Data.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasComment("User bio");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("User first name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("User last name");

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

                    b.HasIndex("CompanyId")
                        .IsUnique()
                        .HasFilter("[CompanyId] IS NOT NULL");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasComment("Users table");

                    b.HasData(
                        new
                        {
                            Id = "dea12856-c198-4129-b3f3-b893d8395082",
                            AccessFailedCount = 0,
                            Bio = "I'm an admin and I moderate.",
                            ConcurrencyStamp = "0f730721-cce0-4c14-b7f0-dcaad3dee786",
                            Email = "admin@mail.com",
                            EmailConfirmed = false,
                            FirstName = "Admin",
                            LastName = "Adminson",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@MAIL.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAENvEsyEl3M7Er7cTwlWiD5vqo/W5kpeMzm6akCJJF/AvgwJVFXhz1wLB3GDUNIMslQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "bf288f60-4b0b-41df-9f62-6675226399ef",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = "206e17be-be9a-4fb6-92e7-9399f462cd94",
                            AccessFailedCount = 0,
                            Bio = "I'm a recruiter and I recruit people.",
                            ConcurrencyStamp = "5463eae1-1e62-4903-9ee8-9d03527cdf84",
                            Email = "recruiter@mail.com",
                            EmailConfirmed = false,
                            FirstName = "Recruiter",
                            LastName = "Recruiterson",
                            LockoutEnabled = false,
                            NormalizedEmail = "RECRUITER@MAIL.COM",
                            NormalizedUserName = "RECRUITER",
                            PasswordHash = "AQAAAAEAACcQAAAAEH/3Rf1KRsmtdbazwHSMHQKd749fNJnFmKWggVz56ftrU2jiV8T0+pTuXD5apuwK5Q==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "5ee459ff-a739-4ad1-94c3-410e35c350ad",
                            TwoFactorEnabled = false,
                            UserName = "recruiter"
                        },
                        new
                        {
                            Id = "a6391dd9-9706-4ebb-b00b-3efa5e49a53f",
                            AccessFailedCount = 0,
                            Bio = "I'm a job seeker and I'm looking for a job.",
                            ConcurrencyStamp = "9c816fb8-ab16-415d-9340-c16f3051914f",
                            Email = "jobseeker@mail.com",
                            EmailConfirmed = false,
                            FirstName = "Job",
                            LastName = "Seeker",
                            LockoutEnabled = false,
                            NormalizedEmail = "JOBSEEKER@MAIL.COM",
                            NormalizedUserName = "JOBSEEKER",
                            PasswordHash = "AQAAAAEAACcQAAAAECpaFRzXIN8+bsPGIuh/WsdbTp2voO+GntJffjB65ynICvLFmcWz/0RSJiZQBlkoWA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "d94f95f1-5743-4cd4-ad1e-386f3adb7f2d",
                            TwoFactorEnabled = false,
                            UserName = "jobseeker"
                        });
                });

            modelBuilder.Entity("JobFinder.Infrastructure.Data.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Category identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasComment("Category name");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasComment("Categories table");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "IT"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Creative"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Marketing"
                        });
                });

            modelBuilder.Entity("JobFinder.Infrastructure.Data.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Company identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasComment("Company description");

                    b.Property<string>("EmployerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Industry")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasComment("Company industry");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Company name");

                    b.HasKey("Id");

                    b.ToTable("Companies");

                    b.HasComment("Companies table");
                });

            modelBuilder.Entity("JobFinder.Infrastructure.Data.Models.EmploymentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Employment type identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Employment type name");

                    b.HasKey("Id");

                    b.ToTable("EmploymentTypes");

                    b.HasComment("Employment types table");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Full-time"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Part-time"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Contract"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Internship"
                        });
                });

            modelBuilder.Entity("JobFinder.Infrastructure.Data.Models.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Job identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Benefits")
                        .HasMaxLength(700)
                        .HasColumnType("nvarchar(700)")
                        .HasComment("Job benefits");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasComment("Job category");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int")
                        .HasComment("Job provider company");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasComment("Job listing creation date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasComment("Job description");

                    b.Property<int>("EmploymentTypeId")
                        .HasColumnType("int")
                        .HasComment("Job employment type");

                    b.Property<int>("MaxSalary")
                        .HasColumnType("int")
                        .HasComment("Job maximum monthly salary");

                    b.Property<int>("MinSalary")
                        .HasColumnType("int")
                        .HasComment("Job minimum monthly salary");

                    b.Property<string>("Requirements")
                        .IsRequired()
                        .HasMaxLength(700)
                        .HasColumnType("nvarchar(700)")
                        .HasComment("Job requirements");

                    b.Property<string>("Responsibilities")
                        .HasMaxLength(700)
                        .HasColumnType("nvarchar(700)")
                        .HasComment("Job responsibilities");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Job title");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("EmploymentTypeId");

                    b.ToTable("Jobs");

                    b.HasComment("Accounts table");
                });

            modelBuilder.Entity("JobFinder.Infrastructure.Data.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Message identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasComment("Message content");

                    b.Property<string>("ReceiverId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SenderId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("SentAt")
                        .HasColumnType("datetime2")
                        .HasComment("Time message was sent");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");

                    b.HasComment("Messages table");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

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
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("JobFinder.Infrastructure.Data.Models.Application", b =>
                {
                    b.HasOne("JobFinder.Infrastructure.Data.Models.AppUser", "Applicant")
                        .WithMany("Applications")
                        .HasForeignKey("ApplicantId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("JobFinder.Infrastructure.Data.Models.Job", "Job")
                        .WithMany("Applications")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Applicant");

                    b.Navigation("Job");
                });

            modelBuilder.Entity("JobFinder.Infrastructure.Data.Models.AppUser", b =>
                {
                    b.HasOne("JobFinder.Infrastructure.Data.Models.Company", "Company")
                        .WithOne("Employer")
                        .HasForeignKey("JobFinder.Infrastructure.Data.Models.AppUser", "CompanyId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Company");
                });

            modelBuilder.Entity("JobFinder.Infrastructure.Data.Models.Job", b =>
                {
                    b.HasOne("JobFinder.Infrastructure.Data.Models.Category", "Category")
                        .WithMany("Jobs")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("JobFinder.Infrastructure.Data.Models.Company", "Company")
                        .WithMany("Jobs")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("JobFinder.Infrastructure.Data.Models.EmploymentType", "EmploymentType")
                        .WithMany("Jobs")
                        .HasForeignKey("EmploymentTypeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Company");

                    b.Navigation("EmploymentType");
                });

            modelBuilder.Entity("JobFinder.Infrastructure.Data.Models.Message", b =>
                {
                    b.HasOne("JobFinder.Infrastructure.Data.Models.AppUser", "Receiver")
                        .WithMany("InboundMessages")
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("JobFinder.Infrastructure.Data.Models.AppUser", "Sender")
                        .WithMany("OutboundMessages")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("JobFinder.Infrastructure.Data.Models.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("JobFinder.Infrastructure.Data.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("JobFinder.Infrastructure.Data.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("JobFinder.Infrastructure.Data.Models.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobFinder.Infrastructure.Data.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("JobFinder.Infrastructure.Data.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JobFinder.Infrastructure.Data.Models.AppUser", b =>
                {
                    b.Navigation("Applications");

                    b.Navigation("InboundMessages");

                    b.Navigation("OutboundMessages");
                });

            modelBuilder.Entity("JobFinder.Infrastructure.Data.Models.Category", b =>
                {
                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("JobFinder.Infrastructure.Data.Models.Company", b =>
                {
                    b.Navigation("Employer")
                        .IsRequired();

                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("JobFinder.Infrastructure.Data.Models.EmploymentType", b =>
                {
                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("JobFinder.Infrastructure.Data.Models.Job", b =>
                {
                    b.Navigation("Applications");
                });
#pragma warning restore 612, 618
        }
    }
}
