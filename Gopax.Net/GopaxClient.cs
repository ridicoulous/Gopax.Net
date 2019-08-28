using CryptoExchange.Net;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Objects;
using Gopax.Net.Interfaces;
using Gopax.Net.Objects;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Gopax.Net
{
    public class GopaxClient : RestClient, IGopaxClient
    {
        public GopaxClient(string endpoint) : base(new GopaxClientOptions(endpoint), null)
        {

        }
        private const string TradesEndpoint = "trading-pairs/{}/trades";

        public CallResult<List<GopaxTrade>> GetTrades(string pair, long? fromid = null, long? toid = null, DateTime? after = null, DateTime? before = null, int limit = 100)
        {
            var parameters = new Dictionary<string, object>();
            parameters.AddOptionalParameter("limit", limit);
            parameters.AddOptionalParameter("pastmax", toid);
            parameters.AddOptionalParameter("latestmin", fromid);
            if (after.HasValue)
              //      parameters.AddOptionalParameter("after", JsonConvert.SerializeObject(after,new TimestampConverter()));
                parameters.AddOptionalParameter("after", after.Value.ToString("o"));
            if (before.HasValue)
            {
               parameters.AddOptionalParameter("before", before.Value.ToString("o"));

               // parameters.AddOptionalParameter("before", JsonConvert.SerializeObject(before, new TimestampConverter()));
            }
            var result = ExecuteRequest<List<GopaxTrade>>(GetUrl(FillPathParameter(TradesEndpoint, pair)), "GET", parameters).Result;
            return new CallResult<List<GopaxTrade>>(result.Data, result.Error);
        }
        protected Uri GetUrl(string endpoint, string version = null)
        {
            return version == null ? new Uri($"{BaseAddress}/{endpoint}") : new Uri($"{BaseAddress}/v{version}/{endpoint}");
        }
        protected override bool IsErrorResponse(JToken data)
        {
            return data.ToString().Contains("errormsg");
        }

        protected override Error ParseErrorResponse(JToken error)
        {
            if (error["errormsg"] == null)
                return new ServerError(error.ToString());

            return new ServerError($"{error["errormsg"]}");
        }


    }
}
