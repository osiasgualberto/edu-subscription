using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduSubscription.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateIdMemberColumnAtSubscriptionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdMember",
                table: "tbl_Subscriptions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "tbl_OutboxMessages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 4, 11, 49, 14, 787, DateTimeKind.Local).AddTicks(1210),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 26, 9, 56, 1, 879, DateTimeKind.Local).AddTicks(8196));

            migrationBuilder.CreateTable(
                name: "tbl_Members",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DocumentNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Members", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Members");

            migrationBuilder.DropColumn(
                name: "IdMember",
                table: "tbl_Subscriptions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "tbl_OutboxMessages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 26, 9, 56, 1, 879, DateTimeKind.Local).AddTicks(8196),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 4, 11, 49, 14, 787, DateTimeKind.Local).AddTicks(1210));
        }
    }
}
