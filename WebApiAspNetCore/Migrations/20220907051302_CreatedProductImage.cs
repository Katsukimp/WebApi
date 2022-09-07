using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiAspNetCore.Migrations
{
    public partial class CreatedProductImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CATEGORY_ID",
                table: "Products");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdCategory",
                table: "Products",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_CATEGORY_ID",
                table: "Products",
                column: "IdCategory",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CATEGORY_ID",
                table: "Products");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdCategory",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CATEGORY_ID",
                table: "Products",
                column: "IdCategory",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
