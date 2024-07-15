using System;
using System.Collections.Generic;

namespace LOR.Interview.PizzeriaChallenge.Models
{
    public interface IMenu
    {
        List<PizzaInfo> GetMenu(string location);
        List<string> GetToppingsForPizza(string location, string pizzaName);
    }
}