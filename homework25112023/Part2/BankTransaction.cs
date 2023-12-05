using System;

namespace Part2
{
    class BankTransaction
    {
        private DateTime transactionTime;
        private decimal amount;

        public BankTransaction(decimal amount)
        {
            transactionTime = DateTime.Now;
            this.amount = amount;
        }
        public DateTime TransactionTime
        {
            get
            {
                return transactionTime;
            }
        }
        public decimal Amount
        {
            get
            {
                return amount;
            }
        }
        public string PrintInfoAboutTransaction()
        {
            return $"Транзакция на сумму {amount}₽ была совершена в {transactionTime}\n";
        }
    }
}
