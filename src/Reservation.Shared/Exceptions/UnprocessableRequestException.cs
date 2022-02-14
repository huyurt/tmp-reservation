using System;

namespace Reservation.Shared.Exceptions
{
    public class UnprocessableRequestException : Exception
    {
        public UnprocessableRequestException(string message) : base(message) { }
    }
}
