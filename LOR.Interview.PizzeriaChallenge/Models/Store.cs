using LOR.Interview.PizzeriaChallenge.Interfaces;
using LOR.Interview.PizzeriaChallenge.Config;

namespace LOR.Interview.PizzeriaChallenge.Models
{
    /// <summary>
    /// Represents a pizzeria store with methods to display menu, get the menu, place and process orders.
    /// </summary>
    public class Store : IStore
    {

        private readonly IPizzaFactory _kitchen;
        private readonly IMenu _menu;
        public string CityName { get; private set; }
        private List<Order> Orders { get; } = new List<Order>();

        /// <summary>
        /// Constructor to initialize a Store instance with the specified city name, pizza factory, and menu.
        /// </summary>
        /// <param name="cityName">The name of the city where the store is located.</param>
        /// <param name="kitchen">The pizza factory responsible for creating pizzas.</param>
        /// <param name="menu">The menu containing available pizzas.</param>
        public Store(string cityName, IPizzaFactory kitchen, IMenu menu)
        {
            CityName = cityName;
            _kitchen = kitchen;
            _menu = menu;


        }

        /// <summary>
        /// Create a new Store instance with the specified city name, pizza factory, and menu.
        /// </summary>
        /// <param name="cityName">The name of the city where the store is located.</param>
        /// <param name="kitchen">The pizza factory responsible for creating pizzas.</param>
        /// <param name="menu">The menu containing available pizzas.</param>
        /// <returns>A new instance of Store.</returns>
        public Store Create(string cityName, IPizzaFactory kitchen, IMenu menu)
        {
            return new Store(cityName, kitchen, menu);
        }



        /// <summary>
        /// Displays the menu of pizzas available at the store.
        /// </summary>
        public void DisplayMenu()
        {
            Console.WriteLine($"MENU FOR {CityName.ToUpper()}");
            foreach (var pizzaGroup in _menu.GetMenu(CityName))
            {
                var pizzaName = pizzaGroup.Name;
                var pizzaPrice = pizzaGroup.BasePrice;
                Console.Write($"{pizzaName} - [Ingredients:");
                for (int i = 0; i < pizzaGroup.Ingredients.Count; i++)
                {
                    var ingredient = pizzaGroup.Ingredients[i];
                    Console.Write($" {ingredient}");
                    if ( i != pizzaGroup.Ingredients.Count-1)
                        Console.Write($", ");
                }
                Console.WriteLine($"] - {pizzaPrice} AUD");              
            }
        }

        /// <summary>
        ///  Retrieves the menu of pizzas available at the store.
        /// </summary>
        /// <returns> List of PizzaInfo objects representing the menu. </returns>
        public List<PizzaInfo> GetMenu()
        {
            return _menu.GetMenu(CityName);
        }


        /// <summary>
        /// Places an order at the store for the specified customer and pizzas.
        /// </summary>
        /// <param name="customer">The customer placing the order.</param>
        /// <param name="pizzaTypes">The list of pizzas being ordered.</param>
        /// <returns>The Order object representing the placed order.</returns>
        public Order PlaceOrder(Customer customer, List<PizzaInfo> pizzaTypes)
        {
            List<Pizza> pizzas = new List<Pizza>();

            foreach (var pizzaType in pizzaTypes)
            {
                Pizza pizza = _kitchen.CreatePizza(CityName, pizzaType);
                if (pizza != null)
                {
                    pizzas.Add(pizza);
                }
            }

            if (pizzas.Count == 0)
            {
                Console.WriteLine("No valid pizzas ordered. Order cancelled.");
                return null;
            }

            Order order = new Order(customer, pizzas);
            Orders.Add(order);

            Console.WriteLine($"Order placed successfully for {customer.Name} at {CityName}.");

            // Send order to kitchen for processing
            ProcessOrder(order);

            return order;
        }

        /// <summary>
        /// Processes the order by preparing each pizza at the kitchen and updating the order status.
        /// </summary>
        /// <param name="order">The Order object to be processed.</param>
        private void ProcessOrder(Order order)
        {
            foreach (var pizza in order.Pizzas)
            {
                _kitchen.PreparePizza(pizza);
            }

            
            order.CompleteOrder();
        }

    }

}
