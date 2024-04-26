using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduSubscription.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateColumnTypeAtOutboxMessageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "tbl_OutboxMessages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 26, 9, 28, 16, 537, DateTimeKind.Local).AddTicks(6964),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 26, 9, 1, 43, 165, DateTimeKind.Local).AddTicks(2615));

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "tbl_OutboxMessages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "tbl_OutboxMessages");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "tbl_OutboxMessages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 26, 9, 1, 43, 165, DateTimeKind.Local).AddTicks(2615),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 26, 9, 28, 16, 537, DateTimeKind.Local).AddTicks(6964));
        }
    }
}
