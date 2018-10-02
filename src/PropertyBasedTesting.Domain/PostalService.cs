namespace PropertyBasedTesting.Domain
{
    public class PostalService
    {
        public bool IsFreeShipment(Parcel parcel)
        {
            return parcel.TotalPrice >= 20M;
        }

        public bool IsFreeShipment(decimal parcelTotalPrice)
        {
            return parcelTotalPrice >= 20M;
        }
    }
}