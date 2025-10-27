using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Take_A_SUT
{
   internal class PaymentSum
   {
      public string Method { get; set; } = string.Empty;
      public int Total { get; set; }

      public PaymentSum(string method, int total)
      {
         Method = method;
         Total = total;
      }
   }
}
