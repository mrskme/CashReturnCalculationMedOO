using System;
using System.Collections.Generic;
using System.Text;

namespace CashReturnCalculation
{
    class CashItem
    {
        public int Value;
        public bool IsCoin;

        public CashItem(int value, bool isCoin)
        {
            Value = value;
            IsCoin = isCoin;
        }
    }
}
