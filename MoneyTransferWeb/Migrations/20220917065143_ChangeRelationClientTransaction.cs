using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyTransferWeb.Migrations
{
    public partial class ChangeRelationClientTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientTransactions_Balances_BalanceID",
                table: "ClientTransactions");

            migrationBuilder.RenameColumn(
                name: "PayDeptDate",
                table: "PayDepts",
                newName: "ReturnDate");

            migrationBuilder.RenameColumn(
                name: "PAmountS",
                table: "PayDepts",
                newName: "RAmountS");

            migrationBuilder.RenameColumn(
                name: "PAmountR",
                table: "PayDepts",
                newName: "RAmountR");

            migrationBuilder.RenameColumn(
                name: "PayDeptID",
                table: "PayDepts",
                newName: "ReturnID");

            migrationBuilder.AlterColumn<int>(
                name: "BalanceID",
                table: "ClientTransactions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CapitalID",
                table: "ClientTransactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TDetail",
                table: "ClientTransactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientTransactions_CapitalID",
                table: "ClientTransactions",
                column: "CapitalID");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientTransactions_Balances_BalanceID",
                table: "ClientTransactions",
                column: "BalanceID",
                principalTable: "Balances",
                principalColumn: "BalanceID");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientTransactions_Capitals_CapitalID",
                table: "ClientTransactions",
                column: "CapitalID",
                principalTable: "Capitals",
                principalColumn: "CapitalID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientTransactions_Balances_BalanceID",
                table: "ClientTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientTransactions_Capitals_CapitalID",
                table: "ClientTransactions");

            migrationBuilder.DropIndex(
                name: "IX_ClientTransactions_CapitalID",
                table: "ClientTransactions");

            migrationBuilder.DropColumn(
                name: "CapitalID",
                table: "ClientTransactions");

            migrationBuilder.DropColumn(
                name: "TDetail",
                table: "ClientTransactions");

            migrationBuilder.RenameColumn(
                name: "ReturnDate",
                table: "PayDepts",
                newName: "PayDeptDate");

            migrationBuilder.RenameColumn(
                name: "RAmountS",
                table: "PayDepts",
                newName: "PAmountS");

            migrationBuilder.RenameColumn(
                name: "RAmountR",
                table: "PayDepts",
                newName: "PAmountR");

            migrationBuilder.RenameColumn(
                name: "ReturnID",
                table: "PayDepts",
                newName: "PayDeptID");

            migrationBuilder.AlterColumn<int>(
                name: "BalanceID",
                table: "ClientTransactions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientTransactions_Balances_BalanceID",
                table: "ClientTransactions",
                column: "BalanceID",
                principalTable: "Balances",
                principalColumn: "BalanceID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
