namespace PropertyBasedTesting.Domain
{
    public struct Item
    {
        public Price Price { get; }

        public Item(decimal price)
        {
            Price = (Price) price;
        }
    }
}