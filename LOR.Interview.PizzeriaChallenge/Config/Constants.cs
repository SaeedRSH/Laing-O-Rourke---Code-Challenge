
namespace LOR.Interview.PizzeriaChallenge.Config
{
    public static class Constants
    {
        // Messages displayed to the user
        public const string WelcomeMessage = "Welcome to LOR Pizzeria! Please select the store location: Brisbane OR Sydney";
        public const string MenuHeader = "MENU";
        public const string SelectPizzaMessage = "What can I get you?";
        public const string ContinueSelectPizzaMessage = "What else can I get you?";
        public const string PizzaAddedMessage = "Added {0} to your order.";
        public const string InvalidPizzaMessage = "Sorry, we don't have that pizza.";
        public const string PreparingOrderMessage = "Preparing your order...";
        public const string OrderReadyMessage = "Your order is ready!";
        public const string InvalidStoreMessage = "Invalid store selection. Do you want to continue shopping?[Y/N]";
        public const string PizzaPreparingMessage = "Preparing {0}...";
        public const string BakingMessage = "Baking {0} for {1} minutes at {2} degrees...";
        public const string CuttingMessage = "Cutting {0} into {1} slices...";
        public const string BoxingMessage = "Boxing {0}...";
        public const string ReceiptMessage = "Total price: {0} AUD";
        public const string continueOrderingMessage = "Do you want to add another order?[Y/N]";
        public const string orderAddedMessage = "Your order added.";
        public const string addPizzaToppingMessage = "Do you want to add {0} as the pizza topping?[Y/N]";


        // Store names
        public const string Brisbane = "brisbane";
        public const string Sydney = "sydney";
        public const string GoldCoast = "gold coast";
        public const string Pizzas = "Pizzas";
        public const string DefaultCityName = "brisbane";

        // Pizza names
        public const string Capriciosa = "capriciosa";
        public const string Florenza = "florenza";
        public const string Margherita = "margherita";
        public const string Inferno = "inferno";

        // Baking temperatures and times
        public const int DefaultBakeTemperature = 200;
        public const int InfernoBakeTemperature = 220;
        public const int FlorenzaBakeTemperature = 230;
        public const int MargheritaBakeTemperature = 180;
        public const int DefaultBakeTime = 30;
        public const int InfernoBakeTime = 25;
        public const int FlorenzaBakeTime = 28;
        public const int MargheritaBakeTime = 35;

        // Default prices
        public const decimal BrisbaneCapriciosaPrice = 210;
        public const decimal BrisbaneFlorenzaPrice = 180;
        public const decimal BrisbaneMargheritaPrice = 190;    
        
        public const decimal SydneyCapriciosaPrice = 210;
        public const decimal SydneyInfernoPrice = 230;


        // Slice counts
        public const int DefaultSliceCount = 8;
        public const int FlorenzaSliceCount = 6;
    }
}
