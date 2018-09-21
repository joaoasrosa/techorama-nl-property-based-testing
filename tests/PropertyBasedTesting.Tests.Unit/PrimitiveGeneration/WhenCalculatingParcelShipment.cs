using FsCheck;
using FsCheck.Xunit;
using NFluent;
using PropertyBasedTesting.Domain;
using Check = NFluent.Check;

namespace PropertyBasedTesting.Tests.Unit.PrimitiveGeneration
{
    public class WhenCalculatingParcelShipment
    {
        [Property(Arbitrary = new[] {typeof(ParcelPriceBelow20Euros)})]
        public void GivenParcelPriceIsBelow20Euros_ParcelShipmentIsNotFree(decimal parcelPrice)
        {
            var postalService = new PostalService();
            var isFreeShipment = postalService.IsFreeShipment(parcelPrice);

            Check.That(isFreeShipment).IsFalse();
        }

        [Property(Arbitrary = new[] {typeof(ParcelPriceEqualOrAbove20Euros)})]
        public void GivenParcelPriceIsEqualOrAbove20Euros_ParcelShipmentFree(decimal parcelPrice)
        {
            var postalService = new PostalService();
            var isFreeShipment = postalService.IsFreeShipment(parcelPrice);

            Check.That(isFreeShipment).IsTrue();
        }

        public class ParcelPriceBelow20Euros
        {
            public static Arbitrary<decimal> ParcelPrice() =>
                Arb.Default.Decimal().Generator.Where(x => x > 0 && x < 20).ToArbitrary();
        }

        public class ParcelPriceEqualOrAbove20Euros
        {
            public static Arbitrary<decimal> ParcelPrice() =>
                Arb.Default.Decimal().Generator.Where(x => x >= 20).ToArbitrary();
        }
    }
}