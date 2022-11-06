using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyTransferWeb.Migrations
{
    public partial class PaydepttoReturns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PayDepts_ClientTransactions_ClientTransactionID",
                table: "PayDepts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PayDepts",
                table: "PayDepts");

            migrationBuilder.RenameTable(
                name: "PayDepts",
                newName: "ReturnTransactions");

            migrationBuilder.RenameIndex(
                name: "IX_PayDepts_ClientTransactionID",
                table: "ReturnTransactions",
                newName: "IX_ReturnTransactions_ClientTransactionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReturnTransactions",
                table: "ReturnTransactions",
                column: "ReturnID");

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnTransactions_ClientTransactions_ClientTransactionID",
                table: "ReturnTransactions",
                column: "ClientTransactionID",
                principalTable: "ClientTransactions",
                principalColumn: "ClientTransactionID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReturnTransactions_ClientTransactions_ClientTransactionID",
                table: "ReturnTransactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReturnTransactions",
                table: "ReturnTransactions");

            migrationBuilder.RenameTable(
                name: "ReturnTransactions",
                newName: "PayDepts");

            migrationBuilder.RenameIndex(
                name: "IX_ReturnTransactions_ClientTransactionID",
                table: "PayDepts",
                newName: "IX_PayDepts_ClientTransactionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PayDepts",
                table: "PayDepts",
                column: "ReturnID");

            migrationBuilder.AddForeignKey(
                name: "FK_PayDepts_ClientTransactions_ClientTransactionID",
                table: "PayDepts",
                column: "ClientTransactionID",
                principalTable: "ClientTransactions",
                principalColumn: "ClientTransactionID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
