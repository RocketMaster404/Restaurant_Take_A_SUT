namespace Restaurant_Take_A_SUT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var restaurant = new Restaurant(10);
            BuildMenu();
                while (true)
                {
                    Inteface.PrintMenu(restaurant);
                    Console.ReadKey();
                }
            if (User.LogIn())
            {
            }
        }
        public static void BuildMenu()
        {
            new Food("Caprese Salad", 80, "Insalata", true);
            new Food("Bruschetta al Pomodoro", 70, "Antipasto", true);
            new Food("Margherita", 120, "Pizza", true);
            new Food("Pepperoni", 135, "Pizza", false);
            new Food("Spaghetti Carbonara", 145, "Pasta", false);
            new Food("Lasagne al Forno", 150, "Pasta", false);
            new Food("Gnocchi al Pesto", 130, "Pasta", true);
            new Food("Risotto ai Funghi", 140, "Risotto", true);
            new Food("Panna Cotta", 90, "Dolce", true);
            new Food("Tiramisu", 95, "Dolce", true);

            new Drinks("Prosecco", 95, "Mionetto", "Veneto", true);
            new Drinks("Aperol Spritz", 95, "Aperol", "Veneto", true);
            new Drinks("Negroni", 90, "Campari", "Lombardia", true);
            new Drinks("Chianti Classico", 110, "Ruffino", "Toscana", true);
            new Drinks("Lambrusco", 85, "Cantina", "Emilia-Romagna", true);
            new Drinks("Limoncello", 60, "Villa Massa", "Campania", true);
            new Drinks("San Pellegrino", 30, "Nestlé", "Toscana", false);
            new Drinks("Acqua Frizzante", 25, "San Benedetto", "Italien", false);
            new Drinks("Cappuccino", 30, "Illy", "Italien", false);
            new Drinks("Espresso", 25, "Lavazza", "Italien", false);
        }
    }
}