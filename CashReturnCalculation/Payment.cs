using System;
using System.Collections.Generic;
using System.Text;

namespace CashReturnCalculation
{
    class Payment
    {
        private List<PartialPayment> _payments;

        public Payment(List<PartialPayment> payment)
        {
            _payments = payment;
        }

        public int SumAmount()
        {
            var sum = 0;
            for (var i = 0; i < _payments.Count; i++)
            {
                sum += _payments[i].Count * _payments[i].CashItem.Value;
            }
            return sum;
        }
    }
}
