using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduSubscription.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateCourseLessonRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "tbl_OutboxMessages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 11, 10, 54, 8, 253, DateTimeKind.Local).AddTicks(3264),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 11, 9, 54, 0, 915, DateTimeKind.Local).AddTicks(7871));

            migrationBuilder.AddColumn<Guid>(
                name: "IdCourse",
                table: "tbl_Lessons",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Lessons_IdCourse",
                table: "tbl_Lessons",
                column: "IdCourse");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Lessons_tbl_Courses_IdCourse",
                table: "tbl_Lessons",
                column: "IdCourse",
                principalTable: "tbl_Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Lessons_tbl_Courses_IdCourse",
                table: "tbl_Lessons");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Lessons_IdCourse",
                table: "tbl_Lessons");

            migrationBuilder.DropColumn(
                name: "IdCourse",
                table: "tbl_Lessons");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "tbl_OutboxMessages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 11, 9, 54, 0, 915, DateTimeKind.Local).AddTicks(7871),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 11, 10, 54, 8, 253, DateTimeKind.Local).AddTicks(3264));
        }
    }
}
