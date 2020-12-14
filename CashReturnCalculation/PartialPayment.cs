using System;
using System.Collections.Generic;
using System.Text;

namespace CashReturnCalculation
{
    class PartialPayment
    {
        public CashItem CashItem;
        public int Count;

        public PartialPayment(CashItem cashItem, int count)
        {
            CashItem = cashItem;
            Count = count;
        }
    }
}
