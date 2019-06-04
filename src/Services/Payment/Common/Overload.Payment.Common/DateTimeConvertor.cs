using Google.Protobuf.WellKnownTypes;
using System;

namespace Overload.Payment.Common
{
    public static class DateTimeConvertor
    {
        public static Timestamp GetProtobufTimeSpan(DateTime? dateTime)
        {
            return dateTime.HasValue ? Timestamp.FromDateTime(dateTime.Value.ToUniversalTime()) : new Timestamp();
        }
    }
}
