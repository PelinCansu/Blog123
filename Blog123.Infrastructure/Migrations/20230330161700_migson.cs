using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog123.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class migson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 30, 19, 17, 0, 805, DateTimeKind.Local).AddTicks(1519),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 30, 15, 26, 26, 510, DateTimeKind.Local).AddTicks(6640));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 30, 19, 17, 0, 805, DateTimeKind.Local).AddTicks(1142),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 30, 15, 26, 26, 510, DateTimeKind.Local).AddTicks(5962));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 30, 15, 26, 26, 510, DateTimeKind.Local).AddTicks(6640),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 30, 19, 17, 0, 805, DateTimeKind.Local).AddTicks(1519));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 30, 15, 26, 26, 510, DateTimeKind.Local).AddTicks(5962),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 30, 19, 17, 0, 805, DateTimeKind.Local).AddTicks(1142));
        }
    }
}
