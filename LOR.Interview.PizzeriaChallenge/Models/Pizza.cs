using LOR.Interview.PizzeriaChallenge.Interfaces;
using LOR.Interview.PizzeriaChallenge.Config;

namespace LOR.Interview.PizzeriaChallenge.Models
{

    /// <summary>
    /// Abstract base class representing a Pizza with basic properties and methods.
    /// </summary>
    public abstract class Pizza
    {
        /// <summary>
        /// The name of the pizza.
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// The list of ingredients in the pizza.
        /// </summary>
        public List<string> Ingredients { get; protected set; } = new List<string>();

        /// <summary>
        /// The list of toppings on the pizza.
        /// </summary>
        public List<string> Toppings { get; protected set; } = new List<string>();

        /// <summary>
        /// The base price of the pizza.
        /// </summary>
        public decimal BasePrice { get; protected set; }

        /// <summary>
        /// Abstract method to prepare the pizza.
        /// </summary>
        public abstract void Prepare();

        /// <summary>
        /// Virtual method to bake the pizza.
        /// </summary>
        public virtual void Bake()
        {
            System.Console.WriteLine($"Baking {Name} for {Constants.DefaultBakeTime} minutes at {Constants.DefaultBakeTemperature} degrees...");
        }

        /// <summary>
        /// Virtual method to cut the pizza.
        /// </summary>
        public virtual void Cut()
        {
            System.Console.WriteLine($"Cutting {Name} into {Constants.DefaultSliceCount} slices...");
        }

        /// <summary>
        /// Virtual method to box the pizza.
        /// </summary>
        public virtual void Box()
        {
           Console.WriteLine($"Boxing {Name}...");
        }



    }



}
