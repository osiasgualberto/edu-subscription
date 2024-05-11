using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduSubscription.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateBasePriceAtPlanTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProcessedDate",
                table: "tbl_Payments",
                newName: "LastProcessedDate");

            migrationBuilder.AddColumn<decimal>(
                name: "BasePrice",
                table: "tbl_Plans",
                type: "decimal(15,4)",
                precision: 15,
                scale: 4,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "tbl_OutboxMessages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 10, 10, 36, 9, 612, DateTimeKind.Local).AddTicks(5457),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 4, 11, 53, 34, 367, DateTimeKind.Local).AddTicks(400));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BasePrice",
                table: "tbl_Plans");

            migrationBuilder.RenameColumn(
                name: "LastProcessedDate",
                table: "tbl_Payments",
                newName: "ProcessedDate");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "tbl_OutboxMessages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 4, 11, 53, 34, 367, DateTimeKind.Local).AddTicks(400),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 10, 10, 36, 9, 612, DateTimeKind.Local).AddTicks(5457));
        }
    }
}
