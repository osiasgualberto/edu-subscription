using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduSubscription.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateRelationWithMemberInSubTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdMember",
                table: "tbl_Subscriptions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "tbl_OutboxMessages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 3, 10, 36, 36, 76, DateTimeKind.Local).AddTicks(746),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 3, 9, 32, 2, 369, DateTimeKind.Local).AddTicks(2369));

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Subscriptions_IdMember",
                table: "tbl_Subscriptions",
                column: "IdMember");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Subscriptions_tbl_Member_IdMember",
                table: "tbl_Subscriptions",
                column: "IdMember",
                principalTable: "tbl_Member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Subscriptions_tbl_Member_IdMember",
                table: "tbl_Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Subscriptions_IdMember",
                table: "tbl_Subscriptions");

            migrationBuilder.DropColumn(
                name: "IdMember",
                table: "tbl_Subscriptions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "tbl_OutboxMessages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 3, 9, 32, 2, 369, DateTimeKind.Local).AddTicks(2369),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 3, 10, 36, 36, 76, DateTimeKind.Local).AddTicks(746));
        }
    }
}
