using Gopax.Net;
using Gopax.Net.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace GopaxClientTests
{
    class Program
    {
        static GopaxClient gp = new GopaxClient("https://api.gopax.co.kr");

        static void Main(string[] args)
        {
            var result = new List<GopaxTrade>();
            //var t = gp.GetTrades("BTC-KRW");
            var controldate = DateTime.UtcNow.AddDays(-30);
            var startdate = DateTime.UtcNow.AddMinutes(-2);
            long? tradeid = null;
            while (startdate > controldate)
            {
                var trades = gp.GetTrades("KRT-KRW",toid:tradeid);
                if (trades.Success)
                {
                    result.AddRange(trades.Data);
                    Console.WriteLine(trades.Data.Max(c=>c.Date));
                    Console.WriteLine(trades.Data.Max(c => c.Time));
                    tradeid = trades.Data.Min(c => c.Id);
                    startdate = trades.Data.Min(c => c.Time);
                }
                else
                {
                    Console.WriteLine(trades.Error?.Message??"Exception");
                }
                Thread.Sleep(110);
            }
            File.WriteAllText("C:\\blockzi\\KRT-KRW-gopax.json", JsonConvert.SerializeObject(result));
        }
    }
}
