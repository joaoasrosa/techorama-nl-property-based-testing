using System.Collections.Generic;
using System.Linq;

namespace PropertyBasedTesting.Domain
{
    public class Parcel
    {
        private readonly IList<Item> _items;
        public Price TotalPrice => (Price)_items.Sum(x => x.Price);

        public Parcel()
        {
            _items = new List<Item>();
        }
        
        public Parcel(IEnumerable<Item> items)
        {
            _items = items.ToList();
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
        }
    }
}