using System.Collections.Generic;
using System.Linq;

namespace PropertyBasedTesting.Domain
{
    public class Parcel
    {
        private readonly IList<Item> _items;
        
        public Price TotalPrice => (Price) _items.Sum(x => x.Price);

        public Parcel()
        {
            _items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
        }

        public override string ToString()
        {
            return $"Parcel total price: {TotalPrice}";
        }
    }
}