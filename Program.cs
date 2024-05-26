using ClassLibrary10;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаба12
{
    internal class Program
    {
        public static void PrintMenu()
        {
            Console.WriteLine("\n\t\t<<<<<Меню>>>>>\n");
            Console.WriteLine("1. Сформировать список\n" +
                "2. Печать листа \n" +
                "3. Добавление после заданного элемента\n" +
                "4. Удаление четных элементов\n" +
                "5. Копия листа\n" +
                "");
        }
        static void AddItem(MyList<BankCard> list)
        {
            BankCard m1 = new BankCard();
            m1.RandomInit();
            int number;
            Console.WriteLine("Введите номер, после которого нужно добавить элемент:");
            number = Convert.ToInt32(Console.ReadLine());
            list.AddAfterPos(number, m1);
            Console.WriteLine($"элемент после которого добавляется элемент: {list.FindItem(number)}\n");
            Console.WriteLine($"добавляемый элемент : {m1}\n");
            list.PrintList();
        }


        static void Main(string[] args)
        {
            string answer = null;
            MyList<BankCard> list = null;
            //MyList<BankCard> list = new MyList<BankCard>();
            //int answer = 1;

            PrintMenu();
            
            while (answer != "6")
            {
                Console.Write("Ваш выбор: ");
                answer = Console.ReadLine();
                switch (answer)
                {
                    case "1":
                        list = new MyList<BankCard>(5);
                        Console.WriteLine("Список сформирован");
                        break;
                    case "2":
                        try
                        {
                            list.PrintList();
                            
                        }
                
                        
                         catch
                        {
                            Console.WriteLine("Сначала сформируйте список.");
                        }
                        break;
                    case "3":
                        try
                        {
                            AddItem(list);

                            //BankCard bcard1 = new BankCard();
                            //bcard1.RandomInit();
                            //list.AddAfterPos(bcard1, bcard1);
                            //Console.WriteLine("Элемент добавлен после заданного элемента");

                        }
                        catch
                        {
                            Console.WriteLine("Сначала сформируйте список.");
                        }
                        break;
                        
                    case "4":
                        try
                        {
                            //BankCard bcard2 = new BankCard();
                            //bcard2.Init();
                            list.RemoveNodesWithEvenIndexes();
                            Console.WriteLine("Элементы удалены");
                            list.PrintList();
                        }
                        catch
                        {
                            Console.WriteLine("Сначала сформируйте список.");
                        }
                        break;
                    case "5":
                        try
                        {
                            Console.WriteLine();
                            Console.WriteLine("Оригинал:\n");
                            list.PrintList();
                            Console.WriteLine();
                            Console.WriteLine("Копия:\n");
                            MyList<BankCard> listcop = list.MakeDeepCopy(list);
                            listcop.PrintList();
                            
                        }
                        catch 
                        {
                            Console.WriteLine("Сначала сформируйте список.");
                        }
                            break;
                    default:
                        Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                        break;

     
                
                }
            }
        }
    }
}                
            
        
    

