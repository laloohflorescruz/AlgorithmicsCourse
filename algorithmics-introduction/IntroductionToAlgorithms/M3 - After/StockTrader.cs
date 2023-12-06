using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Module3After
{
    class StockTrader : IStockTrader
    {
        LinkedList<InvestmentQuery> stocksToTrade = new LinkedList<InvestmentQuery>();
        public void EnqueueStockForTrading(InvestmentQuery query)
        {
            stocksToTrade.AddLast(query);
        }

        public void HandledTradings()
        {
            Console.Write(" [{0} stocks] ", stocksToTrade.Count);
            while(stocksToTrade.Count > 0)
            {
                var query = stocksToTrade.First;
                // As this is simulation of a real service that consumes queries as they arrive,
                // remember to remove the query from the list when processed: 
                stocksToTrade.RemoveFirst();
                
                // Simulate stock trade:
//                Thread.Sleep(100);
            }
        }
    }
}
