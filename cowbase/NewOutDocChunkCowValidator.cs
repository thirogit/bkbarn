using System;

using System.Collections.Generic;
using System.Text;

namespace cowbase
{
    public class NewOutDocChunkCowValidator : NewChunk.CowValidator
    {

        private ICollection<Cow> m_outdocCows;

        public NewOutDocChunkCowValidator(ICollection<Cow> outdocCows)
        {
            m_outdocCows = outdocCows;
        }

        public NewChunk.CowValidateResult Validate(string sEAN)
        {
            Cow cow = FindGoodCow(sEAN);

            if (cow == null)
            {
                return new NewChunk.CowValidateResult(false, "Nieobecny na stanie",null);
            }
            else
            {
                IEnumerator<Cow> cowsEnumerator = m_outdocCows.GetEnumerator();
                while (cowsEnumerator.MoveNext())
                {
                    if (cowsEnumerator.Current.EAN.CompareTo(cow.EAN) == 0)
                    {
                        return new NewChunk.CowValidateResult(false, "Obecny juz w tej WZtce",null);
                    }
                }

                return new NewChunk.CowValidateResult(true,null,cow);
            }

        }


        public Cow FindGoodCow(string sEAN)
        {
            ICollection<Cow> singleCow = SQLDB.LoadCows(new cowbase.wheres.AndWhere(
                                                                    new cowbase.wheres.EanWhere(sEAN),
                                                                    new cowbase.wheres.CowInStockWhere()));

            if (singleCow.Count != 1)
                return null;

            IEnumerator<Cow> cowEnumerator = singleCow.GetEnumerator();
            cowEnumerator.MoveNext();

            return cowEnumerator.Current;
        }


    }
}
