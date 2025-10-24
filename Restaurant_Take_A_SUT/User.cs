using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Take_A_SUT
{
   internal class User
   {
      static List<User> users = new List<User>()
      {
         new User ("Erik", 1234),
         new User ("Pontus", 2040)
      };
      public string UserName { get; set; }
      public int PinCode { get; set; }


      public User(string userName, int pinCode)
      {
         UserName = userName;
         PinCode = pinCode;
           
      }

      public  static bool LogIn()
      {
         int pinCode;
         while (true)
         {
            Console.Clear();
            Console.Write("Ange ditt användarnamn: ");
            string userName = Console.ReadLine();
            Console.Write("Ange din pinkod: ");
            while (!int.TryParse(Console.ReadLine(), out pinCode))
            {
               Console.WriteLine("Pinkoden består av endast siffror");
            }

            foreach (var user in users)
            {
               if (user.UserName == userName && user.PinCode == pinCode)
               {
                  Console.WriteLine($"Välkommen {user.UserName}");
                  Console.ReadKey();
                  return true;
               }
            }

            Console.WriteLine("Felaktigt användarnamn eller pinkod");
            Console.ReadKey();
         }
         


      }




   }
}
