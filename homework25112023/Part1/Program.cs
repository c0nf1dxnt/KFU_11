using System;
using System.Text;

namespace Part1
{
    class Program
    {
        static void Task1()
        {
            Console.WriteLine("Task 13.1 & 13.2\nДобавить свойства для чтения полей классов BankAccount & BankTransaction, добавить поле accountHolder со свойством для чтения и записи, добавить индексатор для доступа к объектам BankTransaction\n");

            BankAccount account1 = new BankAccount(1254.21m, BankAccount.BankAccountType.Savings, "Aleksei");
            BankAccount account2 = new BankAccount(1082.15m, BankAccount.BankAccountType.Savings, "Joe");
            account2.AccountHolder = "Anonymous";

            account2.TransferMoney(account1, 1000m);
            account1.Withdraw(1000m);
        }
        static void Task2()
        {
            Console.WriteLine("Hometask 13.1 & 13.2\nДобавить свойства для чтения и заполнения полей класса Building, создать класс для нескольких зданий");

            BuildingArray buildingArray = new BuildingArray();

            buildingArray.AddBuilding(new Building(100, 50, 100, 1));
            buildingArray.AddBuilding(new Building(50, 25, 50, 1));
            buildingArray.AddBuilding(new Building(200, 100, 200, 2));
            buildingArray.AddBuilding(new Building(300, 150, 300, 3));
            buildingArray.AddBuilding(new Building(20, 10, 20, 1));
            buildingArray.AddBuilding(new Building(100, 50, 100, 1));
            buildingArray.AddBuilding(new Building(50, 25, 50, 1));
            buildingArray.AddBuilding(new Building(200, 100, 200, 2));
            buildingArray.AddBuilding(new Building(300, 150, 300, 3));
            buildingArray.AddBuilding(new Building(20, 10, 20, 1));


            for (int i = 0; i < buildingArray.BuildingsArray.Length; i++)
            {
                Console.WriteLine(buildingArray[i].ToString());
            }
        }
        static void Main()
        {
            Console.Title = "Skynet";
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            Task1();
            Task2();

            Console.ReadKey();
        }
    }
}
