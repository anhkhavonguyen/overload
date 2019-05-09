using System;

namespace Overload.Payment.Common
{
    public enum StatusCode
    {
        Success = 99,
        AmountNotEnoughToTransfer = 17,
        AmountIsTooSmall = 23,
        RequestTimeout = 45,
        AmountExceedLimit = 46,
        InvalidDimUnit = 47,
        InvalidFromAccount = 48,
        InvalidToAccount = 14,
        SystemError = 1006,
        InvalidPaymentCode = 2127,
        AmountMustBeInRange = 151,
        OrderIsUsed = 162,
        InvalidAmount = 1007,
        NoPaymentInQueue = 13,
        PaymentCancelled = 40,
        PaymentDone = 100,
        NotPossibleToCancel = 50,
        InvalidHmac = 153,
        NotSupportPaymentCode = 1014,
        CannotRefund = 2125,
        EventIdIsNotValid = 208,
        InvalidParameters = 10
    }
}
