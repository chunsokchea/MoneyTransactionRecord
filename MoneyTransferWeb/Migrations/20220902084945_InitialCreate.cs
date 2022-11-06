using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyTransferWeb.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Capitals",
                columns: table => new
                {
                    CapitalID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CAmountR = table.Column<float>(type: "real", nullable: false),
                    CAmountS = table.Column<float>(type: "real", nullable: false),
                    UAmountR = table.Column<float>(type: "real", nullable: false),
                    UAmountS = table.Column<float>(type: "real", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Capitals", x => x.CapitalID);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientSex = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientID);
                });

            migrationBuilder.CreateTable(
                name: "Institutions",
                columns: table => new
                {
                    InstitutionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    INameKH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    INameEN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDetail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutions", x => x.InstitutionID);
                });

            migrationBuilder.CreateTable(
                name: "Balances",
                columns: table => new
                {
                    BalanceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BAmountR = table.Column<float>(type: "real", nullable: false),
                    BAmountS = table.Column<float>(type: "real", nullable: false),
                    CapitalID = table.Column<int>(type: "int", nullable: false),
                    InstitutionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balances", x => x.BalanceID);
                    table.ForeignKey(
                        name: "FK_Balances_Capitals_CapitalID",
                        column: x => x.CapitalID,
                        principalTable: "Capitals",
                        principalColumn: "CapitalID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Balances_Institutions_InstitutionID",
                        column: x => x.InstitutionID,
                        principalTable: "Institutions",
                        principalColumn: "InstitutionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientTransactions",
                columns: table => new
                {
                    ClientTransactionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TAmountR = table.Column<float>(type: "real", nullable: false),
                    TAmountS = table.Column<float>(type: "real", nullable: false),
                    TransactionType = table.Column<bool>(type: "bit", nullable: false),
                    Dept = table.Column<bool>(type: "bit", nullable: false),
                    DeptAmountR = table.Column<float>(type: "real", nullable: false),
                    DeptAmountS = table.Column<float>(type: "real", nullable: false),
                    TransactionDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    BalanceID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientTransactions", x => x.ClientTransactionID);
                    table.ForeignKey(
                        name: "FK_ClientTransactions_Balances_BalanceID",
                        column: x => x.BalanceID,
                        principalTable: "Balances",
                        principalColumn: "BalanceID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientTransactions_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WithdrawBalances",
                columns: table => new
                {
                    WithdrawBalanceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WAmountR = table.Column<float>(type: "real", nullable: false),
                    WAmountS = table.Column<float>(type: "real", nullable: false),
                    WithdrawDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BalanceID = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "PayDepts",
                columns: table => new
                {
                    PayDeptID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PAmountR = table.Column<float>(type: "real", nullable: false),
                    PAmountS = table.Column<float>(type: "real", nullable: false),
                    Paid = table.Column<bool>(type: "bit", nullable: false),
                    PayDeptDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientTransactionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayDepts", x => x.PayDeptID);
                    table.ForeignKey(
                        name: "FK_PayDepts_ClientTransactions_ClientTransactionID",
                        column: x => x.ClientTransactionID,
                        principalTable: "ClientTransactions",
                        principalColumn: "ClientTransactionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Balances_CapitalID",
                table: "Balances",
                column: "CapitalID");

            migrationBuilder.CreateIndex(
                name: "IX_Balances_InstitutionID",
                table: "Balances",
                column: "InstitutionID");

            migrationBuilder.CreateIndex(
                name: "IX_ClientTransactions_BalanceID",
                table: "ClientTransactions",
                column: "BalanceID");

            migrationBuilder.CreateIndex(
                name: "IX_ClientTransactions_ClientID",
                table: "ClientTransactions",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_PayDepts_ClientTransactionID",
                table: "PayDepts",
                column: "ClientTransactionID");

            migrationBuilder.CreateIndex(
                name: "IX_WithdrawBalances_BalanceID",
                table: "WithdrawBalances",
                column: "BalanceID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PayDepts");

            migrationBuilder.DropTable(
                name: "WithdrawBalances");

            migrationBuilder.DropTable(
                name: "ClientTransactions");

            migrationBuilder.DropTable(
                name: "Balances");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Capitals");

            migrationBuilder.DropTable(
                name: "Institutions");
        }
    }
}
