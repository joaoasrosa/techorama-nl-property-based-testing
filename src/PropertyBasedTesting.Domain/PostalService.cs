using System;

namespace PropertyBasedTesting.Domain
{
    public class PostalService
    {
        private readonly FreeShipment _freeShipment;

        public PostalService(FreeShipment freeShipment)
        {
            _freeShipment = freeShipment ?? throw new ArgumentNullException(nameof(freeShipment));
        }
        
        public bool IsFreeShipment(Parcel parcel)
        {
            return parcel.TotalPrice >= 20;
        }

        public bool IsFreeShipment(decimal parcelPrice)
        {
            return parcelPrice >= 20;
        }
    }
}