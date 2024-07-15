﻿using LOR.Interview.PizzeriaChallenge.Config;

namespace LOR.Interview.PizzeriaChallenge.Models.Pizzas
{
    public class InfernoPizza : Pizza
    {
        public InfernoPizza(string name, List<string> ingredients, List<string> toppings, decimal basePrice)
        {
            Name = name;
            Ingredients = ingredients;
            Toppings = toppings;
            BasePrice = basePrice;
        }

        public override void Prepare()
        {
            Console.WriteLine($"Preparing {Name}...");
            Console.Write("Adding ");
            foreach (var ingredient in Ingredients)
            {
                Console.Write($"{ingredient}, ");
            }
            foreach (var topping in Toppings)
            {
                Console.Write($"{topping}, ");
            }
            Console.WriteLine();
        }

        public override void Bake()
        {
            Console.WriteLine($"Baking {Name} for {Constants.InfernoBakeTime} minutes at {Constants.InfernoBakeTemperature} degrees...");
        }


    }
}
