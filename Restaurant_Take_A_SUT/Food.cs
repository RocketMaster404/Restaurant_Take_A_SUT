using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Take_A_SUT
{
    internal class Food : MenuItem
    {
        public string Category { get; set; }
        public bool IsVegitarian { get; set; }

        public static List<Food> Foodmenu = new List<Food>();

        public Food(string name, int price, string category, bool isvegitarian) : base(name, price)
        {
            Category = category;
            IsVegitarian = isvegitarian;

            Foodmenu.Add(this);
        }
        public Food()
        {

        }
        public override string ToString()
        {
            string vegText = IsVegitarian ? "Vegetarisk" : "Ej vegetarisk";
            return $"{Name} ({Category}) - {Price} kr, {vegText}";
        }
        public static void ShowFoodMenu()
        {
            Console.WriteLine("\t======Matmeny======");
            foreach (var food in Foodmenu)
            {
                Console.WriteLine(food);
            }
        }
    }
}
