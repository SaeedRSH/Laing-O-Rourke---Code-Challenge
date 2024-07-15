using LOR.Interview.PizzeriaChallenge.Models;
using LOR.Interview.PizzeriaChallenge.Config;
using System.Collections.Generic;

namespace LOR.Interview.PizzeriaChallenge.Interfaces
{
    public interface IMenuService
    {
        void DisplayMenu(Store selectedStore);

        List<PizzaInfo> SelectPizzas(Store selectedStore);
    }
}
