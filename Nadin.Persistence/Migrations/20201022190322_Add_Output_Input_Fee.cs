using Microsoft.EntityFrameworkCore.Migrations;

namespace Nadin.Persistence.Migrations
{
    public partial class Add_Output_Input_Fee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "InputFee",
                table: "Banks",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "OutputFee",
                table: "Banks",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InputFee",
                table: "Banks");

            migrationBuilder.DropColumn(
                name: "OutputFee",
                table: "Banks");
        }
    }
}
