using LOR.Interview.PizzeriaChallenge.Models;
using LOR.Interview.PizzeriaChallenge.Config;
using LOR.Interview.PizzeriaChallenge.Interfaces;

namespace LOR.Interview.PizzeriaChallenge.Services
{
    /// <summary>
    /// Service responsile for placing orders at a selected store.
    /// </summary>

    public class OrderService : IOrderService
    {
        private readonly IStore _store;

        public OrderService(IStore store)
        {
            _store = store;
        }
        /// <summary>
        /// Places an order at the selected store for the specified customer and pizzas.
        /// </summary>
        /// <param name="selectedStore">The store where the order is placed.</param>
        /// <param name="customer">The customer placing the order.</param>
        /// <param name="selectedPizzas">The list of pizzas being ordered.</param>
        public void PlaceOrder(Customer customer, List<PizzaInfo> selectedPizzas)
        {
            try
            {
                // Display a message indicating that the order is being prepared
                Console.WriteLine($"\n{Constants.PreparingOrderMessage}");

                // Place the order at the selected store
                Order order = _store.PlaceOrder(customer, selectedPizzas);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while placing the order}");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
