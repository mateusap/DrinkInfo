using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkInfo
{
    public class UserInput
    {
        DrinkService drinkService = new();
        internal void GetCategoriesInput()
        {
            var categories = drinkService.GetCategories();
            Console.WriteLine("Choose Category:");
            string category = Console.ReadLine();
            while (!Validator.IsStringValid(category))
            {
                Console.WriteLine("\nInvalid Category");
                category = Console.ReadLine();
            }
            if (!categories.Any(x => x.strCategory == category))
            {
                Console.WriteLine("Category doesn't exist.");
                GetCategoriesInput();
            }
            GetDrinkInput(category);
        }


        private void GetDrinkInput(string category)
        {
            var drinks = drinkService.GetDrinkByCategory(category);
            Console.WriteLine("Choose a drink or go back to category menu by typing 0:");
            string drink = Console.ReadLine();
            if (drink == "0") GetCategoriesInput();
            while (!Validator.IsIdValid(drink))
            {
                Console.WriteLine("\nInvalid Drink");
                drink = Console.ReadLine();
            }
            if (!drinks.Any(x => x.idDrink == drink))
            {
                Console.WriteLine("Drink doesn't exist.");
                GetDrinkInput(category);
            }
            drinkService.GetDrink(drink);
            Console.WriteLine("Press any key to go back to categories menu");
            Console.ReadKey();
            if (!Console.KeyAvailable) GetCategoriesInput();
        }
    }
}
