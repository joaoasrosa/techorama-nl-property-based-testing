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
            Arbitrary = new[] {typeof(PrimitiveGenerator.ParcelPriceEqualOrAbove20Euro)},
            Verbose = true)]
        public void
            GivenParcelTotalPriceIsEqualOrAbove20Euro_TheIsEntitledToFreeShipment(
                decimal parcelTotalPrice)
        {
            var postalService = new PostalService();
            var isEntitledToFreeShipment = postalService.IsFreeShipment(parcelTotalPrice);

            Check.That(isEntitledToFreeShipment).IsTrue();
        }

        [Property(
            Arbitrary = new[] {typeof(PrimitiveGenerator.ParcelPriceBelow20Euro)},
            Verbose = true,
            MaxTest = 5)]
        public void
            GivenParcelTotalPriceIsBelow20Euro_ThenIsNotEntitledToFreeShipment(
                decimal parcelTotalPrice)
        {
            var postalPrice = new PostalService();
            var isEntitledToFreeShipment = postalPrice.IsFreeShipment(parcelTotalPrice);
            
            Check.That(isEntitledToFreeShipment).IsFalse();
        }
    }

    public class PrimitiveGenerator
    {
        public class ParcelPriceEqualOrAbove20Euro
        {
            public static Arbitrary<decimal> ParcelPrice =>
                Arb.Default.Decimal().Generator.Where(x => x >= 20).ToArbitrary();
        }

        public class ParcelPriceBelow20Euro
        {
            public static Arbitrary<decimal> ParcelPrice =>
                Arb.Default.Decimal().Generator.Where(x => x > 0 && x < 20).ToArbitrary();
        }
    }
}