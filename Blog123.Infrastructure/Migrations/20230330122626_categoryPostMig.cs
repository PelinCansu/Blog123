using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog123.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class categoryPostMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "CategoryPost",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "CategoryPost",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "CategoryPost",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "CategoryPost",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "CategoryPost",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 30, 15, 26, 26, 510, DateTimeKind.Local).AddTicks(6640),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 30, 15, 21, 59, 809, DateTimeKind.Local).AddTicks(5292));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 30, 15, 26, 26, 510, DateTimeKind.Local).AddTicks(5962),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 30, 15, 21, 59, 809, DateTimeKind.Local).AddTicks(4914));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CategoryPost");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "CategoryPost");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "CategoryPost");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "CategoryPost");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "CategoryPost");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 30, 15, 21, 59, 809, DateTimeKind.Local).AddTicks(5292),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 30, 15, 26, 26, 510, DateTimeKind.Local).AddTicks(6640));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 30, 15, 21, 59, 809, DateTimeKind.Local).AddTicks(4914),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 30, 15, 26, 26, 510, DateTimeKind.Local).AddTicks(5962));
        }
    }
}
