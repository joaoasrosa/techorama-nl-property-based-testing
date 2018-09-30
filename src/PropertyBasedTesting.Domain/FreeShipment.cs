namespace PropertyBasedTesting.Domain
{
    public class FreeShipment
    {
        private const decimal FreeShipmentThreshold = 20M;

        public bool IsParcelEntitledToFreeShipment(Parcel parcel)
        {
            return parcel.TotalPrice >= FreeShipmentThreshold;
        }

        public bool IsParcelEntitledToFreeShipment(decimal parcelTotalPrice)
        {
            return parcelTotalPrice >= FreeShipmentThreshold;
        }
    }
}