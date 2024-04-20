using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduSubscription.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemovePaymentFromSubscriptionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Subscriptions_tbl_Payments_PaymentId",
                table: "tbl_Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Subscriptions_PaymentId",
                table: "tbl_Subscriptions");

            migrationBuilder.DropColumn(
                name: "IdPayment",
                table: "tbl_Subscriptions");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "tbl_Subscriptions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdPayment",
                table: "tbl_Subscriptions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PaymentId",
                table: "tbl_Subscriptions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Subscriptions_PaymentId",
                table: "tbl_Subscriptions",
                column: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Subscriptions_tbl_Payments_PaymentId",
                table: "tbl_Subscriptions",
                column: "PaymentId",
                principalTable: "tbl_Payments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
