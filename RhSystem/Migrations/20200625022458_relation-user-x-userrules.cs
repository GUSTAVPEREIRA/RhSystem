namespace RhSystem.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class relationuserxuserrules : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbUsers_TbUserRules_RulesId",
                table: "TbUsers");

            migrationBuilder.AlterColumn<int>(
                name: "RulesId",
                table: "TbUsers",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TbUsers_TbUserRules_RulesId",
                table: "TbUsers",
                column: "RulesId",
                principalTable: "TbUserRules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbUsers_TbUserRules_RulesId",
                table: "TbUsers");

            migrationBuilder.AlterColumn<int>(
                name: "RulesId",
                table: "TbUsers",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_TbUsers_TbUserRules_RulesId",
                table: "TbUsers",
                column: "RulesId",
                principalTable: "TbUserRules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
