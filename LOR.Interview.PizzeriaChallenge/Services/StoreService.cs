using System;
using LOR.Interview.PizzeriaChallenge.Models;
using LOR.Interview.PizzeriaChallenge.Config;
using LOR.Interview.PizzeriaChallenge.Interfaces;

namespace LOR.Interview.PizzeriaChallenge.Services
{
    /// <summary>
    /// Service responsible for selecting a store based on user input.
    /// </summary>
    public class StoreService : IStoreService
    {
        private readonly IPizzaFactory _pizzaFactory;
        private readonly IMenu _menu;
        private readonly IStore _store;


        /// <summary>
        /// Constructor to initialize StoreService with required dependencies.
        /// </summary>
        /// <param name="store">The store interface.</param>
        /// <param name="pizzaFactory">The pizza factory interface.</param>
        /// <param name="menu">The menu interface.</param>
        public StoreService(IStore store, IPizzaFactory pizzaFactory, IMenu menu)
        {
            _pizzaFactory = pizzaFactory;
            _menu = menu;
            _store = store;
        }

        /// <summary>
        /// Allows user to select a store based on input.
        /// </summary>
        /// <returns>The selected Store object.</returns>
        public Store SelectStore()
        {
            Store selectedStore = null;
            string storeName = "";

            while (selectedStore == null)
            {
                Console.WriteLine(Constants.WelcomeMessage);
                storeName = Console.ReadLine();

                switch (storeName.ToLower())
                {
                    case Constants.Brisbane:
                        selectedStore = _store.Create(Constants.Brisbane, _pizzaFactory, _menu);
                        break;
                    case Constants.Sydney:
                        selectedStore = _store.Create(Constants.Sydney, _pizzaFactory, _menu);
                        break;
                    default:
                        Console.WriteLine(Constants.InvalidStoreMessage);
                        if (!PromptToContinue())
                        {
                            Console.WriteLine("Exiting...");
                            Environment.Exit(0);
                        }
                        break;
                }
            }

            return selectedStore;
        }


        /// <summary>
        /// Prompts the user to continue or exit based on input.
        /// </summary>
        /// <returns>True if user wants to continue, false if user wants to exit.</returns>

        private bool PromptToContinue()
        {
            Console.WriteLine("Press 'N' to exit or any other key to continue...");
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            return keyInfo.Key != ConsoleKey.N;
        }
    }
}