﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using POC_Employee.Data;

#nullable disable

namespace POC_Employee.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("POC_Employee.Data.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Department");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "IT"
                        },
                        new
                        {
                            Id = 2,
                            Name = "HR"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Payroll"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Engineering"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Insurance & Healthcare"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Banking & Finance Services"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Retail & Logistics"
                        });
                });

            modelBuilder.Entity("POC_Employee.Data.Employees", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("City")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<long>("PhoneNumber")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("StateCode")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("ZipCode")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("POC_Employee.Data.Employees", b =>
                {
                    b.HasOne("POC_Employee.Data.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });
#pragma warning restore 612, 618
        }
    }
}
