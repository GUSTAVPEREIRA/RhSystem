using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace RhSystem.Migrations
{
    public partial class createuserrules : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "TbUsers",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 25, 0, 0, 0, 0, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2020, 6, 24, 11, 46, 56, 606, DateTimeKind.Local).AddTicks(3962));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "TbUsers",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 25, 0, 0, 0, 0, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2020, 6, 24, 11, 46, 56, 599, DateTimeKind.Local).AddTicks(6418));

            migrationBuilder.AddColumn<int>(
                name: "RulesId",
                table: "TbUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TbUserRules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    IsAdmin = table.Column<bool>(nullable: false),
                    PhysicalExclusion = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 6, 25, 0, 0, 0, 0, DateTimeKind.Utc)),
                    UpdatedAt = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 6, 25, 0, 0, 0, 0, DateTimeKind.Utc)),
                    DeletedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbUserRules", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbUsers_RulesId",
                table: "TbUsers",
                column: "RulesId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbUsers_TbUserRules_RulesId",
                table: "TbUsers",
                column: "RulesId",
                principalTable: "TbUserRules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbUsers_TbUserRules_RulesId",
                table: "TbUsers");

            migrationBuilder.DropTable(
                name: "TbUserRules");

            migrationBuilder.DropIndex(
                name: "IX_TbUsers_RulesId",
                table: "TbUsers");

            migrationBuilder.DropColumn(
                name: "RulesId",
                table: "TbUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "TbUsers",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 24, 11, 46, 56, 606, DateTimeKind.Local).AddTicks(3962),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 25, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "TbUsers",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2020, 6, 24, 11, 46, 56, 599, DateTimeKind.Local).AddTicks(6418),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 6, 25, 0, 0, 0, 0, DateTimeKind.Utc));
        }
    }
}
