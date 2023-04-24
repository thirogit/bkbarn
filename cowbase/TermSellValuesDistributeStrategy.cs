using System;

using System.Collections.Generic;
using System.Text;

namespace cowbase
{
    public class TermSellValuesDistributeStrategy : NewChunk.DistributeStrategy
    {
        public void Distribute(ICollection<Cow> cows, Nullable<double> totalweight, Nullable<double> totalprice, Stock stock4all)
        {
            if (totalweight.HasValue)
            {
                double minWeight = cows.Count*0.001;
                if (totalweight.Value < minWeight)
                    throw new Exception("Calkowita waga nie moze byc mniejsza niz " + Utils.FormatFloat(minWeight, 3) + "kg (" + cows.Count.ToString() + "g");

                DistributeWeight(cows, totalweight.Value / cows.Count);
            }

            if (totalprice.HasValue)
            {
                double minPrice = cows.Count * 0.001;
                if (totalprice.Value < minPrice)
                    throw new Exception("Calkowita cena nie moze by mniejsza niz " + Utils.FormatMoney(minPrice) + "zl");

                DistributePrice(cows, totalprice.Value/cows.Count);
            }

            if (stock4all != null)
            {
                DistributeStock(cows, stock4all);
            }
        }

        private void DistributeWeight(ICollection<Cow> cows, double onecowweight)
        {
            IEnumerator<Cow> cowsEnumerator = cows.GetEnumerator();
            while (cowsEnumerator.MoveNext())
            {
                Cow cow = cowsEnumerator.Current;
                cow.termsellweight = onecowweight;
            }
        }

        private void DistributePrice(ICollection<Cow> cows, double onecowprice)
        {
            IEnumerator<Cow> cowsEnumerator = cows.GetEnumerator();
            while (cowsEnumerator.MoveNext())
            {
                Cow cow = cowsEnumerator.Current;
                cow.termsellprice = onecowprice;
            }
        }

        private void DistributeStock(ICollection<Cow> cows,Stock stock)
        {
            IEnumerator<Cow> cowsEnumerator = cows.GetEnumerator();
            while (cowsEnumerator.MoveNext())
            {
                Cow cow = cowsEnumerator.Current;
                cow.termsellstock = stock.stockId;
            }
        }
    }
}
