using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace lab08
{
    class Programmer
    {

        public delegate void LANG(List<string> list);
        public event LANG Delete;
        public event LANG Mutate;

        public void dele(List<string> list)
        {
            Console.Write("Ведите номер элемента, который хотите удалить(начиная с 0): ");
            int num = int.Parse(Console.ReadLine());
            list.RemoveAt(num);
            Delete?.Invoke(list);
        }

        public void Perenos(List<string> list)
        {
            Random random = new Random();
            List<string> NewList = list.OrderBy(item => random.Next()).ToList();
            list.Clear();
            list.AddRange(NewList);
            Mutate?.Invoke(list);
        }
    }
    class StringEditor
    {
        public static string RemovePunctuation(string str)
        {
            str = Regex.Replace(str, "[.,;:]", string.Empty);
            return str;
        }

        public static string AddSymbol(string str)
        {
            return str += "Lab08";
        }

        public static string ToUpper(string str)
        {
            return str.ToUpper();
        }

        public static string ToLower(string str)
        {
            return str.ToLower();
        }

        public static string RemoveSpace(string str)
        {
            return str.Replace(" ", string.Empty);
        }
    }
}
