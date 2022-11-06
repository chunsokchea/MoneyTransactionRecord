using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyTransferWeb.Migrations
{
    public partial class AddTableDept : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReturnTransactions_ClientTransactions_ClientTransactionID",
                table: "ReturnTransactions");

            migrationBuilder.AlterColumn<int>(
                name: "ClientTransactionID",
                table: "ReturnTransactions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ClientID",
                table: "ReturnTransactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Debts",
                columns: table => new
                {
                    DebtID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    DAmountR = table.Column<float>(type: "real", nullable: false),
                    DAmountS = table.Column<float>(type: "real", nullable: false),
                    DDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Debts", x => x.DebtID);
                    table.ForeignKey(
                        name: "FK_Debts_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReturnTransactions_ClientID",
                table: "ReturnTransactions",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Debts_ClientID",
                table: "Debts",
                column: "ClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnTransactions_Clients_ClientID",
                table: "ReturnTransactions",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "ClientID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnTransactions_ClientTransactions_ClientTransactionID",
                table: "ReturnTransactions",
                column: "ClientTransactionID",
                principalTable: "ClientTransactions",
                principalColumn: "ClientTransactionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReturnTransactions_Clients_ClientID",
                table: "ReturnTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_ReturnTransactions_ClientTransactions_ClientTransactionID",
                table: "ReturnTransactions");

            migrationBuilder.DropTable(
                name: "Debts");

            migrationBuilder.DropIndex(
                name: "IX_ReturnTransactions_ClientID",
                table: "ReturnTransactions");

            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "ReturnTransactions");

            migrationBuilder.AlterColumn<int>(
                name: "ClientTransactionID",
                table: "ReturnTransactions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnTransactions_ClientTransactions_ClientTransactionID",
                table: "ReturnTransactions",
                column: "ClientTransactionID",
                principalTable: "ClientTransactions",
                principalColumn: "ClientTransactionID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
