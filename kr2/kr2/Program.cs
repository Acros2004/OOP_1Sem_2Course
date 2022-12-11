using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    delegate void Del(string s);

    class PersonException : Exception
    {
        public PersonException(string message)
            : base(message) { }
    }
    class Program
    {
        class MyOwn
        {
            public static void my1(string a)
            {
                Console.WriteLine("Martch " + a);
            }
            public static void my2(string a)
            {
                Console.WriteLine("25 " + a);
            }
            public static void my3(string a)
            {
                Console.WriteLine("1921 " + a);
            }
            public static void my4(string a)
            {
                Console.WriteLine("2021 " + a);
            }
            public static void my5(string a)
            {
                Console.WriteLine("December " + a);
            }
        }
        
        class SuperDic<T, R>
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();
            public void getFindElement(int key)
            {
                string found;
                if (dic.TryGetValue(key, out found))
                {
                    Console.WriteLine("Успешно");
                    return;
                }
                else throw new PersonException("Элемент не найден");
            }
            public void Add(int a, string b)
            {
                dic.Add(a, b);
            }


        }
        static void Main(string[] args)
        {


            try
            {
                SuperDic<int, string> dic = new SuperDic<int, string>();
                dic.Add(1, "dasdad");
                dic.Add(2, "dadgggfh");
                dic.getFindElement(3);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            string[] first = { "daddddad", "dfdghfghds", "hsetgfddgf" };
            string[] second = { "errttygfbgjgh", "fryuknfgfhn", "dfsdfdgyuikhg" };

            var uniontest = first.Union(second).Count();
            Console.WriteLine(uniontest);
            Del del1 = MyOwn.my1;
            del1 += MyOwn.my1;
            del1 += MyOwn.my2;
            del1 += MyOwn.my3;
            del1 += MyOwn.my4;
            del1("2004");
        }
    }

}      
