using FsCheck;
using FsCheck.Xunit;
using NFluent;
using PropertyBasedTesting.Domain;
using Check = NFluent.Check;

namespace PropertyBasedTesting.Tests.Unit.PrimitiveGeneration
{
    public class WhenCalculatingParcelShipment
    {
        [Property(
            Arbitrary = new[] {typeof(ParcelTotalPriceEqualsOrAbove20Euro)},
            Verbose = true)]
        public void GivenParcelTotalPriceIsEqualOrAbove20Euro_ThenIsEntitledToFreeShipment(
            decimal parcelTotalPrice)
        {
            var postalService = new PostalService();
            var isEntitledToFreeShipment = postalService.IsFreeShipment(parcelTotalPrice);

            Check.That(isEntitledToFreeShipment).IsTrue();
        }


        [Property(
            Arbitrary = new[] {typeof(ParcelTotalPriceBelow20Euro)},
            Verbose = true)]
        public void GivenParcelTotalPriceIsBelow20Euro_ThenIsNotEntitledToFreeShipment(
            decimal parcelTotalPrice)
        {
            var postalService = new PostalService();
            var isEntitledToFreeShipment = postalService.IsFreeShipment(parcelTotalPrice);

            Check.That(isEntitledToFreeShipment).IsFalse();
        }
    }

    public class ParcelTotalPriceEqualsOrAbove20Euro
    {
        public static Arbitrary<decimal> ParcelTotalPrice =>
            Arb.Default.Decimal().Generator.Where(x => x >= 20).ToArbitrary();
    }

    public class ParcelTotalPriceBelow20Euro
    {
        public static Arbitrary<decimal> ParcelTotalPrice =>
            Arb.Default.Decimal().Generator.Where(x => x > 0 && x < 20).ToArbitrary();
    }
}