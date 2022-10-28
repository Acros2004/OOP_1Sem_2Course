using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab03
{
    interface IList<T>
    {
        void AddNode(T info);
        void ShowInfo();
        void DeleteNode(T info);

    }
    class List<T>: IList<T> 
    {
        Node<T> tail;
        Node<T> head;
        int length;
        public List()
        {
              
            tail = null;
            head = null;
            length = 0;
        }
        public Node<T> Head
        {
            get => head;
        }

        public void AddNode(T info)
        {
            Node<T> node = new Node<T>();
            node.Info = info;
            if (head == null)
            {
                head = node;
            }
            else
            {
                tail.Next = node;
            }
            tail = node;
            length++;
        }
        public void DeleteNode(T info)
        {
            Node<T> curr = head;
            Node<T> prev = null;
            bool flag = false;
            while (curr != null)
            {
                if (curr.Info.Equals(info))
                {
                    if (prev != null)
                    {
                        prev.Next = curr.Next;
                        if (curr.Next == null)
                            tail = prev;
                    }
                    else
                    {
                        head = head.Next;

                        if (head == null)
                            tail = null;
                    }
                    flag = true;
                }
                prev = curr;
                curr = curr.Next;
            }
            if (!flag) throw new DeleteNotFounded("Не найден элемент для удалянеия");
        }
        public void ShowInfo()
        {
            Node<T> node = head;
            while (node != null)
            {
                Console.WriteLine(node.Info.ToString());
                node = node.Next;
            }
        }
        public static List<T> operator +(Node<T> node, List<T> list)
        {
            node.Next = list.head;
            list.head = node;
            if (list.length == 0)
            {
                list.tail = list.head;
            }
            list.length++;
            return list;
        }
        public static List<T> operator --(List<T> list)
        {
            list.head = list.head.Next;
            list.length--;
            return list;
        }
        public static bool operator !=(List<T> list1, List<T> list2)
        {
            if (list1.length != list2.length)
            {
                return true;
            }
            Node<T> curr1 = list1.head;
            Node<T> curr2 = list2.head;
            while (curr1 != null)
            {
                if (curr1.Info.ToString() != curr2.Info.ToString())
                {
                    return true;
                }
                else
                {
                    curr1 = curr1.Next;
                    curr2 = curr2.Next;
                }
            }
            return false;
        }
        public static bool operator ==(List<T> list1, List<T> list2)
        {
            if (list1.length != list2.length)
            {
                return false;
            }
            Node<T> curr1 = list1.head;
            Node<T> curr2 = list2.head;
            while (curr1 != null)
            {
                if (curr1.Info.ToString() != curr2.Info.ToString())
                {
                    return false;
                }
                else
                {
                    curr1 = curr1.Next;
                    curr2 = curr2.Next;
                }
            }
            return true;
        }
        public static List<T> operator *(List<T> list1, List<T> list2)
        {
            Node<T> curr2 = list2.head;
            while (curr2 != null)
            {
                list1.tail.Next = curr2;
                list1.tail = curr2;
                curr2 = curr2.Next;
                list1.length++;
            }
            return list1;
        }
      
    }
}
