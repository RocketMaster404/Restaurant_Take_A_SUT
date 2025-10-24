using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Take_A_SUT
{
    internal class Inteface
    {
        public static void PrintMenu(Restaurant restaurant)
        {
            Console.Clear();
            Console.WriteLine("\t=====Huvudmeny=====");
            Console.WriteLine("1) Bordskarta.");
            Console.WriteLine("2) Visa matmeny.");
            Console.WriteLine("3) Visa dryckesmeny.");
            Console.WriteLine("4) Logga ut.");
            string input = Console.ReadLine();
            int choice;
            if (int.TryParse(input, out choice))
            {
                switch (choice)
                {
                    case 1:
                        ShowTableMap(restaurant);
                        break;
                    case 2:
                        ShowFoodMenu();
                        break;
                    case 3:
                        ShowDrinkMenu();
                        break;
                    case 4:
                        ;
                        break;
                }
            }
        }

        public static void ShowTableMap(Restaurant restaurant)
        {
            Console.WriteLine("\t======Bordskarta======");
            Console.WriteLine("1) Visa beställningar.");
            Console.WriteLine("2) Lägg till beställningar.");
            Console.WriteLine("3) Skriv ut nota.");
            Console.WriteLine("4) Återgå till huvudmeny.");
            string input = Console.ReadLine();
            int choice;
            if (int.TryParse(input, out choice))
            {
                switch (choice)
                {
                    case 1:
                        restaurant.ShowSpecificTable();
                        break;
                    case 2:
                        OrderFood(restaurant);
                        break;
                    case 3:
                        //Print nota;
                        break;
                    case 4:
                        PrintMenu(restaurant);
                        break;
                }
            }
        }
        public static void ShowFoodMenu()
        {
            Console.WriteLine("\t======Matmeny======");
            for (int i = 0; i < Food.Foodmenu.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Food.Foodmenu[i]}");
            }
        }
        public static void ShowDrinkMenu()
        {
            Console.WriteLine($"\t======Dryckesmeny======");
            for (int i = 0; i < Drinks.DrinkList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Drinks.DrinkList[i]}");
            }
        }
        public static void OrderFood(Restaurant restaurant)
        {
            ShowFoodMenu();

            Console.Write("Ange bordsnummer: ");
            if (!int.TryParse(Console.ReadLine(), out int tableNumber))
            {
                Console.WriteLine("Felaktigt bordnummer.");
                return;
            }

            Console.WriteLine("\nSkriv numret på maträtten för att lägga till i beställningen (0 för att avsluta):");
            while (true)
            {
                Console.Write("Val: ");
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Felaktig inmatning, försök igen.");
                    continue;
                }

                if (choice == 0) break;

                if (choice > 0 && choice <= Food.Foodmenu.Count)
                {
                    var selectedFood = Food.Foodmenu[choice - 1];
                    restaurant.AddOrderToTable(tableNumber, selectedFood);
                    Console.WriteLine($"Tillagd på bord {tableNumber}: {selectedFood.Name}");
                }
                else
                {
                    Console.WriteLine("Fel: valet finns inte i menyn.");
                }
            }
        }
        //public static void LogOut()
        //{
        //    Environment.Exit(0);
        //}
    }
}
