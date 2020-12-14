using System;
using System.Collections.Generic;
using System.Text;

namespace CashReturnCalculation
{
    class PartialPayment
    {
        private CashItem CashItem;
        private int Count;

        public int GetCount()
        {
            return Count;
        }

        public CashItem GetCashItem()
        {
            return CashItem;
        }
        public int GetValue()
        {
            return Count * CashItem.Value;
        }

        public PartialPayment(CashItem cashItem, int count)
        {
            CashItem = cashItem;
            Count = count;
        }
    }
}
