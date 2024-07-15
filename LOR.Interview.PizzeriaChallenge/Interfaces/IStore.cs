using System.Collections.Generic;
using LOR.Interview.PizzeriaChallenge.Models;

namespace LOR.Interview.PizzeriaChallenge.Interfaces
{
    public interface IStore
    {
        string CityName { get; }

        void DisplayMenu();

        List<PizzaInfo> GetMenu();

        Order PlaceOrder(Customer customer, List<PizzaInfo> pizzaTypes);
        Store Create(string cityName, IPizzaFactory kitchen, IMenu menu);
    }
}