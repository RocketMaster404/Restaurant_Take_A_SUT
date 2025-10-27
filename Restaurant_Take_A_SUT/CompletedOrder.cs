using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Take_A_SUT
{
   internal class CompletedOrder
   {

      public int TableNumber { get; set; }
      public List<MenuItem> Items { get; set; }
      public int Total { get; set; }
      public string PaymentMethod { get; set; } = string.Empty;
      public DateTime TimeStamp { get; set; }

      public CompletedOrder(int tableNumber, List<MenuItem> items, int total, string method)
      {
         TableNumber = tableNumber;
         Items = items;
         Total = total;
         PaymentMethod = method;
         TimeStamp = DateTime.Now;
           
      }



   }
}
