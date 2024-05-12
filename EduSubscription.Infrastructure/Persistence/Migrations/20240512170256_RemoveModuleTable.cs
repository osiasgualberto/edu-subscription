using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduSubscription.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemoveModuleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Lessons_tbl_Modules_IdModule",
                table: "tbl_Lessons");

            migrationBuilder.DropTable(
                name: "tbl_Modules");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Lessons_IdModule",
                table: "tbl_Lessons");

            migrationBuilder.DropColumn(
                name: "IdModule",
                table: "tbl_Lessons");

            migrationBuilder.DropColumn(
                name: "MinutesDuration",
                table: "tbl_Lessons");

            migrationBuilder.RenameColumn(
                name: "Installments",
                table: "tbl_Plans",
                newName: "MonthDuration");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "tbl_OutboxMessages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 12, 14, 2, 56, 144, DateTimeKind.Local).AddTicks(821),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 11, 10, 58, 15, 480, DateTimeKind.Local).AddTicks(7656));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MonthDuration",
                table: "tbl_Plans",
                newName: "Installments");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "tbl_OutboxMessages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 11, 10, 58, 15, 480, DateTimeKind.Local).AddTicks(7656),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 12, 14, 2, 56, 144, DateTimeKind.Local).AddTicks(821));

            migrationBuilder.AddColumn<Guid>(
                name: "IdModule",
                table: "tbl_Lessons",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<float>(
                name: "MinutesDuration",
                table: "tbl_Lessons",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "tbl_Modules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Modules", x => x.Id);
                });

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
    }
}
