namespace Restaurant_Take_A_SUT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var d1 = new Drinks("Prosecco", 95, "Mionetto", "Veneto", true);
            var d2 = new Drinks("Espresso", 25, "Lavazza", "Italien", false);
            var d3 = new Drinks("San Pellegrino", 30, "Nestlé", "Toscana", false);

            Drinks.ShowDrinkMenu();
            Console.WriteLine("");
            Console.ReadKey();
        }
    }
}
