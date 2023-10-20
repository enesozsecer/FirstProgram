using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class son3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "InvoiceID",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "InvoiceID",
                table: "Offers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SupplierID",
                table: "Offers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CategorySupplier",
                columns: table => new
                {
                    CategoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorySupplier", x => new { x.CategoryID, x.SupplierID });
                    table.ForeignKey(
                        name: "FK_CategorySupplier_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorySupplier_Suppliers_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Suppliers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Invoices_Suppliers_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Suppliers",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_InvoiceID",
                table: "Products",
                column: "InvoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_InvoiceID",
                table: "Offers",
                column: "InvoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_SupplierID",
                table: "Offers",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_CategorySupplier_SupplierID",
                table: "CategorySupplier",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_SupplierID",
                table: "Invoices",
                column: "SupplierID");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Invoices_InvoiceID",
                table: "Offers",
                column: "InvoiceID",
                principalTable: "Invoices",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Suppliers_SupplierID",
                table: "Offers",
                column: "SupplierID",
                principalTable: "Suppliers",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Invoices_InvoiceID",
                table: "Products",
                column: "InvoiceID",
                principalTable: "Invoices",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Invoices_InvoiceID",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Suppliers_SupplierID",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Invoices_InvoiceID",
                table: "Products");

            migrationBuilder.DropTable(
                name: "CategorySupplier");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Products_InvoiceID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Offers_InvoiceID",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_SupplierID",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "InvoiceID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "InvoiceID",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "SupplierID",
                table: "Offers");
        }
    }
}
