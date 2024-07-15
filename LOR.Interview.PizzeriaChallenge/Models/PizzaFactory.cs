using LOR.Interview.PizzeriaChallenge.Config;
using LOR.Interview.PizzeriaChallenge.Models.Pizzas;
using System.Reflection.Metadata;

namespace LOR.Interview.PizzeriaChallenge.Models
{
    /// <summary>
    /// Factory class responsible for creating different types of pizzas based on the provided pizza information.
    /// </summary>
    public class PizzaFactory : IPizzaFactory
    {
        private readonly IMenu _menu;

        /// <summary>
        /// Constructor to initialize an instance of PizzaFactory with the specified menu.
        /// </summary>
        /// <param name="menu">The menu from which pizza information is retrieved.</param>
        public PizzaFactory(IMenu menu) 
        {
            _menu = menu;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="location">The location where the pizza is ordered.</param>
        /// <param name="pizzaType">The type of pizza to create.</param>
        /// <returns>The created Pizza object based on the provided pizza information.</returns>
        public Pizza CreatePizza(string location, PizzaInfo pizzaType)
        {

            List<PizzaInfo> menu =_menu.GetMenu(location);
            PizzaInfo pizzaInfo = menu.Find(p => p.Name.Equals(pizzaType.Name, StringComparison.OrdinalIgnoreCase));
            if (pizzaInfo == null)
            {
                Console.WriteLine($"Sorry, {pizzaType} is not available at {location}.");
                return null;
            }

            switch (pizzaType.Name.ToLower())
            {
                case Constants.Capriciosa:
                    return new CapriciosaPizza(pizzaType.Name, pizzaType.Ingredients, pizzaType.Toppings, pizzaType.BasePrice);

                case Constants.Inferno:
                    return new InfernoPizza(pizzaType.Name, pizzaType.Ingredients, pizzaType.Toppings, pizzaType.BasePrice);                
                   

                case Constants.Florenza:
                    return new FlorenzaPizza(pizzaType.Name, pizzaType.Ingredients, pizzaType.Toppings, pizzaType.BasePrice);
                
                case Constants.Margherita:
                    return new MargheritaPizza(pizzaType.Name, pizzaType.Ingredients, pizzaType.Toppings, pizzaType.BasePrice);
                

                default:
                    Console.WriteLine($"Unknown pizza type: {pizzaType}");
                    return null;
            }
        }

        /// <summary>
        /// Prepares the given pizza by executing its preparation, baking, and boxing processes.
        /// </summary>
        /// <param name="pizza"The pizza to be prepared.></param>
        public void PreparePizza(Pizza pizza)
        {
            pizza.Prepare();
            pizza.Bake();
            pizza.Box();
            Console.WriteLine($"Pizza {pizza.Name} is ready!");
        }
    }
}

