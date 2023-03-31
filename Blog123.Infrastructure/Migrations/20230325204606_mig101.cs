using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog123.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig101 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                oldDefaultValue: new DateTime(2023, 3, 25, 22, 34, 53, 772, DateTimeKind.Local).AddTicks(4529));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 25, 23, 46, 6, 320, DateTimeKind.Local).AddTicks(7418),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 25, 22, 34, 53, 772, DateTimeKind.Local).AddTicks(3602));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasCategory",
                table: "Posts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 25, 22, 34, 53, 772, DateTimeKind.Local).AddTicks(4529),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 25, 23, 46, 6, 320, DateTimeKind.Local).AddTicks(8137));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 25, 22, 34, 53, 772, DateTimeKind.Local).AddTicks(3602),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 25, 23, 46, 6, 320, DateTimeKind.Local).AddTicks(7418));
        }
    }
}
