using System;

namespace Reservation.Shared.Exceptions
{
    [Serializable]
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message) { }
    }
}
