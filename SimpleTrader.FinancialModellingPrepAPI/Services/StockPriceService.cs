using Newtonsoft.Json;
using SimpleTrader.Domain.Exceptions;
using SimpleTrader.Domain.Services;
using SimpleTrader.FinancialModellingPrepAPI.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.FinancialModellingPrepAPI.Services
{
    public class StockPriceService : IStockPriceService
    {
        public async Task<double> GetPrice(string symbol)
        {
            using (FinancialModelingPrepHttpClient client = new FinancialModelingPrepHttpClient())
            {
                string uri = $"stock/real-time-price/{symbol}?apikey={client.APIKEY}";

                StockPriceResult stockPriceResult = await client.GetAsync<StockPriceResult>(uri);            
                
                if(stockPriceResult.Price == 0)
                {
                    throw new InvalidSymbolException(symbol);
                }



                return stockPriceResult.Price;
            }
        }
    }
}
