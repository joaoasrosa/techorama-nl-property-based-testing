using System.Collections;
using System.Collections.Generic;
using NFluent;
using PropertyBasedTesting.Domain;
using Xunit;

namespace PropertyBasedTesting.Tests.Unit.RegularTesting
{
    public class WhenCalculatingParcelShipment
    {
        public class SingleDataPoint
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

        public class InlineData
        {
            [Theory]
            [InlineData(3)]
            [InlineData(8)]
            [InlineData(9)]
            public void GivenParcelPriceIsBelow20Euros_ParcelShipmentIsNotFree(decimal price)
            {
                var postalService = new PostalService();
                var isFreeShipment = postalService.IsFreeShipment(price);

                Check.That(isFreeShipment).IsFalse();
            }
        }

        public class ClassData
        {
            [Theory]
            [ClassData(typeof(ParcelData))]
            public void GivenParcelPriceIsBelow20Euros_ParcelShipmentIsNotFree(Parcel parcel)
            {
                var postalService = new PostalService();
                var isFreeShipment = postalService.IsFreeShipment(parcel);

                Check.That(isFreeShipment).IsFalse();
            }

            private class ParcelData : IEnumerable<object[]>
            {
                public IEnumerator<object[]> GetEnumerator()
                {
                    yield return CreateParcel(3);
                    yield return CreateParcel(3, 3);
                    yield return CreateParcel(3, 3, 1);
                    yield return CreateParcel(5, 4);
                }

                private static object[] CreateParcel(params decimal[] prices)
                {
                    var parcel = new Parcel();
                    
                    foreach (var price in prices)
                    {
                        parcel.AddItem(new Item(price));
                    }

                    return new object[] {parcel};
                }

                IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
            }
        }
    }
}