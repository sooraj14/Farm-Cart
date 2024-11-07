using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmCart.Migrations
{
    /// <inheritdoc />
    public partial class cust : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_suptable",
                table: "suptable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_producttable",
                table: "producttable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ordertable",
                table: "ordertable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orderitemtable",
                table: "orderitemtable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_custtable",
                table: "custtable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_carttable",
                table: "carttable");

            migrationBuilder.RenameTable(
                name: "suptable",
                newName: "Suppliers");

            migrationBuilder.RenameTable(
                name: "producttable",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "ordertable",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "orderitemtable",
                newName: "OrderItems");

            migrationBuilder.RenameTable(
                name: "custtable",
                newName: "Customers");

            migrationBuilder.RenameTable(
                name: "carttable",
                newName: "Carts");

            migrationBuilder.RenameColumn(
                name: "cust_phone",
                table: "Customers",
                newName: "CustPhone");

            migrationBuilder.RenameColumn(
                name: "cust_password",
                table: "Customers",
                newName: "CustPassword");

            migrationBuilder.RenameColumn(
                name: "cust_name",
                table: "Customers",
                newName: "CustName");

            migrationBuilder.RenameColumn(
                name: "cust_email",
                table: "Customers",
                newName: "CustEmail");

            migrationBuilder.RenameColumn(
                name: "confirm_password",
                table: "Customers",
                newName: "ConfirmPassword");

            migrationBuilder.RenameColumn(
                name: "Is_Active",
                table: "Customers",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "cust_id",
                table: "Customers",
                newName: "CustId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers",
                column: "sup_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "product_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "ord_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems",
                column: "item_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "CustId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carts",
                table: "Carts",
                column: "cart_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carts",
                table: "Carts");

            migrationBuilder.RenameTable(
                name: "Suppliers",
                newName: "suptable");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "producttable");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "ordertable");

            migrationBuilder.RenameTable(
                name: "OrderItems",
                newName: "orderitemtable");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "custtable");

            migrationBuilder.RenameTable(
                name: "Carts",
                newName: "carttable");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "custtable",
                newName: "Is_Active");

            migrationBuilder.RenameColumn(
                name: "CustPhone",
                table: "custtable",
                newName: "cust_phone");

            migrationBuilder.RenameColumn(
                name: "CustPassword",
                table: "custtable",
                newName: "cust_password");

            migrationBuilder.RenameColumn(
                name: "CustName",
                table: "custtable",
                newName: "cust_name");

            migrationBuilder.RenameColumn(
                name: "CustEmail",
                table: "custtable",
                newName: "cust_email");

            migrationBuilder.RenameColumn(
                name: "ConfirmPassword",
                table: "custtable",
                newName: "confirm_password");

            migrationBuilder.RenameColumn(
                name: "CustId",
                table: "custtable",
                newName: "cust_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_suptable",
                table: "suptable",
                column: "sup_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_producttable",
                table: "producttable",
                column: "product_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ordertable",
                table: "ordertable",
                column: "ord_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orderitemtable",
                table: "orderitemtable",
                column: "item_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_custtable",
                table: "custtable",
                column: "cust_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_carttable",
                table: "carttable",
                column: "cart_id");
        }
    }
}
