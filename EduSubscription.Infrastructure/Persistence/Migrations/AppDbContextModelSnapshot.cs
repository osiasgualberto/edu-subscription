﻿// <auto-generated />
using System;
using EduSubscription.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EduSubscription.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.3.24172.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EduSubscription.Core.Courses.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cover")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tbl_Courses", (string)null);
                });

            modelBuilder.Entity("EduSubscription.Core.Courses.Lesson", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IdCourse")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdModule")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("MinutesDuration")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdCourse");

                    b.HasIndex("IdModule");

                    b.ToTable("tbl_Lessons", (string)null);
                });

            modelBuilder.Entity("EduSubscription.Core.Courses.Module", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tbl_Modules", (string)null);
                });

            modelBuilder.Entity("EduSubscription.Core.Members.Member", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DocumentNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("tbl_Members", (string)null);
                });

            modelBuilder.Entity("EduSubscription.Core.Payments.Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdSubscription")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("LastProcessedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PaymentStatus")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasPrecision(15, 4)
                        .HasColumnType("decimal(15,4)");

                    b.HasKey("Id");

                    b.HasIndex("IdSubscription");

                    b.ToTable("tbl_Payments", (string)null);
                });

            modelBuilder.Entity("EduSubscription.Core.Plans.Plan", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Installments")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("tbl_Plans", (string)null);
                });

            modelBuilder.Entity("EduSubscription.Core.Subscriptions.Subscription", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly>("End")
                        .HasColumnType("date");

                    b.Property<Guid>("IdMember")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdPlan")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly>("Start")
                        .HasColumnType("date");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdMember");

                    b.HasIndex("IdPlan");

                    b.ToTable("tbl_Subscriptions", (string)null);
                });

            modelBuilder.Entity("EduSubscription.Infrastructure.Persistence.Common.Outbox.OutboxMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 5, 11, 10, 58, 15, 480, DateTimeKind.Local).AddTicks(7656));

                    b.Property<bool>("Processed")
                        .HasColumnType("bit");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tbl_OutboxMessages", (string)null);
                });

            modelBuilder.Entity("EduSubscription.Core.Courses.Lesson", b =>
                {
                    b.HasOne("EduSubscription.Core.Courses.Course", "Course")
                        .WithMany("Lessons")
                        .HasForeignKey("IdCourse")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EduSubscription.Core.Courses.Module", "Module")
                        .WithMany()
                        .HasForeignKey("IdModule")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Module");
                });

            modelBuilder.Entity("EduSubscription.Core.Payments.Payment", b =>
                {
                    b.HasOne("EduSubscription.Core.Subscriptions.Subscription", "Subscription")
                        .WithMany()
                        .HasForeignKey("IdSubscription")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Subscription");
                });

            modelBuilder.Entity("EduSubscription.Core.Subscriptions.Subscription", b =>
                {
                    b.HasOne("EduSubscription.Core.Members.Member", "Member")
                        .WithMany()
                        .HasForeignKey("IdMember")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EduSubscription.Core.Plans.Plan", "Plan")
                        .WithMany()
                        .HasForeignKey("IdPlan")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("Plan");
                });

            modelBuilder.Entity("EduSubscription.Core.Courses.Course", b =>
                {
                    b.Navigation("Lessons");
                });
#pragma warning restore 612, 618
        }
    }
}
