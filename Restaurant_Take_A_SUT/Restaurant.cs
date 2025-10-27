using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Take_A_SUT
{
    internal class Restaurant
    {

        public List<Table> Tables { get; set; }

        public Restaurant(int numberOfTables)
        {
            Tables = new List<Table>();
            for (int i = 1; i <= numberOfTables; i++)
            {
                Tables.Add(new Table(i));
            }
        }
        public void ShowAllActiveTables()
        {
            foreach (var table in Tables)
            {
                if (table.Orders.Count > 0)
                {
                    table.ShowOrders();
                }
            }
        }

        public void ShowSpecificTable()
        {
            int input;
            Console.WriteLine("Ange bord: ");
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Du måste ange heltal");
            }

            for (int i = 0; i < Tables.Count; i++)
            {
                if (input == Tables[i].TableNumber)
                {
                    Tables[i].ShowOrders();
                    Console.ReadKey();
                }
            }
        }

        public void AddOrderToTable(int tableNumber, MenuItem item)
        {
            var table = GetTable(tableNumber);
            if (table != null)
            {
                table.Orders.Add(item);
            }
        }
        public void RemoveOrderFromTable(int tablenumber, string itemName)
        {
            var table = GetTable(tablenumber);
            if (table == null)
            {
                Console.WriteLine($"Bord {tablenumber} finns inte.");
            }
            MenuItem orderToRemove = null;
            foreach (var order in table.Orders)
            {
                if (string.Equals(order.Name, itemName))
                {
                    orderToRemove = order;
                    break;
                }
            }
        }

        public Table GetTable(int tableNumber)
        {
            foreach (Table currentTable in Tables)
            {
                if (currentTable.TableNumber == tableNumber)
                {
                    return currentTable;
                }
            }

            return null;
        }

    }
}
