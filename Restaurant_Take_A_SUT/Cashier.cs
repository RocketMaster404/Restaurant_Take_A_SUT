using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Take_A_SUT
{
   internal class Cashier
   {

      public static List<CompletedOrder> completedOrders = new List<CompletedOrder>();

      public static void Z_Rapport()
      {
         if(completedOrders.Count == 0)
         {
            Console.WriteLine("Inga avslutade ordrar");
            return;
         }
         Console.WriteLine("Dagens avlsut:\n");

         foreach(var order in completedOrders)
         {
            Console.WriteLine($"Bord: {order.TableNumber}");
            Console.WriteLine($"Tid: {order.TimeStamp}");
            Console.WriteLine($"Betalningsmetod: {order.PaymentMethod}");
            Console.WriteLine("Beställning:");

            foreach (var item in order.Items)
            {
               Console.WriteLine($" - {item.Name,-20} {item.Price,5} kr");
            }

            Console.WriteLine($"Totalt: {order.Total} kr");
            Console.WriteLine(new string('-', 30));
         }
      }


      public static void PrintPayMenu()
      {
         Console.WriteLine("1. Kort");
         Console.WriteLine("2. Swish");
         Console.WriteLine("3. Kontant");
      }

      public static void Pay(Restaurant restaurant)
      {

         Console.WriteLine("Ange bordet att betala för:");
         int input;
         while (!int.TryParse(Console.ReadLine(), out input))
         {
            Console.WriteLine("Du måte ange heltal");
         }



         var table = restaurant.GetTable(input);

         if (table == null)
         {
            Console.WriteLine("Bordet hittades inte");
            return;
         }

         if (table.Orders.Count == 0)
         {
            Console.WriteLine("Inga beställningar att betala");
            return;
         }

         Console.WriteLine($"Kvitto för bord: {input}");
         int sum = 0;

         foreach (var item in table.Orders)
         {
            Console.WriteLine($"{item.Name} - {item.Price}");
            sum += item.Price;
         }

         Console.WriteLine($"Totalt {sum}");
         Console.WriteLine();
         PrintPayMenu();
         Console.WriteLine("Ange ditt betalningsalternativ: ");
         int paymentChoice;
         while (!int.TryParse(Console.ReadLine(), out paymentChoice) || paymentChoice < 1 || paymentChoice > 3)
         {
            Console.WriteLine("Du måste ange ett tal mellan 1-3");
         }

         string paymentMethod = "";

         switch (paymentChoice)
         {
            case 1:
               paymentMethod = "Kort";
               
               break;
            case 2:
               paymentMethod = "Swish";

               break;
            case 3:
               paymentMethod = "Kontant";

               break;

         }

         var completedOrder = new CompletedOrder(input, new List<MenuItem>(table.Orders), sum, paymentMethod);
         completedOrders.Add(completedOrder);
         table.Orders.Clear();
         Console.WriteLine($"Tack för ert Besök, Betalning med {paymentMethod} mottagen");

      }


   }
}
