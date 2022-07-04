﻿// <auto-generated />
using System;
using CollegeSemesterApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CollegeSemesterApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220703175331_AddTeacherToClass")]
    partial class AddTeacherToClass
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("CollegeSemesterApi.Models.Class", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("TeacherId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("CollegeSemesterApi.Models.Student", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<bool>("Approved")
                        .HasColumnType("bit");

                    b.Property<long?>("ClassId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("p1")
                        .HasColumnType("real");

                    b.Property<float?>("p2")
                        .HasColumnType("real");

                    b.Property<float?>("p3")
                        .HasColumnType("real");

                    b.Property<float?>("pFinal")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("CollegeSemesterApi.Models.Teacher", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("CollegeSemesterApi.Models.Class", b =>
                {
                    b.HasOne("CollegeSemesterApi.Models.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("CollegeSemesterApi.Models.Student", b =>
                {
                    b.HasOne("CollegeSemesterApi.Models.Class", "Class")
                        .WithMany("Students")
                        .HasForeignKey("ClassId");

                    b.Navigation("Class");
                });

            modelBuilder.Entity("CollegeSemesterApi.Models.Class", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
