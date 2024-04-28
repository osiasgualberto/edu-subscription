using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduSubscription.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateOutboxMessageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "tbl_Payments",
                newName: "PaymentStatus");

            migrationBuilder.AddColumn<Guid>(
                name: "IdSubscription",
                table: "tbl_Payments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "tbl_OutboxMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 4, 26, 9, 1, 43, 165, DateTimeKind.Local).AddTicks(2615)),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_OutboxMessages", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Payments_IdSubscription",
                table: "tbl_Payments",
                column: "IdSubscription");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Payments_tbl_Subscriptions_IdSubscription",
                table: "tbl_Payments",
                column: "IdSubscription",
                principalTable: "tbl_Subscriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Payments_tbl_Subscriptions_IdSubscription",
                table: "tbl_Payments");

            migrationBuilder.DropTable(
                name: "tbl_OutboxMessages");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Payments_IdSubscription",
                table: "tbl_Payments");

            migrationBuilder.DropColumn(
                name: "IdSubscription",
                table: "tbl_Payments");

            migrationBuilder.RenameColumn(
                name: "PaymentStatus",
                table: "tbl_Payments",
                newName: "Status");
        }
    }
}
