﻿// <auto-generated />
using System;
using Licenta.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Licenta.Migrations
{
    [DbContext(typeof(MyAppContext))]
    [Migration("20190524135856_InitialDB")]
    partial class InitialDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Licenta.Models.AccomodationRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArConfort");

                    b.HasKey("Id");

                    b.ToTable("AccomodationRequest");
                });

            modelBuilder.Entity("Licenta.Models.Dorm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AccomodationRequestId");

                    b.Property<int>("DormBedsInRoom");

                    b.Property<int>("DormComfort");

                    b.Property<string>("DormGender")
                        .IsRequired();

                    b.Property<string>("DormName")
                        .IsRequired();

                    b.Property<int>("DormNoRooms");

                    b.Property<bool>("IsDormForRomanians");

                    b.HasKey("Id");

                    b.HasIndex("AccomodationRequestId");

                    b.ToTable("Dorm");
                });

            modelBuilder.Entity("Licenta.Models.Faculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Faculty");
                });

            modelBuilder.Entity("Licenta.Models.IdCardStudent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("CivilStatus");

                    b.Property<string>("Country");

                    b.Property<string>("District");

                    b.Property<string>("IdCardIssuedBy");

                    b.Property<DateTime>("IdCardIssuedDate");

                    b.Property<string>("IdCardNo");

                    b.Property<string>("Localty");

                    b.HasKey("Id");

                    b.ToTable("IdCardStudent");
                });

            modelBuilder.Entity("Licenta.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AccomodationRequestId");

                    b.Property<int>("BedsInRoom");

                    b.Property<int?>("DormId");

                    b.Property<string>("RoomGender");

                    b.Property<int>("RoomNo");

                    b.HasKey("Id");

                    b.HasIndex("AccomodationRequestId");

                    b.HasIndex("DormId");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("Licenta.Models.Specialization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FacultyId");

                    b.Property<string>("SpecLanguageOfStudy");

                    b.Property<string>("SpecName");

                    b.Property<int>("SpecNoOfFemaleStudents");

                    b.Property<int>("SpecNoOfStudents");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.ToTable("Specialization");
                });

            modelBuilder.Entity("Licenta.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AccomodationRequestId");

                    b.Property<string>("Cnp")
                        .IsRequired()
                        .HasMaxLength(13);

                    b.Property<string>("ConfirmPassword")
                        .IsRequired();

                    b.Property<int>("Credits");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<int?>("FacultyId");

                    b.Property<string>("FirstName");

                    b.Property<int>("Group");

                    b.Property<int?>("IdCardStudent1Id");

                    b.Property<string>("Initial");

                    b.Property<bool>("IsAdmin");

                    b.Property<bool>("IsMedicalCase");

                    b.Property<bool>("IsSocialCase");

                    b.Property<string>("LanguageOfStudy1");

                    b.Property<string>("LastName");

                    b.Property<float>("Media");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("PhoneNo");

                    b.Property<int?>("RoomId");

                    b.Property<string>("Sex");

                    b.Property<int?>("SpecializationId");

                    b.Property<string>("StudyProgram");

                    b.Property<string>("Taxa_buget");

                    b.Property<string>("Year");

                    b.HasKey("Id");

                    b.HasIndex("AccomodationRequestId");

                    b.HasIndex("FacultyId");

                    b.HasIndex("IdCardStudent1Id");

                    b.HasIndex("RoomId");

                    b.HasIndex("SpecializationId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Licenta.Models.Dorm", b =>
                {
                    b.HasOne("Licenta.Models.AccomodationRequest")
                        .WithMany("ArDorm")
                        .HasForeignKey("AccomodationRequestId");
                });

            modelBuilder.Entity("Licenta.Models.Room", b =>
                {
                    b.HasOne("Licenta.Models.AccomodationRequest")
                        .WithMany("ArRoom")
                        .HasForeignKey("AccomodationRequestId");

                    b.HasOne("Licenta.Models.Dorm")
                        .WithMany("Rooms")
                        .HasForeignKey("DormId");
                });

            modelBuilder.Entity("Licenta.Models.Specialization", b =>
                {
                    b.HasOne("Licenta.Models.Faculty")
                        .WithMany("Specializations")
                        .HasForeignKey("FacultyId");
                });

            modelBuilder.Entity("Licenta.Models.Student", b =>
                {
                    b.HasOne("Licenta.Models.AccomodationRequest", "AccomodationRequest")
                        .WithMany("ArRoommates")
                        .HasForeignKey("AccomodationRequestId");

                    b.HasOne("Licenta.Models.Faculty", "Faculty")
                        .WithMany()
                        .HasForeignKey("FacultyId");

                    b.HasOne("Licenta.Models.IdCardStudent", "IdCardStudent1")
                        .WithMany()
                        .HasForeignKey("IdCardStudent1Id");

                    b.HasOne("Licenta.Models.Room")
                        .WithMany("StudentsInRoom")
                        .HasForeignKey("RoomId");

                    b.HasOne("Licenta.Models.Specialization", "Specialization")
                        .WithMany()
                        .HasForeignKey("SpecializationId");
                });
#pragma warning restore 612, 618
        }
    }
}
