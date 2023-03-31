﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog123.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig100 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryPost_Categories_CategoriesId",
                table: "CategoryPost");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryPost_Posts_PostsId",
                table: "CategoryPost");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryPost",
                table: "CategoryPost");

            migrationBuilder.DropIndex(
                name: "IX_CategoryPost_PostsId",
                table: "CategoryPost");

            migrationBuilder.RenameColumn(
                name: "PostsId",
                table: "CategoryPost",
                newName: "PostId");

            migrationBuilder.RenameColumn(
                name: "CategoriesId",
                table: "CategoryPost",
                newName: "CategoryId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 25, 22, 34, 53, 772, DateTimeKind.Local).AddTicks(4529),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 24, 14, 26, 36, 501, DateTimeKind.Local).AddTicks(589));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 25, 22, 34, 53, 772, DateTimeKind.Local).AddTicks(3602),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 24, 14, 26, 36, 501, DateTimeKind.Local).AddTicks(226));

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryPost",
                table: "CategoryPost",
                columns: new[] { "PostId", "CategoryId" });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryPost_CategoryId",
                table: "CategoryPost",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryPost_Categories_CategoryId",
                table: "CategoryPost",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryPost_Posts_PostId",
                table: "CategoryPost",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryPost_Categories_CategoryId",
                table: "CategoryPost");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryPost_Posts_PostId",
                table: "CategoryPost");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryPost",
                table: "CategoryPost");

            migrationBuilder.DropIndex(
                name: "IX_CategoryPost_CategoryId",
                table: "CategoryPost");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "CategoryPost",
                newName: "CategoriesId");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "CategoryPost",
                newName: "PostsId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 24, 14, 26, 36, 501, DateTimeKind.Local).AddTicks(589),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 25, 22, 34, 53, 772, DateTimeKind.Local).AddTicks(4529));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 24, 14, 26, 36, 501, DateTimeKind.Local).AddTicks(226),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 25, 22, 34, 53, 772, DateTimeKind.Local).AddTicks(3602));

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryPost",
                table: "CategoryPost",
                columns: new[] { "CategoriesId", "PostsId" });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryPost_PostsId",
                table: "CategoryPost",
                column: "PostsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryPost_Categories_CategoriesId",
                table: "CategoryPost",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryPost_Posts_PostsId",
                table: "CategoryPost",
                column: "PostsId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}