using System.Collections.Generic;
using System.Linq;

namespace PropertyBasedTesting.Domain
{
    public class Parcel
    {
        private readonly IEnumerable<Item> _items;
        public double TotalPrice => _items.Sum(x => x.Price);

        public Parcel(IEnumerable<Item> items)
        {
            _items = items;
        }
    }
}