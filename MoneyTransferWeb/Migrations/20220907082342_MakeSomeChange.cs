using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyTransferWeb.Migrations
{
    public partial class MakeSomeChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UAmountR",
                table: "Capitals");

            migrationBuilder.DropColumn(
                name: "UAmountS",
                table: "Capitals");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Detail",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNo",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Detail",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "PhoneNo",
                table: "Clients");

            migrationBuilder.AddColumn<float>(
                name: "UAmountR",
                table: "Capitals",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "UAmountS",
                table: "Capitals",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
