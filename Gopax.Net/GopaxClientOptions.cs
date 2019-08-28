using CryptoExchange.Net.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gopax.Net
{
    public class GopaxClientOptions : RestClientOptions
    {
        public GopaxClientOptions(string baseAddres)
        {
            BaseAddress = baseAddres;
        }
    }
}
