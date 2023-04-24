using System;
using System.Collections;
using System.Data.Common;

namespace cowbase
{
	public class ChooseStock : ButtonList
	{
        protected ArrayList LoadStocks()
        {
            string stockQ = "SELECT * FROM stocks ORDER BY stockcode ASC";
            DbDataReader reader = null;
            try
            {
                ArrayList stocks = new ArrayList();
               

                reader = SQLDB.ExecuteQuery(stockQ);

                int stockcodeOrd = reader.GetOrdinal("stockcode");
                int stockidOrd = reader.GetOrdinal("stockid");
                int predefsexOrd = reader.GetOrdinal("predefsex");

                while (reader.Read())
                {
                    Stock stock = new Stock();

                    stock.stockCode = reader.GetString(stockcodeOrd);
                    if (!reader.IsDBNull(predefsexOrd))
                    {
                        stock.predefSex = CowSex.FromInt(reader.GetInt32(predefsexOrd));
                    }
                    stock.stockId = reader.GetInt32(stockidOrd);
                    stocks.Add(stock);

                }
                return stocks;
            }
            catch (SystemException sqlEx)
            {
                throw new SystemException("QUERY = " + stockQ + " MSG = " + sqlEx.Message);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                reader = null;
            }
        }


        protected override bool KeyEquals(object key, object keySelect)
        {
            return ((int)keySelect) == ((Stock)key).stockId;
        }
        
        public ChooseStock(int selStockId, string caption,bool bIncludeNoneStock) : base(null, selStockId, caption)
        {            
            try
            {
                ArrayList stockEntries = new ArrayList();
                if (bIncludeNoneStock)
                {
                    Stock noStock = new Stock();
                    noStock.stockId = 0;
                    noStock.stockCode = "BRAK";
                    noStock.predefSex = CowSex.NONE;
                    stockEntries.Add(new DictionaryEntry(noStock, noStock.stockCode));
                }

                ArrayList stocks = LoadStocks();
                IEnumerator stocksEnumerator = stocks.GetEnumerator();
                while (stocksEnumerator.MoveNext())
                {
                    Stock stock = (Stock)stocksEnumerator.Current;
                    stockEntries.Add(new DictionaryEntry(stock, stock.stockCode));
                }

                m_optArray = stockEntries;

                SetFont(16, true);

            }
            catch (SystemException sqlEx)
            {
                LOG.DoLog("ChooseStock() exception: " + sqlEx.Message);
            }
            
        }
	}
}
