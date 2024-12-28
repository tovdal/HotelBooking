using HotelBooking.Models;
using Spectre.Console;

namespace HotelBooking.Utilities.Helpers.CustomerHelper
{
    public class CustomerInputHelper
    {
        public static string PromptFirstName()
        {
            return AnsiConsole.Prompt(
                new TextPrompt<string>("Enter customer's first name: ")
                    .ValidationErrorMessage("[red]Name cannot be empty![/]")
                    .Validate(input => !string.IsNullOrWhiteSpace(input))
            );
        }

        public static string PromptLastName()
        {
            return AnsiConsole.Prompt(
                new TextPrompt<string>("Enter customer's last name: ")
                    .ValidationErrorMessage("[red]Name cannot be empty![/]")
                    .Validate(input => !string.IsNullOrWhiteSpace(input))
            );
        }

        public static string PromptEmail()
        {
            return AnsiConsole.Prompt(
                new TextPrompt<string>("Enter customer's email: ")
                    .ValidationErrorMessage("[red]Please enter a valid email address![/]")
                    .Validate(input => input.Contains("@"))
            ).ToLower();
        }

        public static string PromptPhoneNumber()
        {
            return AnsiConsole.Prompt(
                new TextPrompt<string>("Enter customer's phone number: ")
                    .ValidationErrorMessage("[red]Phone number must be numeric![/]")
                    .Validate(input => long.TryParse(input, out _))
            );
        }

        public static string PromptStreet()
        {
            return AnsiConsole.Prompt(
                new TextPrompt<string>("Enter street: ")
                    .ValidationErrorMessage("[red]Street cannot be empty![/]")
                    .Validate(input => !string.IsNullOrWhiteSpace(input))
            );
        }

        public static string PromptCity()
        {
            return AnsiConsole.Prompt(
                new TextPrompt<string>("Enter city: ")
                    .ValidationErrorMessage("[red]City cannot be empty![/]")
                    .Validate(input => !string.IsNullOrWhiteSpace(input))
            );
        }

        public static string PromptPostalCode()
        {
            return AnsiConsole.Prompt(
                new TextPrompt<string>("Enter postal code: ")
                    .ValidationErrorMessage("[red]Postal code cannot be empty![/]")
                    .Validate(input => !string.IsNullOrWhiteSpace(input))
            ).ToUpper();
        }

        public static string PromptCountry()
        {
            return AnsiConsole.Prompt(
                new TextPrompt<string>("Enter country: ")
                    .ValidationErrorMessage("[red]Country cannot be empty![/]")
                    .Validate(input => !string.IsNullOrWhiteSpace(input))
            );
        }

        public static Address PromptAddress()
        {
            return new Address
            {
                Street = PromptStreet(),
                City = PromptCity(),
                PostalCode = PromptPostalCode(),
                Country = PromptCountry()
            };
        }
        public static Customer PromptCustomerDetails()
        {
            return new Customer
            {
                FirstName = PromptFirstName(),
                LastName = PromptLastName(),
                Email = PromptEmail(),
                PhoneNumber = PromptPhoneNumber(),
                Address = PromptAddress(),
                IsCustomerDeleted = false
            };
        }
    }
}