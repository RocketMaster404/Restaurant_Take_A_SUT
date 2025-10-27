using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
         Console.WriteLine("5. Betala");
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
                  LogOut();
                  break;
               case 5:
                  Cashier.Pay(restaurant);
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
                  BothMenus(restaurant);
                  break;
               case 3:
                  //Print nota;
                  break;
               case 4:
                  PrintMenu(restaurant);
                  break;
                switch (choice)
                {
                    case 1:
                        DrawTableMap(restaurant);
                        ShowTableMap(restaurant);
                        break;
                    case 2:
                        ShowFoodMenu();
                        break;
                    case 3:
                        ShowDrinkMenu();
                        break;
                    case 4:
                        LogOut();
                        break;
                }
            }
        }
        public static void DrawTableMap(Restaurant restaurant)
        {
            Console.Clear();
            Console.WriteLine("===== Bordskarta =====\n");
            int cellWidth = 5;
            foreach (var table in restaurant.Tables)
            {
                Console.ForegroundColor = table.Orders.Count == 0 ? ConsoleColor.Green : ConsoleColor.Red;
                Console.Write("╔" + new string('═', cellWidth) + "╗ ");
            }
            Console.WriteLine();
            foreach (var table in restaurant.Tables)
            {
                Console.ForegroundColor = table.Orders.Count == 0 ? ConsoleColor.Green : ConsoleColor.Red;

                string number = table.TableNumber.ToString();
                int padding = (cellWidth - number.Length) / 2;
                string leftPad = new string(' ', padding);
                string rightPad = new string(' ', cellWidth - number.Length - padding);

                Console.Write($"║{leftPad}{number}{rightPad}║ ");
            }
            Console.WriteLine();
            foreach (var table in restaurant.Tables)
            {
                Console.ForegroundColor = table.Orders.Count == 0 ? ConsoleColor.Green : ConsoleColor.Red;
                Console.Write("╚" + new string('═', cellWidth) + "╝ ");
            }
            Console.WriteLine("\n");
            Console.ResetColor();
        }

        public static void ShowTableMap(Restaurant restaurant)
        {
            Console.WriteLine("\t======Bordskarta======");
            Console.WriteLine("1) Visa beställningar.");
            Console.WriteLine("2) Lägg till beställningar.");
            Console.WriteLine("3) Ta bort en produkt från bordet.");
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
                        BothMenus(restaurant);
                        break;
                    case 3:
                        RemoveOrderMenu(restaurant);
                        break;
                    case 4:
                        PrintMenu(restaurant);
                        break;
                }
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
      public static void OrderDrinks(Restaurant restaurant)
      {
         Console.Write("Ange bordsnummer: ");
         if (!int.TryParse(Console.ReadLine(), out int tableNumber))
         {
            Console.WriteLine("Felaktigt bordnummer.");
            return;
         }
         Console.WriteLine("\nSkriv numret på drycken för att lägga till i beställningen (0 för att avsluta):");
         while (true)
         {
            Console.Write("Val: ");
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
               Console.WriteLine("Felaktig inmatning, försök igen.");
               continue;
            }
            if (choice == 0) break;

            if (choice > 0 && choice <= Drinks.DrinkList.Count)
            {
               var selectedDrink = Drinks.DrinkList[choice - 1];
               restaurant.AddOrderToTable(tableNumber, selectedDrink);
               Console.WriteLine($"Tillagd på bord {tableNumber}: {selectedDrink.Name}");
            }
            else
            {
               Console.WriteLine("Fel: valet finns inte i menyn.");
            }
         }
      }
      public static void BothMenus(Restaurant restaurant)
      {
         bool running = true;
         while (running)
         {
            Console.Clear();
            Console.WriteLine("1) Mat.");
            Console.WriteLine("2) Dryck.");
            Console.WriteLine("3) Återgå.");
            string input = Console.ReadLine();
            int choice;
            if (int.TryParse(input, out choice))
        }
        public static void RemoveOrderMenu(Restaurant restaurant)
        {
            Console.WriteLine("Ange bordets nummer: ");
            if (!int.TryParse(Console.ReadLine(), out int tableNumber))
            {
                Console.WriteLine("Felaktigt bordsnummer.");
            }
            var table = restaurant.GetTable(tableNumber);
            if (table == null || table.Orders.Count == 0)
            {
                Console.WriteLine("Finns inga beställningar på bordet.");
                Console.ReadKey();
            }
            Console.WriteLine("\nBeställningar på bordet: ");
            for (int i = 0; i < table.Orders.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{table.Orders[i].Name}");
            }
            Console.WriteLine("Välj numret på produkten som ska tas bort: ");
            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > table.Orders.Count)
            {
                Console.WriteLine("Felaktigt val.");
                Console.ReadKey();
            }
            var removedItem = table.Orders[choice - 1];
            table.Orders.RemoveAt(choice - 1);
            Console.WriteLine($"{removedItem.Name} tagits bort från bord {tableNumber}.");
            Console.ReadKey();
        }
        public static void BothMenus(Restaurant restaurant)
        {
            bool running = true;
            while (running)
            {
               switch (choice)
               {
                  case 1:
                     ShowFoodMenu();
                     OrderFood(restaurant);
                     break;
                  case 2:
                     ShowDrinkMenu();
                     OrderDrinks(restaurant);
                     break;
                  case 3:
                     running = false;
                     break;
               }
            }
         }
      }
      public static void LogOut()
      {
         Environment.Exit(0);
      }
   }
}
