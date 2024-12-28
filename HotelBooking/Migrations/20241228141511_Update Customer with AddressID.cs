using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBooking.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCustomerwithAddressID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Address_AddressCustomerAddressId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_AddressCustomerAddressId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "AddressCustomerAddressId",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "CustomerAddressId",
                table: "Address",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AddressId",
                table: "Customers",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Address_AddressId",
                table: "Customers",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Address_AddressId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_AddressId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Address",
                newName: "CustomerAddressId");

            migrationBuilder.AddColumn<int>(
                name: "AddressCustomerAddressId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AddressCustomerAddressId",
                table: "Customers",
                column: "AddressCustomerAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Address_AddressCustomerAddressId",
                table: "Customers",
                column: "AddressCustomerAddressId",
                principalTable: "Address",
                principalColumn: "CustomerAddressId");
        }
    }
}
