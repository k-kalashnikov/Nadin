using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nadin.Persistence.Migrations
{
    public partial class Update_Bank_Account : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "AccountId",
                table: "BankAccounts",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AccountId",
                table: "BankAccounts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid));
        }
    }
}
