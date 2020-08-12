using Microsoft.EntityFrameworkCore.Migrations;

namespace LekarnaApi.Data.Migrations
{
    public partial class PharmacyDbModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pharmacy_AspNetUsers_UserId",
                table: "Pharmacy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pharmacy",
                table: "Pharmacy");

            migrationBuilder.RenameTable(
                name: "Pharmacy",
                newName: "Pharmacies");

            migrationBuilder.RenameIndex(
                name: "IX_Pharmacy_UserId",
                table: "Pharmacies",
                newName: "IX_Pharmacies_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Pharmacies",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Pharmacies",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Pharmacies",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pharmacies",
                table: "Pharmacies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pharmacies_AspNetUsers_UserId",
                table: "Pharmacies",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pharmacies_AspNetUsers_UserId",
                table: "Pharmacies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pharmacies",
                table: "Pharmacies");

            migrationBuilder.RenameTable(
                name: "Pharmacies",
                newName: "Pharmacy");

            migrationBuilder.RenameIndex(
                name: "IX_Pharmacies_UserId",
                table: "Pharmacy",
                newName: "IX_Pharmacy_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Pharmacy",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Pharmacy",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Pharmacy",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pharmacy",
                table: "Pharmacy",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pharmacy_AspNetUsers_UserId",
                table: "Pharmacy",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
