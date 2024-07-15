
namespace LOR.Interview.PizzeriaChallenge.Models
{
    /// <summary>
    /// Represents information about a pizza, including its name, ingredients, toppings, and base price.
    /// </summary>
    public class PizzaInfo
    {
        public string Name { get; }
        public List<string> Ingredients { get; }
        public List<string> Toppings { get; }
        public decimal BasePrice { get; }

        /// <summary>
        /// Constructor to initialize a PizzaInfo instance with the specified name, ingredients, and base price.
        /// </summary>
        /// <param name="name">The name of the pizza.</param>
        /// <param name="ingredients">The list of ingredients included in the pizza.</param>
        /// <param name="basePrice">The base price of the pizza.</param>
        public PizzaInfo(string name, List<string> ingredients, decimal basePrice)
        {
            Name = name;
            Ingredients = ingredients;
            BasePrice = basePrice;
            Toppings = new List<string>();
        }

        /// <summary>
        /// Method to add a topping to the pizza.
        /// </summary>
        /// <param name="topping">The topping to be added.</param>
        public void AddTopping(string topping)
        {
            Toppings.Add(topping);
        }

        /// <summary>
        /// Method to get the toppings of the pizza.
        /// </summary>
        /// <returns>The list of toppings added to the pizza.</returns>
        public List<string> GetToppings()
        {
            return Toppings;
        }
    }
}
