using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Take_A_SUT
{
   internal class Table
   {
      public List<MenuItem> Orders = new List<MenuItem>();
      public int TableNumber { get; set; }


      public Table(int tableNumber,List<MenuItem> orders)
      {
         TableNumber = tableNumber;
         Orders = orders;
          
      }

   }
}
