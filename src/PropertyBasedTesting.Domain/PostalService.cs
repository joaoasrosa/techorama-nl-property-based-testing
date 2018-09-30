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
            return _freeShipment.IsParcelEntitledToFreeShipment(parcel);
        }

        public bool IsFreeShipment(decimal parcelTotalPrice)
        {
            return _freeShipment.IsParcelEntitledToFreeShipment(parcelTotalPrice);
        }
    }
}