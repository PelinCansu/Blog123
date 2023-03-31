using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog123.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _102 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasCategory",
                table: "Posts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 26, 0, 36, 18, 297, DateTimeKind.Local).AddTicks(4465),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 25, 23, 46, 6, 320, DateTimeKind.Local).AddTicks(8137));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 26, 0, 36, 18, 297, DateTimeKind.Local).AddTicks(4084),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 25, 23, 46, 6, 320, DateTimeKind.Local).AddTicks(7418));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasCategory",
                table: "Posts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 25, 23, 46, 6, 320, DateTimeKind.Local).AddTicks(8137),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 26, 0, 36, 18, 297, DateTimeKind.Local).AddTicks(4465));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 25, 23, 46, 6, 320, DateTimeKind.Local).AddTicks(7418),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 26, 0, 36, 18, 297, DateTimeKind.Local).AddTicks(4084));
        }
    }
}
