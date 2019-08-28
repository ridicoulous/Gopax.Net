using CryptoExchange.Net.Objects;
using Gopax.Net.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gopax.Net.Interfaces
{
    public interface IGopaxClient
    {
        CallResult<List<GopaxTrade>> GetTrades(string pair, long? fromid=null, long? toid=null, DateTime? after=null, DateTime? before=null, int limit=100);
    }
}
