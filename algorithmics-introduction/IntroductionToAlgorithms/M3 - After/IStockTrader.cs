namespace Module3After
{
    interface IStockTrader
    {
        void EnqueueStockForTrading(InvestmentQuery query);
        void HandledTradings();
    }
}