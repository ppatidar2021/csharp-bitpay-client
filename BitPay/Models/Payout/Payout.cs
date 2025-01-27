﻿using System;
using System.Collections.Generic;
using System.Linq;
using BitPaySDK.Exceptions;
using Newtonsoft.Json;

namespace BitPaySDK.Models.Payout
{
    public class Payout
    {
        public const string MethodManual2 = "manual_2";

        private string _currency = "";
        private string _ledgerCurrency = "";
        private dynamic _exchangeRates;

        /// <summary>
        ///     Constructor, create an empty Payout object.
        /// </summary>
        public Payout()
        {
            Amount = 0.0;
            Currency = "USD";
            NotificationEmail = "";
            NotificationUrl = "";
        }

        /// <summary>
        ///     Constructor, create an instruction-full request Payout object.
        /// </summary>
        /// <param name="currency">Currency to use on payout.</param>
        /// <param name="amount">
        ///     The payout request amount in the requested currency. The
        ///     minimum amount per instruction is $5 USD equivalent.
        /// </param>
        /// <param name="ledgerCurrency">
        ///     Ledger currency code set for the payout request (ISO 4217
        ///     3-character currency code), it indicates on which ledger the
        ///     payout request will be recorded.If not provided in the request,
        ///     this parameter will be set by default to the active ledger
        ///     currency on your account, e.g.your settlement currency.
        ///     Supported ledger currency codes for payout requests are EUR,
        ///     USD, GBP, CAD, NZD, AUD, ZAR, JPY, BTC, BCH, GUSD, USDC,
        ///     PAX, XRP, BUSD, DOGE, ETH, WBTC, DAI.
        /// </param>

        public Payout(double amount, string currency, string ledgerCurrency) : this()
        {
            Amount = amount;
            Currency = currency;
            LedgerCurrency = ledgerCurrency;
        }

        // API fields
        //

        //[JsonProperty(PropertyName = "guid")] public string Guid { get; set; }

        [JsonProperty(PropertyName = "token")] public string Token { get; set; }

        // Required fields
        //

        [JsonProperty(PropertyName = "amount")]
        public double Amount { get; set; }

        [JsonProperty(PropertyName = "currency")]
        public string Currency
        {
            get => _currency;
            set
            {
                if (!Models.Currency.isValid(value))
                    throw new BitPayException("Error: currency code must be a type of BitPayAPI.Models.Currency");

                _currency = value;
            }
        }

        [JsonProperty(PropertyName = "ledgerCurrency")]
        public string LedgerCurrency
        {
            get => _ledgerCurrency;
            set
            {
                if (!Models.Currency.isValid(value))
                    throw new BitPayException("Error: currency code must be a type of BitPayAPI.Models.Currency");

                _ledgerCurrency = value;
            }
        }

        [JsonProperty(PropertyName = "effectiveDate")]
        [JsonConverter(typeof(BitPaySDK.Converters.DateStringConverter))]
        public DateTime? EffectiveDate { get; set; }

        [JsonProperty(PropertyName = "transactions")]
        public List<PayoutInstructionTransaction> Transactions { get; set; }

        // Optional fields
        //

        [JsonProperty(PropertyName = "reference")]
        public string Reference { get; set; }

        [JsonProperty(PropertyName = "notificationEmail")]
        public string NotificationEmail { get; set; }

        [JsonProperty(PropertyName = "notificationURL")]
        public string NotificationUrl { get; set; }

        // Response fields
        //

        public string Id { get; set; }

        [JsonProperty(PropertyName = "recipientId")]
        public string RecipientId { get; set; }

        [JsonProperty(PropertyName = "shopperId")]
        public string ShopperId { get; set; }

        public string Account { get; set; }

        public string SupportPhone { get; set; }

        public string Status { get; set; }

        public string Email { get; set; }

        public string Label { get; set; }

        public double PercentFee { get; set; }

        public double Fee { get; set; }

        public double DepositTotal { get; set; }

        public double Rate { get; set; }

        public double Btc { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        [JsonConverter(typeof(BitPaySDK.Converters.DateStringConverter))]
        public DateTime RequestDate { get; set; }

        [JsonConverter(typeof(BitPaySDK.Converters.DateStringConverter))]
        public DateTime DateExecuted { get; set; }

        public dynamic ExchangeRates
        {
            get => _exchangeRates;
            set => _exchangeRates = JsonConvert.DeserializeObject(value.ToString(Formatting.None));
        }

        // Private methods
        public bool ShouldSerializeAmount()
        {
            return true;
        }

        public bool ShouldSerializeNotificationEmail()
        {
            return !string.IsNullOrEmpty(NotificationEmail);
        }
        public bool ShouldSerializeToken()
        {
            return !string.IsNullOrEmpty(Token);
        }

        public bool ShouldSerializeNotificationUrl()
        {
            return !string.IsNullOrEmpty(NotificationUrl);
        }

        public bool ShouldSerializeId()
        {
            return false;
        }

        public bool ShouldSerializeExchangeRates()
        {
            return false;
        }

        public bool ShouldSerializeAccount()
        {
            return false;
        }

        public bool ShouldSerializeStatus()
        {
            return false;
        }

        public bool ShouldSerializeRate()
        {
            return false;
        }

        public bool ShouldSerializeBtc()
        {
            return false;
        }

        public bool ShouldSerializeRequestDate()
        {
            return false;
        }

        public bool ShouldSerializePercentFee()
        {
            return false;
        }

        public bool ShouldSerializeFee()
        {
            return false;
        }

        public bool ShouldSerializeDepositTotal()
        {
            return false;
        }

        public bool ShouldSerializeSupportPhone()
        {
            return false;
        }

        public bool ShouldSerializeReference()
        {
            return !string.IsNullOrEmpty(Reference);
        }

        public bool ShouldSerializeDateExecuted()
        {
            return false;
        }
    }
}