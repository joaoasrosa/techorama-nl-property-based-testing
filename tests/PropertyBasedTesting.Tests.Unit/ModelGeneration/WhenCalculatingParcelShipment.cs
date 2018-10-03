using FsCheck.Xunit;
using NFluent;
using PropertyBasedTesting.Domain;

namespace PropertyBasedTesting.Tests.Unit.ModelGeneration
{
    public class WhenCalculatingParcelShipment
    {
        [Property(
            Arbitrary = new[] {typeof(ParcelGenerator.ParcelTotalPriceEqualOrAbove20Euro)},
            Verbose = true)]
        public void GivenParcelTotalPriceIsEqualOrAbove20Euro_ThenIsEntitledToFreeShipment(
            Parcel parcel)
        {
            var postalService = new PostalService();
            var isEntitledToFreeShipment = postalService.IsFreeShipment(parcel);

            Check.That(isEntitledToFreeShipment).IsTrue();
        }
        
        [Property(
            Arbitrary = new[] {typeof(ParcelGenerator.ParcelTotalPriceBelow20Euro)},
            Verbose = true,
            Replay = "1820211557,296505923")]
        public void GivenParcelTotalPriceIsBelow20Euro_ThenIsNotEntitledToFreeShipment(
            Parcel parcel)
        {
            var postalService = new PostalService();
            var isEntitledToFreeShipment = postalService.IsFreeShipment(parcel);

            Check.That(isEntitledToFreeShipment).IsFalse();
        }
    }
}