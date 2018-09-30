namespace PropertyBasedTesting.Domain
{
    public struct Item
    {
        public Price Price { get; }

        public Item(double price)
        {
            Price = (Price)price;
        }
    }
}