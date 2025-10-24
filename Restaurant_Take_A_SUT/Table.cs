using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Take_A_SUT
{
   internal class Table
   {
      public List<MenuItem> Orders { get; set; }
      
      public int TableNumber { get; set; }


      public Table(int tableNumber)
      {
         TableNumber = tableNumber;
         Orders = new List<MenuItem>();
      }

      public void ShowOrders()
      {
         int sum = 0;
         Console.WriteLine($"Beställningar för Bord: {TableNumber}");

         for(int i = 0; i < Orders.Count; i++)
         {
            Console.WriteLine($"{Orders[i].Name}: {Orders[i].Price} Kr");
            sum += Orders[i].Price;
         }

         Console.WriteLine($"Totalt: {sum} Kr");

      }

      

   }
    internal class Table
    {
        public List<MenuItem> Orders { get; set; }
        public int TableNumber { get; set; }


        public Table(int tableNumber)
        {
            TableNumber = tableNumber;
            Orders = new List<MenuItem>();
        }

        public void ShowOrders()
        {
            int sum = 0;
            Console.WriteLine($"Beställningar för Bord: {TableNumber}");

            for (int i = 0; i < Orders.Count; i++)
            {
                Console.WriteLine($"{Orders[i].Name}: {Orders[i].Price} Kr");
                sum += Orders[i].Price;
            }

            Console.WriteLine($"Totalt: {sum} Kr");
        }
    }
}
