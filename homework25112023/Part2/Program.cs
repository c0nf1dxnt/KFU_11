#define DEBUG_ACCOUNT
using System;
using System.Linq;
using System.Text;

namespace Part2
{
    class Program
    {
        static void Task1()
        {
            Console.WriteLine("Task 14.1\nИспользовать условный атрибут для условного выполнения кода, добавить в BankAccount" +
                "метод DumpToScreen(), зависящий\nот символа условной компиляции\n");

            BankAccount account = new BankAccount(1000000m, BankAccount.BankAccountType.Current, "Dog");

            account.DumpToScreen();
        }
        static void Task2()
        {
            Console.WriteLine("Task 14.2\nСоздать пользовательский атрибут DeveloperInfoAttribute, который позволяет хранить\n" +
                "в метаданных класса имя разработчка и дату разработки класса. Атрибут должен позволять многократное использование\n" +
                "использовать этот атрибут для записи имени разработчика класса RationalNumber\n");

            Type type = typeof(RationalNumber);
            object[] attributes = type.GetCustomAttributes(false);
            foreach (var attribute in attributes.OfType<DeveloperInfoAttribute>())
            {
                Console.WriteLine($"Имя разработчика класса RationalNumber: {attribute.DeveloperName}, дата создания класса {attribute.Date}\n");
            }
        }
        static void Task3()
        {
            Console.WriteLine("Hometask 14.1\nСоздать пользовательский атрибут для класса Building, атрибут позволяет хранить\n" +
                "в метаданных класса имя разработчика и название организации\n");

            Type type = typeof(Building);
            object[] attributes = type.GetCustomAttributes(false);
            foreach (var attribute in attributes.OfType<DeveloperInfoV2Attribute>())
            {
                Console.WriteLine($"Имя разработчика класса Building: {attribute.DeveloperName}, " +
                    $"организация: {attribute.Organization}\n");
            }
        }
        static void Main()
        {
            Console.Title = "Skynet";
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            Task1();
            Task2();
            Task3();

            Console.ReadKey();
        }
    }
}
