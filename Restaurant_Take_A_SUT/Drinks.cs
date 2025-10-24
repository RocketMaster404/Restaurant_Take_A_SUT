using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Take_A_SUT
{
    internal class Drinks:MenuItem
    {
        public string Brand { get; set; }
        public string OriginRegion { get; set; }
        public bool ContainAlc { get; set; }

        public static List<Drinks> DrinkList = new List<Drinks>();
        public Drinks(string name, int price, string brand, string originregion, bool containalc) : base(name, price)
        {
            Brand = brand;
            OriginRegion = originregion;
            ContainAlc = containalc;

            DrinkList.Add(this);
        }
        public override string ToString()
        {
            string alcoholText = ContainAlc ? "Innehåller alkohol" : "Alkoholfri";
            return $"{Name} ({Brand}) - {Price} kr, Från {OriginRegion}, {alcoholText}";
        }
        public static void ShowDrinkMenu()
        {
            Console.WriteLine($"\t======Dryckesmeny======");
            foreach (var drink in DrinkList)
            {
                Console.WriteLine(drink);
            }
        }
    }
}
