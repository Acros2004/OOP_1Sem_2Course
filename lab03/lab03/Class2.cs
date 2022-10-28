using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab03
{
    class Node<T>
    {
        Node<T> next;
        public T Info;
        public Node<T> Next;
    }
    static class StaticOperations
    {
        public static int Count<T>(List<T> list) where T : class
        {
            int count = 0;
            Node<T> curr = list.Head;
            while (curr != null)
            {
                count++;
                curr = curr.Next;
            }
            return count;
        }
        public static string getSumString<T>(List<T> list) where T : class
        {
            string str = "";
            Node<T> curr = list.Head;
            while (curr != null)
            {
                str = str + curr.Info;
                curr = curr.Next;
            }
            return str;
        }
        public static string ListString<T>(List<T> list) 
        {
            string str = "";
            Node<T> curr = list.Head;
            while (curr != null)
            {
                str = str + curr.Info.ToString() + ", ";
                curr = curr.Next;
            }
            return str;
        }
        public static int LongestInfo<T>(List<T> list) where T : struct
        {
            Node<T> curr = list.Head;
            string str = curr.Info.ToString();
            string str2 = curr.Info.ToString();
            while (curr != null)
            {
                if (curr.Info.ToString().Length > str.ToString().Length)
                {
                    str = curr.Info.ToString();
                }
                else
                {
                    str2 =curr.Info.ToString();
                }
                curr = curr.Next;
            }
            int a = str.Length;
            int b = str2.Length;
            a -= b;
            return a;
        }
        public static string FormatText(this string str)
        {
            return char.ToUpper(str[0]) + str.Substring(1).ToLower();
        }
        public static int CountFirstCapitalLetters(this string str)
        {
            int count = 0;
            string[] words = str.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                if (char.IsUpper(word[0]))
                {
                    count++;
                }
            }
            return count;
        }


    }

    static class Extensions
    {
        
        public static bool CheckRepeatings<T>(this List<T> list) where T : class
        {
            Node<T> curr = list.Head;
            while (curr != null)
            {
                Node<T> node = curr.Next;
                while (node != null)
                {
                    if (node.Info.ToString() == curr.Info.ToString())
                    {
                        return true;
                    }
                    else
                    {
                        node = node.Next;
                    }
                }
                curr = curr.Next;
            }
            return false;
        }
    }
}
