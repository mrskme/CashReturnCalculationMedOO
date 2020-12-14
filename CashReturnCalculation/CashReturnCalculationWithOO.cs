using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CashReturnCalculation
{
    class CashReturnCalculationWithOO
    {
        private readonly List<CashItem> _cashItems;
        private List<PartialPayment> PartialPayments;
        public CashReturnCalculationWithOO()
        {
            _cashItems = new List<CashItem>
            {
                new CashItem(1, true),
                new CashItem(5, true),
                new CashItem(10, true),
                new CashItem(20, true),
                new CashItem(50, false),
                new CashItem(100, false),
                new CashItem(200, false),
                new CashItem(500, false),
                new CashItem(1000, false),
            };
            PartialPayments = new List<PartialPayment>();
            _cashItems.Reverse();
        }
        public void Run()
        {
            Console.WriteLine("Hvor mye skal det betales? ");
            var paymentAmountString = Console.ReadLine();
            var paymentAmount = Convert.ToInt32(paymentAmountString);
            var cashItemCounts = AcceptPayment(_cashItems, paymentAmount);
            var paidAmount = SumAmount(cashItemCounts, _cashItems);
            Console.WriteLine($"Du har betalt {paidAmount}kr.");
            var returnAmount = paidAmount - paymentAmount;
            ShowReturnAmount(returnAmount, _cashItems);
        }

        private void ShowReturnAmount(int returnAmount, List<CashItem> cashItems)
        {
            Console.WriteLine($"Du skal få tilbake {returnAmount}kr:");
            var remaining = returnAmount;
            foreach (var cashItem in cashItems)
            {
                var count = remaining / cashItem.Value;
                if (count > 0)
                {
                    remaining -= count * cashItem.Value;
                    Console.WriteLine($" - {count}x{cashItem.Value}kr");
                }
            }
        }

        private int[] AcceptPayment(List<CashItem> cashItems, int paymentAmount)
        {
            var cashItemCounts = new int[9];
            var sumAmount = 0;
            do
            {
                Console.Write("Angi betaling (eks: 7x5kr betyr sju femkroner): ");
                var paymentString = Console.ReadLine();

                if (!paymentString.Contains("x") || !paymentString.EndsWith("kr")) continue;
                var xIndex = paymentString.IndexOf("x");
                var countString = paymentString.Substring(0, xIndex);
                var isSuccessCount = int.TryParse(countString, out int count);

                if (!isSuccessCount) continue;
                var cashItemString = paymentString.Substring(xIndex + 1).TrimEnd('k','r');
                var isSuccessCashItem = int.TryParse(cashItemString, out int cashItem);

                if (!isSuccessCashItem) continue;
                var cashItemIndex = cashItems.FindIndex(V => V.Value == cashItem);
                var chosenCashItem = cashItems.FirstOrDefault(v => v.Value == cashItem);

                if (cashItemIndex == -1) continue;
                cashItemCounts[cashItemIndex] += count;
                //sumAmount = SumAmount(cashItemCounts, cashItems);

                PartialPayment partialPayment = new PartialPayment(chosenCashItem, count);
                PartialPayments.Add(partialPayment);
                Payment payment = new Payment(PartialPayments);
                sumAmount = payment.SumAmount();

                Console.WriteLine($"Du har betalt {sumAmount}kr.");
            } while (sumAmount < paymentAmount);

            return cashItemCounts;
        }

        public int SumAmount(int[] countOfCashItem, List<CashItem> cashItems)
        {
            var sum = 0;
            for (var i = 0; i < countOfCashItem.Length; i++)
            {
                sum += countOfCashItem[i] * cashItems[i].Value;
            }
            return sum;
        }
    }
}
