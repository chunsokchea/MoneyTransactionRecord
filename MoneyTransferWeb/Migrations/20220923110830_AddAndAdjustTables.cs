using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyTransferWeb.Migrations
{
    public partial class AddAndAdjustTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Debts_Clients_ClientID",
                table: "Debts");

            migrationBuilder.DropForeignKey(
                name: "FK_ReturnTransactions_Clients_ClientID",
                table: "ReturnTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_ReturnTransactions_ClientTransactions_ClientTransactionID",
                table: "ReturnTransactions");

            migrationBuilder.DropTable(
                name: "ClientTransactions");

            migrationBuilder.DropIndex(
                name: "IX_ReturnTransactions_ClientTransactionID",
                table: "ReturnTransactions");

            migrationBuilder.DropColumn(
                name: "ClientTransactionID",
                table: "ReturnTransactions");

            migrationBuilder.DropColumn(
                name: "DDate",
                table: "Debts");

            migrationBuilder.RenameColumn(
                name: "ClientID",
                table: "ReturnTransactions",
                newName: "TransactionID");

            migrationBuilder.RenameIndex(
                name: "IX_ReturnTransactions_ClientID",
                table: "ReturnTransactions",
                newName: "IX_ReturnTransactions_TransactionID");

            migrationBuilder.RenameColumn(
                name: "ClientID",
                table: "Debts",
                newName: "TransactionID");

            migrationBuilder.RenameIndex(
                name: "IX_Debts_ClientID",
                table: "Debts",
                newName: "IX_Debts_TransactionID");

            migrationBuilder.AddColumn<bool>(
                name: "DebtOwe",
                table: "Debts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalR = table.Column<float>(type: "real", nullable: false),
                    TotalS = table.Column<float>(type: "real", nullable: false),
                    TDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    CapitalID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionID);
                    table.ForeignKey(
                        name: "FK_Transactions_Capitals_CapitalID",
                        column: x => x.CapitalID,
                        principalTable: "Capitals",
                        principalColumn: "CapitalID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionChilds",
                columns: table => new
                {
                    ChildID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TAmountR = table.Column<float>(type: "real", nullable: false),
                    TAmountS = table.Column<float>(type: "real", nullable: false),
                    TType = table.Column<bool>(type: "bit", nullable: false),
                    TransactionID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionChilds", x => x.ChildID);
                    table.ForeignKey(
                        name: "FK_TransactionChilds_Transactions_TransactionID",
                        column: x => x.TransactionID,
                        principalTable: "Transactions",
                        principalColumn: "TransactionID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransactionChilds_TransactionID",
                table: "TransactionChilds",
                column: "TransactionID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CapitalID",
                table: "Transactions",
                column: "CapitalID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ClientID",
                table: "Transactions",
                column: "ClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Debts_Transactions_TransactionID",
                table: "Debts",
                column: "TransactionID",
                principalTable: "Transactions",
                principalColumn: "TransactionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnTransactions_Transactions_TransactionID",
                table: "ReturnTransactions",
                column: "TransactionID",
                principalTable: "Transactions",
                principalColumn: "TransactionID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Debts_Transactions_TransactionID",
                table: "Debts");

            migrationBuilder.DropForeignKey(
                name: "FK_ReturnTransactions_Transactions_TransactionID",
                table: "ReturnTransactions");

            migrationBuilder.DropTable(
                name: "TransactionChilds");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropColumn(
                name: "DebtOwe",
                table: "Debts");

            migrationBuilder.RenameColumn(
                name: "TransactionID",
                table: "ReturnTransactions",
                newName: "ClientID");

            migrationBuilder.RenameIndex(
                name: "IX_ReturnTransactions_TransactionID",
                table: "ReturnTransactions",
                newName: "IX_ReturnTransactions_ClientID");

            migrationBuilder.RenameColumn(
                name: "TransactionID",
                table: "Debts",
                newName: "ClientID");

            migrationBuilder.RenameIndex(
                name: "IX_Debts_TransactionID",
                table: "Debts",
                newName: "IX_Debts_ClientID");

            migrationBuilder.AddColumn<int>(
                name: "ClientTransactionID",
                table: "ReturnTransactions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DDate",
                table: "Debts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "ClientTransactions",
                columns: table => new
                {
                    ClientTransactionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CapitalID = table.Column<int>(type: "int", nullable: false),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    Dept = table.Column<bool>(type: "bit", nullable: false),
                    DeptAmountR = table.Column<float>(type: "real", nullable: false),
                    DeptAmountS = table.Column<float>(type: "real", nullable: false),
                    TAmountR = table.Column<float>(type: "real", nullable: false),
                    TAmountS = table.Column<float>(type: "real", nullable: false),
                    TDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionType = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientTransactions", x => x.ClientTransactionID);
                    table.ForeignKey(
                        name: "FK_ClientTransactions_Capitals_CapitalID",
                        column: x => x.CapitalID,
                        principalTable: "Capitals",
                        principalColumn: "CapitalID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientTransactions_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReturnTransactions_ClientTransactionID",
                table: "ReturnTransactions",
                column: "ClientTransactionID");

            migrationBuilder.CreateIndex(
                name: "IX_ClientTransactions_CapitalID",
                table: "ClientTransactions",
                column: "CapitalID");

            migrationBuilder.CreateIndex(
                name: "IX_ClientTransactions_ClientID",
                table: "ClientTransactions",
                column: "ClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Debts_Clients_ClientID",
                table: "Debts",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "ClientID",
                onDelete: ReferentialAction.Cascade);

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
    }
}
