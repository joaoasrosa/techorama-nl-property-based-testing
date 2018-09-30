using System;

namespace PropertyBasedTesting.Domain
{
    internal class InvalidPrice : Exception
    {
        internal InvalidPrice(string message) : base(message)
        {
        }
    }
}