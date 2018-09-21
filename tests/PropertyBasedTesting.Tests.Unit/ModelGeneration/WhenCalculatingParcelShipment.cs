using System.Linq;
using FsCheck;
using FsCheck.Xunit;
using NFluent;
using PropertyBasedTesting.Domain;
using Check = NFluent.Check;

namespace PropertyBasedTesting.Tests.Unit.ModelGeneration
{
    public class WhenCalculatingParcelShipment
    {
        [Property(MaxTest = 50, Arbitrary = new[] {typeof(ParcelPriceBelow20Euros)})]
        public void GivenParcelPriceIsBelow20Euros_ParcelShipmentIsNotFree(Parcel parcel)
        {
            var postalService = new PostalService();
            var isFreeShipment = postalService.IsFreeShipment(parcel);

            Check.That(isFreeShipment).IsFalse();
        }

        [Property(Arbitrary = new[] {typeof(ParcelPriceEqualOrAbove20Euros)})]
        public void GivenParcelPriceIsEqualOrAbove20Euros_ParcelShipmentFree(Parcel parcel)
        {
            var postalService = new PostalService();
            var isFreeShipment = postalService.IsFreeShipment(parcel);
            
            Check.That(isFreeShipment).IsTrue();
        }

        public class ParcelPriceBelow20Euros
        {
            public static Arbitrary<Parcel> Parcel()
            {
                var input = from prices in Arb.Generate<double[]>()
                    where prices.Sum() > 0 && prices.Sum() < 20
                    select new Parcel(prices.Select(x => new Item(x)).ToArray());

                return input.ToArbitrary();
            }
        }

        public class ParcelPriceEqualOrAbove20Euros
        {
            public static Arbitrary<Parcel> Parcel()
            {
                var input = from prices in Arb.Generate<double[]>()
                    where prices.Sum() >= 20
                    select new Parcel(prices.Select(x => new Item(x)).ToArray());

                return input.ToArbitrary();
            }
        }
    }
}