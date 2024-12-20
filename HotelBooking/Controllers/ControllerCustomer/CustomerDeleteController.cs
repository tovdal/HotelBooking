﻿using HotelBooking.Service.CustomerService;
using HotelBooking.Utilities.Display.Message;
using HotelBooking.Utilities.Display;
using HotelBooking.Utilities.Validators;
using HotelBooking.Controllers.ControllerCustomer.Interface;
using Microsoft.EntityFrameworkCore;
using Spectre.Console;
using HotelBooking.Data;

namespace HotelBooking.Controllers.ControllerCustomer
{
    public class CustomerDeleteController : ICustomerDeleteController
    {
        private readonly CustomerRead _customerRead;
        private readonly CustomerUpdate _customerUpdate;
        private readonly ApplicationDbContext _dbContext;
        public CustomerDeleteController(CustomerRead customerRead, CustomerUpdate customerUpdate, ApplicationDbContext dbContext)
        {
            _customerRead = customerRead;
            _customerUpdate = customerUpdate;
            _dbContext = dbContext;
        }
        public void DeleteCustomer()
        {
            bool isRunning = true;
            while (isRunning)
            {
                var customers = _customerRead.GetAllCustomersInDatabase().ToList();
                DisplayCustomerInformation.PrintCustomersNamesAndID(customers,
                    "There are no customers registered");

                if (!ValidatorCustomerId.TryGetCustomerId(out int customerId))
                {
                    return;
                }
                var customerToDelete = _customerUpdate.ReturnCustomerWithId(customerId);

                if (customerToDelete == null)
                {
                    Console.WriteLine($"No customer found with ID number: {customerId}.");
                    return;
                }
                
                bool selectedCustomerAsDeleted = AnsiConsole.Confirm
                    ($"Do you want to delete customer: {customerToDelete.FirstName} " +
                    $"{customerToDelete.LastName}?");

                Console.Clear();
                if (selectedCustomerAsDeleted)
                {
                    customerToDelete.IsCustomerDeleted = true;
                    _dbContext.SaveChanges();
                    AnsiConsole.MarkupLine("[bold green]Customer successfully deleted![/]");
                }
                else
                {
                    AnsiConsole.MarkupLine("[bold red]Deletion canceled.[/]");
                }

                bool addAnother = AnsiConsole.Confirm("Do you want delete another customer?");
                if (!addAnother)
                {
                    isRunning = false;
                }
            }
        }
    }
}
