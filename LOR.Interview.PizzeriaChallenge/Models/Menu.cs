using LOR.Interview.PizzeriaChallenge.Config;

namespace LOR.Interview.PizzeriaChallenge.Models
{
    /// <summary>
    /// Represents the menu of pizzas available at different locations.
    /// </summary>
    public class Menu : IMenu
    {
        /// <summary>
        /// Constructor initializes the menu and adds toppings to menu items.
        /// </summary>
        public Menu()
        {
            // Call method to add toppings to menu items
            AddToppingsToMenuItems();
        }

        /// <summary>
        /// Retrieves the menu for a specific location.
        /// </summary>
        /// <param name="location">The location to retrieve the menu for.</param>
        /// <returns>The menu for the specified location.</returns>
        public List<PizzaInfo> GetMenu(string location)
        {
            switch (location.ToLower())
            {
                case Constants.Brisbane:
                    return BrisbaneMenu;
                case Constants.Sydney:
                    return SydneyMenu;
                case Constants.GoldCoast:
                    return GoldCoastMenu;
                default:
                    throw new ArgumentException($"Unknown location: {location}");
            }
        }

        /// <summary>
        /// Adds toppings to the menu items based on their location.
        /// </summary>
        private void AddToppingsToMenuItems()
        {
            // Add toppings to Brisbane menu items
            BrisbaneMenu[0].AddTopping("extra cheese");
            BrisbaneMenu[1].AddTopping("olives");

            // Add toppings to Sydney menu items
            SydneyMenu[0].AddTopping("extra cheese");
            SydneyMenu[1].AddTopping("extra cheese");
        }

        /// <summary>
        /// Retrieves the toppings for a specific pizza at a given location.
        /// </summary>
        /// <param name="location">The location to retrieve the menu for.</param>
        /// <param name="pizzaName">The name of the pizza to retrieve toppings for.</param>
        /// <returns>The toppings for the specified pizza at the given location.</returns>

        public List<string> GetToppingsForPizza(string location, string pizzaName)
        {
            List<PizzaInfo> menu = GetMenu(location);
            var pizza = menu.Find(p => p.Name.Equals(pizzaName, StringComparison.OrdinalIgnoreCase));
            return pizza?.GetToppings();
        }

        // Define menu items for Brisbane with initial toppings
        private List<PizzaInfo> BrisbaneMenu = new List<PizzaInfo>
        {
            new PizzaInfo("Capriciosa", new List<string> { "mushrooms", "cheese", "ham", "mozzarella" }, 20),
            new PizzaInfo("Florenza", new List<string> { "olives", "pastrami", "mozzarella", "onion" }, 21),
            new PizzaInfo("Margherita", new List<string> { "mozzarella", "onion", "garlic", "oregano" }, 22)
        };

        // Define menu items for Sydney with initial toppings
        private List<PizzaInfo> SydneyMenu = new List<PizzaInfo>
        {
            new PizzaInfo("Capriciosa", new List<string> { "mushrooms", "cheese", "ham", "mozzarella" }, 30),
            new PizzaInfo("Inferno", new List<string> { "chili peppers", "mozzarella", "chicken", "cheese" }, 31)
        };

        // Define an empty list for Gold Coast menu items (can be filled later)
        private List<PizzaInfo> GoldCoastMenu = new List<PizzaInfo>
        {
            // Define Gold Coast menu items here
        };
    }

}
