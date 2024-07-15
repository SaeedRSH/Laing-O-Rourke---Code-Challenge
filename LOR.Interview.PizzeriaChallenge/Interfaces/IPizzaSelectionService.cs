using LOR.Interview.PizzeriaChallenge.Models;

namespace LOR.Interview.PizzeriaChallenge.Interfaces
{
    public interface IPizzaSelectionService
    {
        List<PizzaInfo> SelectPizzas(Store selectedStore);
    }
}