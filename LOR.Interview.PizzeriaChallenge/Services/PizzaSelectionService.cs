using LOR.Interview.PizzeriaChallenge.Models;
using LOR.Interview.PizzeriaChallenge.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using LOR.Interview.PizzeriaChallenge.Config;

namespace LOR.Interview.PizzeriaChallenge.Services
{
    /// <summary>
    /// Service responsible for selecting pizzas from a given store's menu based on user input.
    /// </summary>
    public class PizzaSelectionService : IPizzaSelectionService
    {
        /// <summary>
        /// Selects pizzas from the specified store's menu based on user input.
        /// </summary>
        /// <param name="selectedStore">The store from which pizzas are selected.</param>
        /// <returns>A list of selected PizzaInfo objects.</returns>
        public List<PizzaInfo> SelectPizzas(Store selectedStore)
        {
            Console.WriteLine($"\n{Constants.SelectPizzaMessage}");

            List<PizzaInfo> selectedPizzas = new List<PizzaInfo>();
            try
            {
                while (true)
                {
                    var pizzaType = Console.ReadLine().Trim();

                    // Find the selected pizza information from the store's menu
                    var selectedPizzaInfo = selectedStore.GetMenu().FirstOrDefault(p => p.Name.Equals(pizzaType, StringComparison.OrdinalIgnoreCase));

                    if (selectedPizzaInfo != null)
                    {
                        PizzaInfo selectedPizza = new PizzaInfo(selectedPizzaInfo.Name, selectedPizzaInfo.Ingredients, selectedPizzaInfo.BasePrice);

                        foreach (var topping in selectedPizzaInfo.Toppings)
                        {
                            Console.WriteLine($"\n{Constants.addPizzaToppingMessage}", topping);
                            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                            if (keyInfo.Key == ConsoleKey.Y)
                                selectedPizza.AddTopping(topping);
                        }

                        selectedPizzas.Add(selectedPizza);

                        if (!ContinueOrdering())
                            break;

                    }
                    else
                    {
                        Console.WriteLine(Constants.InvalidPizzaMessage);
                        if (!ContinueOrdering())
                            break;

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return selectedPizzas;
        }

        private bool ContinueOrdering()
        {
            Console.WriteLine($"\n{Constants.continueOrderingMessage}");
            ConsoleKeyInfo continueKey = Console.ReadKey(true);
            if (continueKey.Key == ConsoleKey.N)
                return false;
            else
            {
                Console.WriteLine($"\n{Constants.ContinueSelectPizzaMessage}");
                return true;
            }
        }
    }
}