using PropertyBasedTesting.Domain;
using Xunit;

namespace PropertyBasedTesting.Tests.Unit.RegularTesting
{
    public class WhenCalculatingParcelShipmentWithBug
    {
        [Fact]
        public void GivenParcelPriceIsBelow20Euros_ParcelShipmentIsNotFree()
        {
            const decimal price = 5;
            
            var postalService = new PostalServiceWithBug();
            var isFreeShipment = postalService.IsFreeShipment(price);
            
            Assert.Equal(false, isFreeShipment);
        }
        
        [Fact]
        public void GivenParcelPriceIsEqualOrAbove20Euros_ParcelShipmentFree()
        {
            const decimal price = 20;
            
            var postalService = new PostalServiceWithBug();
            var isFreeShipment = postalService.IsFreeShipment(price);
            
            Assert.Equal(true, isFreeShipment);
        }
    }
}