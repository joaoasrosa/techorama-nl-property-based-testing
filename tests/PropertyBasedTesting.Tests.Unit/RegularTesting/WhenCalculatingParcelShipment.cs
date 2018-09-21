using NFluent;
using PropertyBasedTesting.Domain;
using Xunit;

namespace PropertyBasedTesting.Tests.Unit.RegularTesting
{
    public class WhenCalculatingParcelShipment
    {
        [Fact]
        public void GivenParcelPriceIsBelow20Euros_ParcelShipmentIsNotFree()
        {
            const decimal price = 5;
            
            var postalService = new PostalService();
            var isFreeShipment = postalService.IsFreeShipment(price);
            
            Check.That(isFreeShipment).IsFalse();
        }
        
        [Fact]
        public void GivenParcelPriceIsEqualOrAbove20Euros_ParcelShipmentFree()
        {
            const decimal price = 20;
            
            var postalService = new PostalService();
            var isFreeShipment = postalService.IsFreeShipment(price);
            
            Check.That(isFreeShipment).IsTrue();
        }
    }
}