using CryptoExchange.Net.Objects;

namespace Gopax.Net
{
    public class GopaxError : Error
    {
        public GopaxError(int code, string message) : base(code, message)
        {
        }
    }
}
