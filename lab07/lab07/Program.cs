using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab03
{
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                List<string> list = new List<string>();
                Console.WriteLine(" - - - - - Вывод списка string  - - - - - - - ");
                list.AddNode("sdfsfds");
                list.AddNode("sdf");
                list.AddNode("sfsfds");
                list.ShowInfo();
                Console.WriteLine(" - - - - - Вывод списка удалили элемент sdf- - - - - - - ");
                list.DeleteNode("sdf");
                //list.DeleteNode("sdf123");
                list.ShowInfo();
                Console.WriteLine("Количество элементов списка Check " + StaticOperations.Count(list));
                Console.WriteLine(" - - - - - Вывод списка инт  - - - - - - - ");
                List<int> listInt = new List<int>();
                listInt.AddNode(12);
                listInt.AddNode(13);
                listInt.AddNode(345);
                listInt.ShowInfo();
                Console.WriteLine(" - - - - - Вывод списка инт удалили 12 - - - - - - - ");
                listInt.DeleteNode(12);
                listInt.FoundNode(132313);
                Console.WriteLine(" - - - - - Вывод инта - - - - - - - ");
                listInt.ShowInfo();
                //Console.WriteLine("Количество элементов списка int " + StaticOperations.Count(listInt));

                Check newcheck = new Check("12.11.2004", 12, 31233131);
                Check newcheck2 = new Check("1.11.2004", 123, 31233131);
                Check newcheck3 = new Check("11.11.2004", 1234, 31233131);

                Console.WriteLine(" - - - - - Вывод списка Сheck - - - - - - - ");
                List<Check> listCheck = new List<Check>();
                listCheck.AddNode(newcheck);
                listCheck.AddNode(newcheck2);
                listCheck.AddNode(newcheck3);
                listCheck.ShowInfo();
                Console.WriteLine(" - - - - - Вывод списка Сheck удалили сумму 12 - - - - - - - ");
                listCheck.DeleteNode(newcheck);
                listCheck.ShowInfo();
                Console.WriteLine("Количество элементов списка Check " + StaticOperations.Count(listCheck));
                Check newcheck4 = new Check("Пример", 53454, 1233141313);
                Node<Check> node = new Node<Check>();
                node.Info = newcheck4;
                listCheck = node + listCheck;
                Console.WriteLine("------------------------------------------");
                listCheck.ShowInfo();
                Console.WriteLine("------------------------------------------");
                listCheck--;
                listCheck.ShowInfo();
                Console.WriteLine("------------------------------------------");
                List<Check> listCheck2 = new List<Check>();
                listCheck2.AddNode(newcheck);
                listCheck2.AddNode(newcheck2);
                listCheck2.AddNode(newcheck3);
                Console.WriteLine(listCheck == listCheck2);

                List<Check> list4 = new List<Check>();
                List<string> list6 = new List<string>();
                List<int> list7 = new List<int>();
                Streams<Check>.ReadFile(ref list4, ref list6, ref list7, @"C:\Users\noname\Desktop\123\OOP\lab07\out.txt");
                Console.WriteLine("-------------------------------------------Вывод считанных данных");
                list4.ShowInfo();
                list6.ShowInfo();
                list7.ShowInfo();



                List<Check> list5 = new List<Check>();
                list5.AddNode(new Check("99999", 11111, 12));
                list5.AddNode(new Check("44444", 222222, 13));
                list5.AddNode(new Check("111111", 33333, 11));
                Console.WriteLine("------------------------------------------- Данные которые запишутся в файл");
                list5.ShowInfo();

                Streams<Check>.InFile(ref list5, @"C:\Users\noname\Desktop\123\OOP\lab07\in.txt");
                //Streams<string>.InFile(ref list6, @"C:\Users\noname\Desktop\123\OOP\lab07\in.txt");
            }
            catch (DeleteNotFounded exception)
            {
                Console.WriteLine($"Произошла ошибка: {exception.Message}");
            }
            finally
            {
                Console.WriteLine("тест закончился");
            }

        }

    }
}
