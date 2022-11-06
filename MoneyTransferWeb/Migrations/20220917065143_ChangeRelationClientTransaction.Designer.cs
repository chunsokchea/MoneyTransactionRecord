﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoneyTransferWeb.Data;

#nullable disable

namespace MoneyTransferWeb.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220917065143_ChangeRelationClientTransaction")]
    partial class ChangeRelationClientTransaction
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MoneyTransferWeb.Models.Balance", b =>
                {
                    b.Property<int>("BalanceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BalanceID"), 1L, 1);

                    b.Property<float>("BAmountR")
                        .HasColumnType("real");

                    b.Property<float>("BAmountS")
                        .HasColumnType("real");

                    b.Property<int>("CapitalID")
                        .HasColumnType("int");

                    b.Property<int>("InstitutionID")
                        .HasColumnType("int");

                    b.HasKey("BalanceID");

                    b.HasIndex("CapitalID");

                    b.HasIndex("InstitutionID");

                    b.ToTable("Balances");
                });

            modelBuilder.Entity("MoneyTransferWeb.Models.Capital", b =>
                {
                    b.Property<int>("CapitalID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CapitalID"), 1L, 1);

                    b.Property<float>("CAmountR")
                        .HasColumnType("real");

                    b.Property<float>("CAmountS")
                        .HasColumnType("real");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("CapitalID");

                    b.ToTable("Capitals");
                });

            modelBuilder.Entity("MoneyTransferWeb.Models.Client", b =>
                {
                    b.Property<int>("ClientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientID"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ClientSex")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Detail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientID");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("MoneyTransferWeb.Models.ClientTransaction", b =>
                {
                    b.Property<int>("ClientTransactionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientTransactionID"), 1L, 1);

                    b.Property<int?>("BalanceID")
                        .HasColumnType("int");

                    b.Property<int>("CapitalID")
                        .HasColumnType("int");

                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.Property<bool>("Dept")
                        .HasColumnType("bit");

                    b.Property<float>("DeptAmountR")
                        .HasColumnType("real");

                    b.Property<float>("DeptAmountS")
                        .HasColumnType("real");

                    b.Property<float>("TAmountR")
                        .HasColumnType("real");

                    b.Property<float>("TAmountS")
                        .HasColumnType("real");

                    b.Property<string>("TDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TransactionDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("TransactionType")
                        .HasColumnType("bit");

                    b.HasKey("ClientTransactionID");

                    b.HasIndex("BalanceID");

                    b.HasIndex("CapitalID");

                    b.HasIndex("ClientID");

                    b.ToTable("ClientTransactions");
                });

            modelBuilder.Entity("MoneyTransferWeb.Models.Institution", b =>
                {
                    b.Property<int>("InstitutionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstitutionID"), 1L, 1);

                    b.Property<string>("IDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("INameEN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("INameKH")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InstitutionID");

                    b.ToTable("Institutions");
                });

            modelBuilder.Entity("MoneyTransferWeb.Models.ReturnTransaction", b =>
                {
                    b.Property<int>("ReturnID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReturnID"), 1L, 1);

                    b.Property<int>("ClientTransactionID")
                        .HasColumnType("int");

                    b.Property<bool>("Paid")
                        .HasColumnType("bit");

                    b.Property<float>("RAmountR")
                        .HasColumnType("real");

                    b.Property<float>("RAmountS")
                        .HasColumnType("real");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ReturnID");

                    b.HasIndex("ClientTransactionID");

                    b.ToTable("PayDepts");
                });

            modelBuilder.Entity("MoneyTransferWeb.Models.WithdrawBalance", b =>
                {
                    b.Property<int>("WithdrawBalanceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WithdrawBalanceID"), 1L, 1);

                    b.Property<int>("BalanceID")
                        .HasColumnType("int");

                    b.Property<float>("WAmountR")
                        .HasColumnType("real");

                    b.Property<float>("WAmountS")
                        .HasColumnType("real");

                    b.Property<string>("WDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("WithdrawDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("WithdrawBalanceID");

                    b.HasIndex("BalanceID");

                    b.ToTable("WithdrawBalances");
                });

            modelBuilder.Entity("MoneyTransferWeb.Models.Balance", b =>
                {
                    b.HasOne("MoneyTransferWeb.Models.Capital", "Capitals")
                        .WithMany("Balances")
                        .HasForeignKey("CapitalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoneyTransferWeb.Models.Institution", "Institution")
                        .WithMany("Balances")
                        .HasForeignKey("InstitutionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Capitals");

                    b.Navigation("Institution");
                });

            modelBuilder.Entity("MoneyTransferWeb.Models.ClientTransaction", b =>
                {
                    b.HasOne("MoneyTransferWeb.Models.Balance", null)
                        .WithMany("ClientTransactions")
                        .HasForeignKey("BalanceID");

                    b.HasOne("MoneyTransferWeb.Models.Capital", "Capital")
                        .WithMany()
                        .HasForeignKey("CapitalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoneyTransferWeb.Models.Client", "Client")
                        .WithMany("ClientTransactions")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Capital");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("MoneyTransferWeb.Models.ReturnTransaction", b =>
                {
                    b.HasOne("MoneyTransferWeb.Models.ClientTransaction", "ClientTransaction")
                        .WithMany("ReturnTransactions")
                        .HasForeignKey("ClientTransactionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClientTransaction");
                });

            modelBuilder.Entity("MoneyTransferWeb.Models.WithdrawBalance", b =>
                {
                    b.HasOne("MoneyTransferWeb.Models.Balance", "Balance")
                        .WithMany("WithdrawBalamces")
                        .HasForeignKey("BalanceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Balance");
                });

            modelBuilder.Entity("MoneyTransferWeb.Models.Balance", b =>
                {
                    b.Navigation("ClientTransactions");

                    b.Navigation("WithdrawBalamces");
                });

            modelBuilder.Entity("MoneyTransferWeb.Models.Capital", b =>
                {
                    b.Navigation("Balances");
                });

            modelBuilder.Entity("MoneyTransferWeb.Models.Client", b =>
                {
                    b.Navigation("ClientTransactions");
                });

            modelBuilder.Entity("MoneyTransferWeb.Models.ClientTransaction", b =>
                {
                    b.Navigation("ReturnTransactions");
                });

            modelBuilder.Entity("MoneyTransferWeb.Models.Institution", b =>
                {
                    b.Navigation("Balances");
                });
#pragma warning restore 612, 618
        }
    }
}
