﻿// <auto-generated />
using System;
using EduSubscription.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EduSubscription.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240426120144_CreateOutboxMessageTable")]
    partial class CreateOutboxMessageTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.3.24172.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EduSubscription.Core.Payments.Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdSubscription")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PaymentStatus")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ProcessedDate")
                        .HasColumnType("datetime2");

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

                    b.Property<int>("DurationInMonths")
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

                    b.Property<Guid>("IdPlan")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly>("Start")
                        .HasColumnType("date");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdPlan");

                    b.ToTable("tbl_Subscriptions", (string)null);
                });

            modelBuilder.Entity("EduSubscription.Infrastructure.Persistence.Common.Outbox.OutboxMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 4, 26, 9, 1, 43, 165, DateTimeKind.Local).AddTicks(2615));

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("tbl_OutboxMessages", (string)null);
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
                    b.HasOne("EduSubscription.Core.Plans.Plan", "Plan")
                        .WithMany()
                        .HasForeignKey("IdPlan")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Plan");
                });
#pragma warning restore 612, 618
        }
    }
}
