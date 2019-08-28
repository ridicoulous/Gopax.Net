using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gopax.Net.Objects
{
    public class GopaxTrade
    {
        [JsonProperty("time")]
        public DateTime Time { get; set; }

        [JsonProperty("date"),JsonConverter(typeof(TimestampSecondsConverter))]
        public DateTime Date { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("side")]
        public string Side { get; set; }
    }
   // public enum Side { Buy, Sell };
}
