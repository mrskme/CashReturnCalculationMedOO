using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CashReturnCalculation
{
    class Payment
    {
        private List<PartialPayment> _payments;

        public Payment()
        {
            _payments = new List<PartialPayment>();
        }

        public int SumAmount()
        {
            var sum = 0;
            for (var i = 0; i < _payments.Count; i++)
            {
                sum += _payments[i].GetValue();
            }
            return sum;
        }

        public static Payment GetAmount(int returnAmount, List<CashItem> cashItems)
        {
            var payment = new Payment();
            var remaining = returnAmount;
            foreach (var cashItem in cashItems)
            {
                var count = remaining / cashItem.Value;
                if (count > 0)
                {
                    payment._payments.Add(new PartialPayment(cashItem, count));
                    remaining -= count * cashItem.Value;
                }
            }
            return payment;
        }

        public void Show()
        {
            foreach (var payment in _payments)
            {
                Console.WriteLine($"- {payment.GetCount()}x{payment.GetCashItem().Value}kr");
            }
        }

        public void AddPayment(List<CashItem> cashItems, string paymentString)
        {
            if (!paymentString.Contains("x") || !paymentString.EndsWith("kr")) return;
            var xIndex = paymentString.IndexOf("x");
            var countString = paymentString.Substring(0, xIndex);
            var isSuccessCount = int.TryParse(countString, out int count);

            if (!isSuccessCount) return;
            var cashItemString = paymentString.Substring(xIndex + 1).TrimEnd('k', 'r');
            var isSuccessCashItem = int.TryParse(cashItemString, out int cashItem);

            if (!isSuccessCashItem) return;
            var chosenCashItem = cashItems.FirstOrDefault(v => v.Value == cashItem);

            if (chosenCashItem == null) return;
            _payments.Add(new PartialPayment(chosenCashItem, count));
        }
        //do
//            {
//                Console.Write("Angi betaling (eks: 7x5kr betyr sju femkroner): ");
//                var paymentString = Console.ReadLine();

//                if (!paymentString.Contains("x") || !paymentString.EndsWith("kr")) continue;
//                var xIndex = paymentString.IndexOf("x");
//                var countString = paymentString.Substring(0, xIndex);
//                var isSuccessCount = int.TryParse(countString, out int count);

//                if (!isSuccessCount) continue;
//                var cashItemString = paymentString.Substring(xIndex + 1).TrimEnd('k','r');
//                var isSuccessCashItem = int.TryParse(cashItemString, out int cashItem);

//                if (!isSuccessCashItem) continue;
//                var chosenCashItem = cashItems.FirstOrDefault(v => v.Value == cashItem);

//                if (chosenCashItem == null) continue;

//                PartialPayment partialPayment = new PartialPayment(chosenCashItem, count);
//                PartialPayments.Add(partialPayment);
//                payment = new Payment(PartialPayments);
//                sumAmount = payment.SumAmount();

//                Console.WriteLine($"Du har betalt {sumAmount}kr.");
//            } while (sumAmount < paymentAmount);
//            return payment;
    }
}

//namespace CashReturnCalculation
//{
//    class Payment
//    {
//        private List<PartialPayment> _payments;

//        public Payment(List<PartialPayment> payment)
//        {
//            _payments = payment;
//        }

//        public int SumAmount()
//        {
//            var sum = 0;
//            for (var i = 0; i < _payments.Count; i++)
//            {
//                sum += _payments[i].Count * _payments[i].CashItem.Value;
//            }
//            return sum;
//        }
//    }
//}
