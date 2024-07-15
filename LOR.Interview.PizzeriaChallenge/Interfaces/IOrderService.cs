using LOR.Interview.PizzeriaChallenge.Models;
using System.Collections.Generic;

namespace LOR.Interview.PizzeriaChallenge.Interfaces
{
    public interface IOrderService
    {
        void PlaceOrder(Customer customer, List<PizzaInfo> selectedPizzas);
    }
}