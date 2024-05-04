using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduSubscription.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateIdMemberForeignKeyAtSubscriptionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "IdMember",
                table: "tbl_Subscriptions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "tbl_OutboxMessages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 4, 11, 53, 34, 367, DateTimeKind.Local).AddTicks(400),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 4, 11, 49, 14, 787, DateTimeKind.Local).AddTicks(1210));

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Subscriptions_IdMember",
                table: "tbl_Subscriptions",
                column: "IdMember");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Subscriptions_tbl_Members_IdMember",
                table: "tbl_Subscriptions",
                column: "IdMember",
                principalTable: "tbl_Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Subscriptions_tbl_Members_IdMember",
                table: "tbl_Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Subscriptions_IdMember",
                table: "tbl_Subscriptions");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdMember",
                table: "tbl_Subscriptions",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "tbl_OutboxMessages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 4, 11, 49, 14, 787, DateTimeKind.Local).AddTicks(1210),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 4, 11, 53, 34, 367, DateTimeKind.Local).AddTicks(400));
        }
    }
}
