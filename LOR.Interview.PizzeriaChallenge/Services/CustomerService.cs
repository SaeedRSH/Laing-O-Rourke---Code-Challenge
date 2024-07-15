using LOR.Interview.PizzeriaChallenge.Interfaces;
using LOR.Interview.PizzeriaChallenge.Models;

namespace LOR.Interview.PizzeriaChallenge.Services
{
    /// <summary>
    /// Service responsible for gathering customer details.
    /// </summary>
    public class CustomerService : ICustomerService
    {
        /// <summary>
        /// Prompts the user to input their details,
        /// and then creates and returns a customer object using the entered details.
        /// </summary>
        /// <returns>A Customer object populated with the entered details.</returns>
        public Customer PopulateCustomerDetails()
        {
            Console.Write("Enter your name: ");
            string customerName = Console.ReadLine();
            Console.Write("Enter your address: ");
            string customerAddress = Console.ReadLine();
            Console.Write("Enter your phone number: ");
            string customerPhoneNumber = Console.ReadLine();

            return new Customer
            {
                Name = customerName,
                Address = customerAddress,
                PhoneNumber = customerPhoneNumber
            };
        }
    }
}