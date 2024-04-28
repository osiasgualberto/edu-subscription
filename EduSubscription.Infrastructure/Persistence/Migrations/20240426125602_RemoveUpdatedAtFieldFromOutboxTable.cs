using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduSubscription.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUpdatedAtFieldFromOutboxTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "tbl_OutboxMessages");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "tbl_OutboxMessages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 26, 9, 56, 1, 879, DateTimeKind.Local).AddTicks(8196),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 26, 9, 28, 16, 537, DateTimeKind.Local).AddTicks(6964));

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "tbl_OutboxMessages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Processed",
                table: "tbl_OutboxMessages",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "tbl_OutboxMessages");

            migrationBuilder.DropColumn(
                name: "Processed",
                table: "tbl_OutboxMessages");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "tbl_OutboxMessages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 26, 9, 28, 16, 537, DateTimeKind.Local).AddTicks(6964),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 26, 9, 56, 1, 879, DateTimeKind.Local).AddTicks(8196));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "tbl_OutboxMessages",
                type: "datetime2",
                nullable: true);
        }
    }
}
