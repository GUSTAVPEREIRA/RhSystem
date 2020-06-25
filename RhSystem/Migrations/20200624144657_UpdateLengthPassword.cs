using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RhSystem.Migrations
{
    public partial class UpdateLengthPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "TbUsers",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 24, 11, 46, 56, 606, DateTimeKind.Local).AddTicks(3962),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2020, 6, 24, 11, 31, 59, 793, DateTimeKind.Local).AddTicks(8847));

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "TbUsers",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "TbUsers",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 24, 11, 46, 56, 599, DateTimeKind.Local).AddTicks(6418),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2020, 6, 24, 11, 31, 59, 788, DateTimeKind.Local).AddTicks(8258));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "TbUsers",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 24, 11, 31, 59, 793, DateTimeKind.Local).AddTicks(8847),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 24, 11, 46, 56, 606, DateTimeKind.Local).AddTicks(3962));

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "TbUsers",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "TbUsers",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 24, 11, 31, 59, 788, DateTimeKind.Local).AddTicks(8258),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 24, 11, 46, 56, 599, DateTimeKind.Local).AddTicks(6418));
        }
    }
}
