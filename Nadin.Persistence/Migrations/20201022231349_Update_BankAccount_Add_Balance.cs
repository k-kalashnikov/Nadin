using Microsoft.EntityFrameworkCore.Migrations;

namespace Nadin.Persistence.Migrations
{
    public partial class Update_BankAccount_Add_Balance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "BankAccounts",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                table: "BankAccounts");
        }
    }
}
