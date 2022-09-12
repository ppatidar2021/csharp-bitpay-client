using System;

namespace BitPaySDK.Exceptions
{
    public class InvoicePaymentException : InvoiceException
    {
        private const string BitPayCode = "BITPAY-INVOICE-PAY-UPDATE";
        private const string BitPayMessage = "Failed to pay invoice";
        protected string ApiCode;
        private string message;

        public InvoicePaymentException() : base(BitPayCode, BitPayMessage)
        {
        }

        public InvoicePaymentException(string message)
        {
            this.message = message;
        }

        public InvoicePaymentException(Exception ex, string apiCode = "000000") : base(BitPayCode, BitPayMessage, ex)
        {
            ApiCode = apiCode;
        }

        public String GetApiCode()
        {
            return ApiCode;
        }
    }
}