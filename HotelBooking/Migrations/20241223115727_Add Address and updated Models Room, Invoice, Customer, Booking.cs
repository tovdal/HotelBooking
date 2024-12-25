using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBooking.Migrations
{
    /// <inheritdoc />
    public partial class AddAddressandupdatedModelsRoomInvoiceCustomerBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
        name: "FK_Booking_Invoices_InvoiceId",
        table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Booking_BookingId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_BookingId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Booking_InvoiceId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Adress",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "Booking");

            migrationBuilder.RenameColumn(
                name: "TypeOfRooms",
                table: "Rooms",
                newName: "TypeOfRoom");

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AddressCustomerAddressId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckOutDate",
                table: "Booking",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    CustomerAddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.CustomerAddressId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_BookingId",
                table: "Invoices",
                column: "BookingId",
                unique: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Booking_BookingId",
                table: "Invoices",
                column: "BookingId",
                principalTable: "Booking",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
        name: "FK_Customers_Address_AddressCustomerAddressId",
        table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Booking_BookingId",
                table: "Invoices");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_BookingId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Customers_AddressCustomerAddressId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "AddressCustomerAddressId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CheckOutDate",
                table: "Booking");

            migrationBuilder.RenameColumn(
                name: "TypeOfRoom",
                table: "Rooms",
                newName: "TypeOfRooms");

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "Rooms",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_BookingId",
                table: "Rooms",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_InvoiceId",
                table: "Booking",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Invoices_InvoiceId",
                table: "Booking",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Booking_BookingId",
                table: "Rooms",
                column: "BookingId",
                principalTable: "Booking",
                principalColumn: "Id");
        }
    }
}