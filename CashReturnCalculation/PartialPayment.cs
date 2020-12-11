using System;
using System.Collections.Generic;
using System.Text;

namespace CashReturnCalculation
{
    class PartialPayment
    {
        private CashItem _cashItem;
        private int _amount;

        public PartialPayment(CashItem cashItem, int amount)
        {
            _cashItem = cashItem;
            _amount = amount;
        }
    }
}
