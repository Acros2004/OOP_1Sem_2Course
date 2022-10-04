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
            List list1 = new List();
            list1.AddNode("Y");
            list1.AddNode("XX");
            list1.AddNode("Z");

            List list2 = new List();
            list2.AddNode("Y");
            list2.AddNode("XX");
            list2.AddNode("Z");

            list1.ShowInfo();
            Console.Write("\n");
            list2.ShowInfo();
            Console.Write("\nequals : ");
            Console.WriteLine(list1 == list2);
            Console.Write("\n");

            Node node = new Node();
            node.Info = "R";
            list1 = node + list1;
            list1.ShowInfo();
            Console.Write("\n");
            list2.ShowInfo();
            Console.Write("\nnot equals: ");
            Console.WriteLine(list1 != list2);
            Console.Write("\n");

            list1--;
            list1.ShowInfo();
            Console.Write("\n");
            list1 *= list2;
            list1.ShowInfo();
            Console.Write("\n");

            List list3 = new List();
            list3.AddNode("Vie");
            list3.AddNode("gakjK");
            list3.AddNode("jfFJf");
            list3.AddNode("sdhS");
            list3.AddNode("VSVfre");
            list3.ShowInfo();
            Console.Write("\n");

            Console.WriteLine("Количество слов с заглавной буквой " + list3.CountFirstCapitalLetters());
            Console.WriteLine("Повторяющиеся элементы в списке 3 = " + list3.CheckRepeatings());
            Console.WriteLine("Повторяющиеся элементы в списке 2 = " + list2.CheckRepeatings());
            Console.WriteLine("Количество элементов списка 3 =  " + StaticOperations.Count(list3));
            Console.WriteLine(StaticOperations.ListString(list3));
            Console.WriteLine("Сумма(слияние) элементов списка 1 "+StaticOperations.getSumString(list1));
            Console.WriteLine("Разница в количестве символов большего и меньшего элемента в списке 3: " + StaticOperations.LongestInfo(list3));

            string str = "mY NaMe Is NiKiTa";
            Console.WriteLine(str + " изменено: " + StaticOperations.FormatText(str));
            List.Developer person = new List.Developer(123, "Nikita", "BSTU");
            Console.ReadKey();
        }

    }
}
