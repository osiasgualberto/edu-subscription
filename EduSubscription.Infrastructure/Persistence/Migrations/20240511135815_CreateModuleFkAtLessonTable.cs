using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduSubscription.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateModuleFkAtLessonTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "tbl_OutboxMessages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 11, 10, 58, 15, 480, DateTimeKind.Local).AddTicks(7656),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 11, 10, 54, 8, 253, DateTimeKind.Local).AddTicks(3264));

            migrationBuilder.AddColumn<Guid>(
                name: "IdModule",
                table: "tbl_Lessons",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Lessons_IdModule",
                table: "tbl_Lessons",
                column: "IdModule");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Lessons_tbl_Modules_IdModule",
                table: "tbl_Lessons",
                column: "IdModule",
                principalTable: "tbl_Modules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Lessons_tbl_Modules_IdModule",
                table: "tbl_Lessons");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Lessons_IdModule",
                table: "tbl_Lessons");

            migrationBuilder.DropColumn(
                name: "IdModule",
                table: "tbl_Lessons");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "tbl_OutboxMessages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 11, 10, 54, 8, 253, DateTimeKind.Local).AddTicks(3264),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 11, 10, 58, 15, 480, DateTimeKind.Local).AddTicks(7656));
        }
    }
}
