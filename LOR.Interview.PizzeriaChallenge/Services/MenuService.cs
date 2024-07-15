using LOR.Interview.PizzeriaChallenge.Models;
using LOR.Interview.PizzeriaChallenge.Interfaces;
using LOR.Interview.PizzeriaChallenge.Config;

namespace LOR.Interview.PizzeriaChallenge.Services
{
    /// <summary>
    /// Service responsible for managing the menu operations of a pizzeria,
    /// including displaying the menu and selecting pizzas.
    /// Implements the IMenuService interface.
    /// </summary>
    public class MenuService : IMenuService
    {
        private readonly IPizzaSelectionService _pizzaSelectionService;

        /// <summary>
        /// Initializes a new instance of the MenuService class.
        /// </summary>
        /// <param name="pizzaSelectionService">The service responsible for pizza selection.</param>
        public MenuService(IPizzaSelectionService pizzaSelectionService)
        {
            _pizzaSelectionService = pizzaSelectionService;
        }

        /// <summary>
        /// Displays the menu of the selected store.
        /// </summary>
        /// <param name="selectedStore">The store whose menu should be displayed.</param>
        public void DisplayMenu(Store selectedStore)
        {

            Console.WriteLine(Constants.MenuHeader);
            selectedStore.DisplayMenu();
        }

        /// <summary>
        /// Select Pizza from the menu of the selected store using the PizzaSelectionService
        /// </summary>
        /// <param name="selectedStore">The store from which pizzas are to be selected.</param>
        /// <returns></returns>
        public List<PizzaInfo> SelectPizzas(Store selectedStore)
        {

            return _pizzaSelectionService.SelectPizzas(selectedStore);
        }
    }
}