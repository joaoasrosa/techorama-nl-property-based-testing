using System;
using System.Globalization;

namespace PropertyBasedTesting.Domain
{
    public struct Price : IEquatable<Price>
    {
        private readonly decimal _price;

        private Price(decimal price)
        {
            if (price < 0)
                throw new InvalidPrice($"{nameof(price)} has an illegal value of [{price}]");

            _price = price;
        }

        public static implicit operator decimal(Price price)
        {
            return price._price;
        }

        public static explicit operator Price(decimal price)
        {
            return new Price(price);
        }

        public static explicit operator Price(double price)
        {
            return new Price((decimal) price);
        }

        public bool Equals(Price other)
        {
            return _price == other._price;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;

            return obj is Price other && Equals(other);
        }

        public override int GetHashCode()
        {
            return _price.GetHashCode();
        }

        public static bool operator ==(Price left, Price right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Price left, Price right)
        {
            return !left.Equals(right);
        }

        public override string ToString()
        {
            return _price.ToString(CultureInfo.InvariantCulture);
        }
    }
}