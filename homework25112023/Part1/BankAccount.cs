using System;
using System.Collections.Generic;
using System.IO;

namespace Part1
{
    class BankAccount
    {
        public enum BankAccountType
        {
            Current,
            Savings
        }
        private string accountHolder;
        private static int generatedAccountNumber = 1;
        private int accountNumber;
        private decimal accountBalance;
        private BankAccountType accountType;
        private List<BankTransaction> transactionHistory = new List<BankTransaction>();

        /// <summary>
        /// Конструктор, используемый для заполнения полей экземпляра класса BankAccount,
        /// вызывающийся при передаче в него значений accountBalance и accountType
        /// </summary>
        /// <param name="accountBalance">Баланс счёта</param>
        /// <param name="accountType">Тип счёта</param>
        /// <param name="accountHolder">Держатель счёта</param>
        public BankAccount(decimal accountBalance, BankAccountType accountType, string accountHolder)
        {
            accountNumber = GenerateAccountNumber();
            this.accountBalance = accountBalance;
            this.accountType = accountType;
            this.accountHolder = accountHolder;
        }
        /// <summary>
        /// Конструктор, используемый для заполнения полей экземпляра класса BankAccount,
        /// вызывающийся при передаче в него значения accountBalance
        /// </summary>
        /// <param name="accountBalance">Баланс счёта</param>
        /// <param name="accountHolder">Держатель счёта</param>
        public BankAccount(decimal accountBalance, string accountHolder)
        {
            accountNumber = GenerateAccountNumber();
            this.accountBalance = accountBalance;
            accountType = BankAccountType.Current;
            this.accountHolder = accountHolder;
        }
        /// <summary>
        /// Конструктор, используемый для заполнения полей экземпляра класса BankAccount,
        /// вызывающийся при передаче в него значения accountType
        /// </summary>
        /// <param name="accountType">Тип счёта</param>
        /// <param name="accountHolder">Держатель счёта</param>
        public BankAccount(BankAccountType accountType, string accountHolder)
        {
            accountNumber = GenerateAccountNumber();
            accountBalance = 0;
            this.accountType = accountType;
            this.accountHolder = accountHolder;
        }
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public BankAccount()
        {
            accountNumber = GenerateAccountNumber();
            accountBalance = 0;
            accountType = BankAccountType.Current;
            accountHolder = "Not specified";
        }
        public static int GenerateAccountNumber()
        {
            return generatedAccountNumber++;
        }
        public BankTransaction this[int index]
        {
            get
            {
                return transactionHistory[index];
            }
        }
        public string AccountHolder
        {
            get
            {
                return accountHolder;
            }
            set
            {
                accountHolder = value;
            }
        }
        public int AccountNumber
        {
            get
            {
                return accountNumber;
            }
        }
        public decimal AccountBalance
        {
            get
            {
                return accountBalance;
            }
        }
        public BankAccountType AccountType
        {
            get
            {
                return accountType;
            }
        }
        public List<BankTransaction> TransactionHistory
        {
            get
            {
                return transactionHistory;
            }
        }
        public void Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= accountBalance)
            {
                accountBalance -= amount;
                AddTransactionToHistory(amount);
                Console.WriteLine($"Со счёта {accountNumber} было успешно снято {amount}₽!\nТеперь баланс данного счёта составляет {accountBalance}₽\n");
            }
            else if (amount < 0)
            {
                Console.WriteLine("Снятие отрицательной суммы невозможно!");
            }
            else
            {
                Console.WriteLine($"Невозможно снять {amount}₽, так как текущий баланс составляет {accountBalance}₽!\nНедостаточно средств!\n");
            }
        }
        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                accountBalance += amount;
                AddTransactionToHistory(amount);
                Console.WriteLine($"На счёт {accountNumber} было успешно зачислено {amount}₽!\nТеперь баланс данного счёта составляет {accountBalance}₽\n");
            }
            else
            {
                Console.WriteLine("Внесение отрицательной суммы невозможно!\n");
            }
        }
        public void TransferMoney(BankAccount recipient, decimal amount)
        {
            if (amount > 0 && accountBalance >= amount && accountNumber != recipient.accountNumber)
            {
                accountBalance -= amount;
                recipient.accountBalance += amount;
                AddTransactionToHistory(amount);
                Console.WriteLine($"Пользователь со счётом {accountNumber} успешно перевёл {amount}₽ на счёт {recipient.accountNumber}!\nТеперь на его счету {accountBalance}₽\n");
            }
            else if (accountNumber.Equals(recipient.accountNumber))
            {
                Console.WriteLine("Перевод самому себе невозможен!");
            }
            else if (amount <= 0)
            {
                Console.WriteLine("Переводимая сумма должна быть положительной!");
            }
            else
            {
                Console.WriteLine("Перевод невозможен, на счету отправителя недостаточно средств!\nПополните счёт и повторите попытку\n");
            }
        }
        /// <summary>
        /// Метод, добавляющий транзакцию в историю транзакций, для упрощения кода
        /// </summary>
        /// <param name="amount">Сумма</param>
        private void AddTransactionToHistory(decimal amount)
        {
            BankTransaction transaction = new BankTransaction(amount);
            transactionHistory.Add(transaction);
            Console.Write(transaction.PrintInfoAboutTransaction());
        }
        /// <summary>
        /// Метод Dispose, сохраняющий данные о транзакциях аккаунта в файл output.txt, находящийся в \homework28102023\Part1\bin\Debug\output.txt
        /// </summary>
        /// <param name="account">Аккаунт, историю транзакций которого мы сохраняем в файл</param>
        public void Dispose(BankAccount account)
        {
            string outputFileName = "output.txt";
            File.Delete(outputFileName);
            for (int i = 0; i < transactionHistory.Count; i++)
            {
                BankTransaction transaction = transactionHistory[i];
                File.AppendAllText(outputFileName, transaction.PrintInfoAboutTransaction());
            }
            GC.SuppressFinalize(account);
        }
    }
}
