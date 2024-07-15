using LOR.Interview.PizzeriaChallenge.Interfaces;

namespace LOR.Interview.PizzeriaChallenge.Models
{
    /// <summary>
    /// Represents an order placed by a customer, containing pizzas.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// The customer who placed the order.
        /// </summary>
        private Customer Customer { get; }

        /// <summary>
        /// The list of pizzas included in the order.
        /// </summary>
        public List<Pizza> Pizzas { get; }

        /// <summary>
        /// Constructor to initialize an order with a customer and list of pizzas.
        /// </summary>
        /// <param name="customer">The customer who placed the order.</param>
        /// <param name="pizzas">The list of pizzas included in the order.</param>
        public Order(Customer customer, List<Pizza> pizzas)
        {
            Customer = customer;
            Pizzas = pizzas;
        }

        /// <summary>
        /// Calculates the total price of the order based on the pizzas included.
        /// </summary>
        /// <returns>The total price of the order.</returns>
        private decimal CalculateTotalPrice()
        {
            decimal totalPrice = 0;
            foreach (var pizza in Pizzas)
            {
                totalPrice += pizza.BasePrice;
            }
            return totalPrice;
        }

        /// <summary>
        /// Prints the receipt for the order showing the total price.
        /// </summary>
        /// <param name="totalPrice">The total price of the order to print.</param>
        private void PrintReceipt(decimal totalPrice)
        {
            System.Console.WriteLine($"Total price: {totalPrice} AUD");
        }

        /// <summary>
        /// Adds a pizza to the order.
        /// </summary>
        /// <param name="pizza">The pizza to add to the order.</param>
        public void AddPizza(Pizza pizza)
        {
            Pizzas.Add(pizza);
        }

        /// <summary>
        /// Prepares all pizzas in the order by invoking their preparation method.
        /// </summary>
        public void PreparePizzas()
        {
            foreach (var pizza in Pizzas)
            {
                pizza.Prepare();
            }
        }

        /// <summary>
        /// Completes the order by calculating the total price and printing the receipt.
        /// </summary>
        public void CompleteOrder()
        {
            decimal totalPrice = CalculateTotalPrice();
            PrintReceipt(totalPrice);
        }

    }
}
