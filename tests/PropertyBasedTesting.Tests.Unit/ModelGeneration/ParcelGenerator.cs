using FsCheck;
using PropertyBasedTesting.Domain;

namespace PropertyBasedTesting.Tests.Unit.ModelGeneration
{
    public class ParcelGenerator
    {
        public class ParcelTotalPriceBelow20Euro
        {
            public static Arbitrary<Parcel> Parcel()
            {
                var input = from prices in Arb.Generate<decimal[]>()
                    where PricesAreValid(prices, 0, 20)
                    select CreateParcel(prices);

                return input.ToArbitrary();
            }
        }
        
        public class ParcelTotalPriceEqualOrAbove20Euro
        {
            public static Arbitrary<Parcel> Parcel()
            {
                var input = from prices in Arb.Generate<decimal[]>()
                    where PricesAreValid(prices, 20, int.MaxValue)
                    select CreateParcel(prices);

                return input.ToArbitrary();
            }
        }

        private static bool PricesAreValid(decimal[] prices, int minPrice, int maxPrice)
        {
            var sum = 0.0;
                
            foreach (var price in prices)
            {
                if (price < 0)
                    return false;

                sum += (double) price;

                if (sum >= maxPrice)
                    return false;
            }
                
            return sum >= minPrice;
        }

        private static Parcel CreateParcel(decimal[] prices)
        {
            var parcel = new Parcel();

            foreach (var price in prices)
            {
                var item = new Item(price);
                parcel.AddItem(item);
            }
                
            return parcel;
        }
    }
}