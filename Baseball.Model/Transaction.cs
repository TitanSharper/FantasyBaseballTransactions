using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Baseball.Model
{
    public class TransactionTrend
    {
        public int Adds = 0;
        public int Drops = 0;
        public DateTime DateOfSample = DateTime.Now;

        public override string ToString()
        {
            return string.Format("{0}: +{1} -{2}", DateOfSample, Adds, Drops);
        }
    }
    public class TransactionTrends : Collection<TransactionTrend>
    {
        public TransactionTrend GetLast()
        {
            return this.Last();
        }
    }
}
