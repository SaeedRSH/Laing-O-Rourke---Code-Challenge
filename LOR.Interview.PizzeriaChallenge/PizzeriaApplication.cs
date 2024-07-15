using LOR.Interview.PizzeriaChallenge.Config;
using LOR.Interview.PizzeriaChallenge.Interfaces;
using LOR.Interview.PizzeriaChallenge.Services;

/// <summary>
/// Represents the main application logic for the Pizzeria Challenge
/// This class shows the interaction between different services
/// </summary>
public class PizzeriaApplication 
{
    private readonly IStoreService _storeService;
    private readonly ICustomerService _customerService;
    private readonly IMenuService _menuService;
    private  IOrderService _orderService;
    /// <summary>
    /// onstructor to initialize the PizzeriaApplication with required services.
    /// </summary>
    /// <param name="storeService">Service for managing stores and their operations.</param>
    /// <param name="customerService">Service for managing customer details.</param>
    /// <param name="menuService">Service for displaying menus and selecting pizzas.</param>
    public PizzeriaApplication(
        IStoreService storeService,
        ICustomerService customerService,
        IMenuService menuService)
    {
        _storeService = storeService;
        _customerService = customerService;
        _menuService = menuService;
       
    }
    /// <summary>
    /// Runs the Pizzeria Application.
    /// This method coordinates the flow of the application,
    /// including selecting a store, ordering pizzas, and displaying the order status.
    /// </summary>
    public void Run()
    {
        // Select a store where the order will be placed
        var selectedStore = _storeService.SelectStore();

        // Create the order service with the selected store
        _orderService = new OrderService(selectedStore);
     
        // Gather customer details
        var customer = _customerService.PopulateCustomerDetails();

        // Display the menu of the selected store
        _menuService.DisplayMenu(selectedStore);

        // Select pizzas to order from the menu
        var selectedPizzas = _menuService.SelectPizzas(selectedStore);

        // Place the order at the selected store
        _orderService.PlaceOrder(customer, selectedPizzas);

        // Display confirmation message that the order is ready
        if(selectedPizzas != null)
            Console.WriteLine($"\n{Constants.OrderReadyMessage}");

    }
}
