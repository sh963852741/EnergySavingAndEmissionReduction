﻿// <auto-generated />
using System;
using JNJPBackEnd;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JNJPBackEnd.Migrations
{
    [DbContext(typeof(JNJPContext))]
    [Migration("20210418052759_credit")]
    partial class credit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JNJPBackEnd.Modules.Category", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ParentID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("ParentID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("JNJPBackEnd.Modules.CreditDetail", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CreditChange")
                        .HasColumnType("int");

                    b.Property<string>("Descript")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RecycleFormID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.ToTable("CreditDetails");
                });

            modelBuilder.Entity("JNJPBackEnd.Modules.RecycleForm", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Credit")
                        .HasColumnType("int");

                    b.Property<string>("RecycleMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubCategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("RecycleForms");
                });

            modelBuilder.Entity("JNJPBackEnd.Modules.Category", b =>
                {
                    b.HasOne("JNJPBackEnd.Modules.Category", null)
                        .WithMany("SubCategories")
                        .HasForeignKey("ParentID");
                });

            modelBuilder.Entity("JNJPBackEnd.Modules.Category", b =>
                {
                    b.Navigation("SubCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
