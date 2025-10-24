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
        foreach(MenuItem item in Orders)
         {
            Console.WriteLine($"{item.Name}: {item.Price} Kr");
         }
      }

   }
}
