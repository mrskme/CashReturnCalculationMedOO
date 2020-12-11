using System;
using System.Collections.Generic;
using System.Text;

namespace CashReturnCalculation
{
    class Payment
    {
        private PartialPayment[] _payment;

        public Payment(PartialPayment[] payment)
        {
            _payment = payment;
        }
    }
}
