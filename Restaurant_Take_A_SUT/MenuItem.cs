namespace Restaurant_Take_A_SUT
{
    internal class MenuItem
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public MenuItem(string name,int price)
        {
            Name = name;
            Price = price;
        }
        public MenuItem()
        {
            Name = "Item";
            Price = 0;
        }
    }
}
