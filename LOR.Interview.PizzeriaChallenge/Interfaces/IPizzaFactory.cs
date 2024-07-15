using LOR.Interview.PizzeriaChallenge.Models.Pizzas;

namespace LOR.Interview.PizzeriaChallenge.Models
{
    public interface IPizzaFactory
    {
        Pizza CreatePizza(string location, PizzaInfo pizzaType);
        void PreparePizza(Pizza pizza);
    }
}