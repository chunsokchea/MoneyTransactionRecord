using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyTransferWeb.Migrations
{
    public partial class ChangeWidrawal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientTransactions_Balances_BalanceID",
                table: "ClientTransactions");

            migrationBuilder.DropTable(
                name: "WithdrawBalances");

            migrationBuilder.DropIndex(
                name: "IX_ClientTransactions_BalanceID",
                table: "ClientTransactions");

            migrationBuilder.DropColumn(
                name: "BalanceID",
                table: "ClientTransactions");

            migrationBuilder.CreateTable(
                name: "Withdraws",
                columns: table => new
                {
                    WithdrawID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WAmountR = table.Column<float>(type: "real", nullable: false),
                    WAmountS = table.Column<float>(type: "real", nullable: false),
                    WithdrawDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CapitalID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Withdraws", x => x.WithdrawID);
                    table.ForeignKey(
                        name: "FK_Withdraws_Capitals_CapitalID",
                        column: x => x.CapitalID,
                        principalTable: "Capitals",
                        principalColumn: "CapitalID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Withdraws_CapitalID",
                table: "Withdraws",
                column: "CapitalID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Withdraws");

            migrationBuilder.AddColumn<int>(
                name: "BalanceID",
                table: "ClientTransactions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WithdrawBalances",
                columns: table => new
                {
                    WithdrawBalanceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BalanceID = table.Column<int>(type: "int", nullable: false),
                    WAmountR = table.Column<float>(type: "real", nullable: false),
                    WAmountS = table.Column<float>(type: "real", nullable: false),
                    WDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WithdrawDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WithdrawBalances", x => x.WithdrawBalanceID);
                    table.ForeignKey(
                        name: "FK_WithdrawBalances_Balances_BalanceID",
                        column: x => x.BalanceID,
                        principalTable: "Balances",
                        principalColumn: "BalanceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientTransactions_BalanceID",
                table: "ClientTransactions",
                column: "BalanceID");

            migrationBuilder.CreateIndex(
                name: "IX_WithdrawBalances_BalanceID",
                table: "WithdrawBalances",
                column: "BalanceID");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientTransactions_Balances_BalanceID",
                table: "ClientTransactions",
                column: "BalanceID",
                principalTable: "Balances",
                principalColumn: "BalanceID");
        }
    }
}
