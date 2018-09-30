namespace PropertyBasedTesting.Domain
{
    public struct Item
    {
        public double Price { get; }

        public Item(double price)
        {
            Price = price;
        }
    }
}