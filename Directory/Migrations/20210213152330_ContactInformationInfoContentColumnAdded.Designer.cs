﻿// <auto-generated />
using Directory.Model.ORM.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Directory.Migrations
{
    [DbContext(typeof(DirectoryContext))]
    [Migration("20210213152330_ContactInformationInfoContentColumnAdded")]
    partial class ContactInformationInfoContentColumnAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Directory.Model.ORM.Entities.ContactInformation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("EMail")
                        .HasColumnType("text");

                    b.Property<string>("InformationContent")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<int>("PersonID")
                        .HasColumnType("integer");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("PersonID");

                    b.ToTable("ContactInformation");
                });

            modelBuilder.Entity("Directory.Model.ORM.Entities.Person", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Company")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("People");
                });

            modelBuilder.Entity("Directory.Model.ORM.Entities.ContactInformation", b =>
                {
                    b.HasOne("Directory.Model.ORM.Entities.Person", "Person")
                        .WithMany("ContactInfoList")
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Directory.Model.ORM.Entities.Person", b =>
                {
                    b.Navigation("ContactInfoList");
                });
#pragma warning restore 612, 618
        }
    }
}
