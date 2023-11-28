﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace mnt_weApi_LaptopManagement_Code_First.Migrations
{
    [DbContext(typeof(mntContext))]
    partial class mntContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("mnt_weApi_LaptopManagement_Code_First.Model.Employee", b =>
                {
                    b.Property<int>("empId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("empId"));

                    b.Property<string>("empname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isLaptopAssigned")
                        .HasColumnType("bit");

                    b.HasKey("empId");

                    b.ToTable("employees");
                });

            modelBuilder.Entity("mnt_weApi_LaptopManagement_Code_First.Model.EmployeeLaptopMapping", b =>
                {
                    b.Property<int>("mappingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("mappingId"));

                    b.Property<string>("createdBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("createdDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("empId")
                        .HasColumnType("int");

                    b.Property<int>("laptopId")
                        .HasColumnType("int");

                    b.Property<string>("modifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("modifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("mappingId");

                    b.HasIndex("empId");

                    b.HasIndex("laptopId");

                    b.ToTable("EmployeeLaptopMappings");
                });

            modelBuilder.Entity("mnt_weApi_LaptopManagement_Code_First.Model.Laptop", b =>
                {
                    b.Property<int>("laptopId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("laptopId"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("battery")
                        .HasColumnType("bit");

                    b.Property<string>("brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("charger")
                        .HasColumnType("bit");

                    b.Property<bool>("isAssigned")
                        .HasColumnType("bit");

                    b.Property<bool>("keyBoard")
                        .HasColumnType("bit");

                    b.Property<bool>("mic")
                        .HasColumnType("bit");

                    b.Property<string>("modelNum")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("mouse")
                        .HasColumnType("bit");

                    b.Property<string>("operatingSystem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ram")
                        .HasColumnType("int");

                    b.Property<string>("serialNum")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("speaker")
                        .HasColumnType("bit");

                    b.Property<int>("storage")
                        .HasColumnType("int");

                    b.HasKey("laptopId");

                    b.ToTable("laptops");
                });

            modelBuilder.Entity("mnt_weApi_LaptopManagement_Code_First.Model.EmployeeLaptopMapping", b =>
                {
                    b.HasOne("mnt_weApi_LaptopManagement_Code_First.Model.Employee", "employee")
                        .WithMany("employeeLaptopMappings")
                        .HasForeignKey("empId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("mnt_weApi_LaptopManagement_Code_First.Model.Laptop", "laptop")
                        .WithMany()
                        .HasForeignKey("laptopId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("employee");

                    b.Navigation("laptop");
                });

            modelBuilder.Entity("mnt_weApi_LaptopManagement_Code_First.Model.Employee", b =>
                {
                    b.Navigation("employeeLaptopMappings");
                });
#pragma warning restore 612, 618
        }
    }
}
