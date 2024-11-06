using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmCart.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "carttable",
                columns: table => new
                {
                    cart_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    cust_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carttable", x => x.cart_id);
                });

            migrationBuilder.CreateTable(
                name: "custtable",
                columns: table => new
                {
                    cust_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cust_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cust_phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cust_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cust_password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    confirm_password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Is_Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_custtable", x => x.cust_id);
                });

            migrationBuilder.CreateTable(
                name: "orderitemtable",
                columns: table => new
                {
                    item_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    item_ord_no = table.Column<int>(type: "int", nullable: false),
                    cust_id = table.Column<int>(type: "int", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    product_price = table.Column<int>(type: "int", nullable: false),
                    product_quantity = table.Column<int>(type: "int", nullable: false),
                    Is_Available = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderitemtable", x => x.item_id);
                });

            migrationBuilder.CreateTable(
                name: "ordertable",
                columns: table => new
                {
                    ord_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ord_no = table.Column<int>(type: "int", nullable: false),
                    ord_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    total_amount = table.Column<int>(type: "int", nullable: false),
                    ord_address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cust_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordertable", x => x.ord_id);
                });

            migrationBuilder.CreateTable(
                name: "producttable",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    brand_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    product_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    product_price = table.Column<int>(type: "int", nullable: false),
                    product_quantity = table.Column<int>(type: "int", nullable: false),
                    sup_id = table.Column<int>(type: "int", nullable: false),
                    imagepath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_available = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_producttable", x => x.product_id);
                });

            migrationBuilder.CreateTable(
                name: "suptable",
                columns: table => new
                {
                    sup_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sup_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sup_phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sup_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sup_password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    confirm_password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Is_Valid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_suptable", x => x.sup_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "carttable");

            migrationBuilder.DropTable(
                name: "custtable");

            migrationBuilder.DropTable(
                name: "orderitemtable");

            migrationBuilder.DropTable(
                name: "ordertable");

            migrationBuilder.DropTable(
                name: "producttable");

            migrationBuilder.DropTable(
                name: "suptable");
        }
    }
}
