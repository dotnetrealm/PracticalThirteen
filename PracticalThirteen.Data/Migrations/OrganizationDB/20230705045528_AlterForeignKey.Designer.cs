﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PracticalThirteen.Data.Contexts;

#nullable disable

namespace PracticalThirteen.Data.Migrations.OrganizationDB
{
    [DbContext(typeof(OrganizationDBContext))]
    [Migration("20230705045528_AlterForeignKey")]
    partial class AlterForeignKey
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PracticalThirteen.Data.Models.Designation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DesignationName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Designations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DesignationName = "Team Manager"
                        },
                        new
                        {
                            Id = 2,
                            DesignationName = "Lead Engineer"
                        },
                        new
                        {
                            Id = 3,
                            DesignationName = "Senior Developer"
                        },
                        new
                        {
                            Id = 4,
                            DesignationName = "Junior Developer"
                        },
                        new
                        {
                            Id = 5,
                            DesignationName = "Trainee Engineer"
                        });
                });

            modelBuilder.Entity("PracticalThirteen.Data.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<int?>("DesignationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("JoiningDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("DesignationId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("PracticalThirteen.Data.Models.EmployeeWithSalary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("Date");

                    b.Property<int>("DesignationId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("DesignationId");

                    b.ToTable("EmployeesWithSalary");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Rajkot",
                            DOB = new DateTime(2002, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DesignationId = 1,
                            FirstName = "Bhavin",
                            LastName = "Kareliya",
                            MobileNumber = "1231231231",
                            Salary = 999999m
                        },
                        new
                        {
                            Id = 2,
                            Address = "Anand",
                            DOB = new DateTime(2001, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DesignationId = 2,
                            FirstName = "Jil",
                            LastName = "Patel",
                            MobileNumber = "9898989898",
                            Salary = 999999m
                        },
                        new
                        {
                            Id = 3,
                            Address = "Ahemedabad",
                            DOB = new DateTime(1999, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DesignationId = 3,
                            FirstName = "Vipul",
                            LastName = "Kumar",
                            MobileNumber = "1231231231",
                            Salary = 999999m
                        },
                        new
                        {
                            Id = 4,
                            Address = "Morbi",
                            DOB = new DateTime(2002, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DesignationId = 3,
                            FirstName = "Abhi",
                            LastName = "Dasadiya",
                            MobileNumber = "9898989898",
                            Salary = 999999m
                        },
                        new
                        {
                            Id = 5,
                            Address = "Rajkot",
                            DOB = new DateTime(2001, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DesignationId = 3,
                            FirstName = "Jay",
                            LastName = "Gohel",
                            MobileNumber = "1231231231",
                            Salary = 999999m
                        });
                });

            modelBuilder.Entity("PracticalThirteen.Data.Models.Employee", b =>
                {
                    b.HasOne("PracticalThirteen.Data.Models.Designation", null)
                        .WithMany("Employees")
                        .HasForeignKey("DesignationId");
                });

            modelBuilder.Entity("PracticalThirteen.Data.Models.EmployeeWithSalary", b =>
                {
                    b.HasOne("PracticalThirteen.Data.Models.Designation", "Designation")
                        .WithMany()
                        .HasForeignKey("DesignationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Designation");
                });

            modelBuilder.Entity("PracticalThirteen.Data.Models.Designation", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
