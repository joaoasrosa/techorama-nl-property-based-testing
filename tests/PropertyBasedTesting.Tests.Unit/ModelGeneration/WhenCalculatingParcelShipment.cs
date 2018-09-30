using System;
using System.Collections.Generic;
using FsCheck;
using FsCheck.Xunit;
using NFluent;
using PropertyBasedTesting.Domain;
using Check = NFluent.Check;

namespace PropertyBasedTesting.Tests.Unit.ModelGeneration
{
    public class WhenCalculatingParcelShipment
    {
        [Property(Arbitrary = new[] {typeof(Generators.ParcelPriceBelow20Euros)})]
        public void GivenParcelPriceIsBelow20Euros_ParcelShipmentIsNotFree(Parcel parcel)
        {
            var postalService = new PostalService(new FreeShipment());
            var isFreeShipment = postalService.IsFreeShipment(parcel);

            Check.That(isFreeShipment).IsFalse();
        }

        [Property(Arbitrary = new[] {typeof(Generators.ParcelPriceEqualOrAbove20Euros)})]
        public void GivenParcelPriceIsEqualOrAbove20Euros_ParcelShipmentFree(Parcel parcel)
        {
            var postalService = new PostalService(new FreeShipment());
            var isFreeShipment = postalService.IsFreeShipment(parcel);

            Check.That(isFreeShipment).IsTrue();
        }

        private class Generators
        {
            public class ParcelPriceBelow20Euros
            {
                public static Arbitrary<Parcel> Parcel()
                {
                    var input = from prices in Arb.Generate<decimal[]>()
                        where PricesAreValid(prices)
                        select CreateParcel(prices);

                    return input.ToArbitrary();
                }

                private static bool PricesAreValid(IReadOnlyCollection<decimal> prices)
                {
                    var sum = 0.0;
                    foreach (var price in prices)
                    {
                        if (price < 0)
                            return false;

                        sum += (double) price;

                        if (sum > 20)
                            return false;
                    }

                    return true;
                }
            }

            public class ParcelPriceEqualOrAbove20Euros
            {
                public static Arbitrary<Parcel> Parcel()
                {
                    var input = from prices in Arb.Generate<decimal[]>()
                        where PricesAreValid(prices)
                        select CreateParcel(prices);

                    return input.ToArbitrary();
                }

                private static bool PricesAreValid(IReadOnlyCollection<decimal> prices)
                {
                    var sum = 0.0;
                    foreach (var price in prices)
                    {
                        if (price < 0)
                            return false;

                        sum += (double) price;
                    }

                    return sum >= 20 && sum <= (double)decimal.MaxValue;
                }
            }

            private static Parcel CreateParcel(IReadOnlyCollection<decimal> prices)
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
}