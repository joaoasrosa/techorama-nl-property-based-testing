namespace PropertyBasedTesting.Domain
{
    public struct Item
    {
        public decimal Price { get; }

        public Item(decimal price)
        {
            Price = price;
        }
    }
}