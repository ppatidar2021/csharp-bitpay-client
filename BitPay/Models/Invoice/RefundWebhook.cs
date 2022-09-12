using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace BitPay.Models.Invoice
{
    class RefundWebhook
    {
        public RefundWebhook()
        {

        }

        // Request fields
        //

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "invoice")]
        public string Invoice { get; set; }

        [JsonProperty(PropertyName = "supportRequest")]
        public string SupportRequest { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "amount")]
        public double Amount { get; set; }

        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }

        // Response fields
        //

        [JsonProperty(PropertyName = "refundFee")]
        public double RefundFee { get; set; }

        [JsonProperty(PropertyName = "lastRefundNotification")]
        public DateTime LastRefundNotification { get; set; }

        [JsonProperty(PropertyName = "immediate")]
        public bool Immediate { get; set; }

        [JsonProperty(PropertyName = "buyerPaysRefundFee")]
        public bool BuyerPaysRefundFee { get; set; }

        [JsonProperty(PropertyName = "requestDate")]
        public DateTime RequestDate { get; set; }

        public bool ShouldSerializeId()
        {
            return (Id != null);
        }

        public bool ShouldSerializeCurrency()
        {
            return (Currency != null);
        }

        public bool ShouldSerializeRequestDate()
        {
            return (RequestDate != null);
        }

        public bool ShouldSerializeLastRefundNotification()
        {
            return (LastRefundNotification != null);
        }

        public bool ShouldSerializeStatus()
        {
            return (Status != null);
        }

        public bool ShouldSerializeSupportRequest()
        {
            return (SupportRequest != null);
        }

        public bool ShouldSerializeInvoice()
        {
            return (Invoice != null);
        }

        public bool ShouldSerializePreview()
        {
            return false;
        }

        public bool ShouldSerializeImmediate()
        {
            return false;
        }

        public bool ShouldSerializeBuyerPaysRefundFee()
        {
            return false;
        }

    }
}
