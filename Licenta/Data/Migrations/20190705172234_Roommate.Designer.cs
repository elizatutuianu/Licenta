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
    [DbContext(typeof(DBContext))]
    [Migration("20190705172234_Roommate")]
    partial class Roommate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Licenta.Models.AccomodationRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LastComfortAccepted");

                    b.HasKey("Id");

                    b.ToTable("AccomodationRequests");
                });

            modelBuilder.Entity("Licenta.Models.Dorm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DormBedsInRoom");

                    b.Property<int>("DormComfort");

                    b.Property<string>("DormGender");

                    b.Property<string>("DormName")
                        .IsRequired();

                    b.Property<int>("DormNoRooms");

                    b.Property<bool>("IsDormForRomanians");

                    b.Property<bool>("IsFull");

                    b.HasKey("Id");

                    b.ToTable("Dorms");
                });

            modelBuilder.Entity("Licenta.Models.DormsPreferred", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AccomodationRequestId");

                    b.Property<int?>("DormId");

                    b.Property<string>("DormName");

                    b.HasKey("Id");

                    b.HasIndex("AccomodationRequestId");

                    b.HasIndex("DormId");

                    b.ToTable("DormsPreferreds");
                });

            modelBuilder.Entity("Licenta.Models.Faculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Faculties");
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

                    b.ToTable("IdCardStudents");
                });

            modelBuilder.Entity("Licenta.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BedsInRoom");

                    b.Property<int>("DormId");

                    b.Property<bool>("IsFull");

                    b.Property<string>("RoomGender");

                    b.Property<int>("RoomNo");

                    b.HasKey("Id");

                    b.HasIndex("DormId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Licenta.Models.Roommate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccomodationRequestId");

                    b.Property<string>("FirstName");

                    b.Property<string>("Initial");

                    b.Property<string>("LastName");

                    b.Property<int>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("AccomodationRequestId");

                    b.HasIndex("StudentId");

                    b.ToTable("Roommates");
                });

            modelBuilder.Entity("Licenta.Models.RoomPreferred", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AccomodationRequestId");

                    b.Property<int?>("RoomId");

                    b.Property<int>("RoomNo");

                    b.HasKey("Id");

                    b.HasIndex("AccomodationRequestId");

                    b.HasIndex("RoomId");

                    b.ToTable("RoomPreferreds");
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

                    b.ToTable("Specializations");
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

                    b.Property<string>("ConfirmPassword");

                    b.Property<int?>("Credits");

                    b.Property<string>("Email");

                    b.Property<int>("FacultyId");

                    b.Property<string>("FirstName");

                    b.Property<int?>("Group");

                    b.Property<int>("IdCardStudentId");

                    b.Property<string>("Initial");

                    b.Property<bool?>("IsMedicalCase");

                    b.Property<bool?>("IsSocialCase");

                    b.Property<string>("LastName");

                    b.Property<double?>("Media");

                    b.Property<string>("Password");

                    b.Property<string>("PhoneNo");

                    b.Property<int?>("RoomId");

                    b.Property<string>("Sex");

                    b.Property<int>("SpecializationId");

                    b.Property<string>("StudyProgram");

                    b.Property<string>("Taxa_buget");

                    b.Property<int?>("Year");

                    b.HasKey("Id");

                    b.HasIndex("AccomodationRequestId");

                    b.HasIndex("FacultyId");

                    b.HasIndex("IdCardStudentId");

                    b.HasIndex("RoomId");

                    b.HasIndex("SpecializationId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Licenta.Models.DormsPreferred", b =>
                {
                    b.HasOne("Licenta.Models.AccomodationRequest", "AccomodationRequest")
                        .WithMany("ArDorm")
                        .HasForeignKey("AccomodationRequestId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Licenta.Models.Dorm", "Dorm")
                        .WithMany()
                        .HasForeignKey("DormId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Licenta.Models.Room", b =>
                {
                    b.HasOne("Licenta.Models.Dorm")
                        .WithMany("Rooms")
                        .HasForeignKey("DormId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Licenta.Models.Roommate", b =>
                {
                    b.HasOne("Licenta.Models.AccomodationRequest", "AccomodationRequest")
                        .WithMany("ArRoommates")
                        .HasForeignKey("AccomodationRequestId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Licenta.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Licenta.Models.RoomPreferred", b =>
                {
                    b.HasOne("Licenta.Models.AccomodationRequest", "AccomodationRequest")
                        .WithMany("ArRoom")
                        .HasForeignKey("AccomodationRequestId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Licenta.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Licenta.Models.Specialization", b =>
                {
                    b.HasOne("Licenta.Models.Faculty")
                        .WithMany("Specializations")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Licenta.Models.Student", b =>
                {
                    b.HasOne("Licenta.Models.AccomodationRequest", "AccomodationRequest")
                        .WithMany()
                        .HasForeignKey("AccomodationRequestId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Licenta.Models.Faculty", "Faculty")
                        .WithMany()
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Licenta.Models.IdCardStudent", "IdCardStudent")
                        .WithMany()
                        .HasForeignKey("IdCardStudentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Licenta.Models.Room")
                        .WithMany("StudentsInRoom")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Licenta.Models.Specialization", "Specialization")
                        .WithMany()
                        .HasForeignKey("SpecializationId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
