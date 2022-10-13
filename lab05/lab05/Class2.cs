using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab04
{
    class Bygalteria : System.Collections.IEnumerable
    {
        private readonly List<Document> ListDocument;
        public List<Document> GetList
        {
            get;
            set;
        }
        public Bygalteria()
        {
            ListDocument = new List<Document>();
        }
        public void addDoc(Document obj)
        {
            ListDocument.Add(obj);
        }
        public bool removeDoc(int position)
        {
            if (position < ListDocument.Count)
            {
                Console.WriteLine($"Элемент {position} удалён");
                ListDocument.RemoveAt(position);
                return true;
            }
            else return false;
        }
        public void Show()
        {
            Console.WriteLine("============СПИСОК============");
            foreach (Document obj in ListDocument)
            {
                Console.Write(obj);
            }
            Console.WriteLine("\n=============================");
        }
        public System.Collections.IEnumerator GetEnumerator()
        {
            return ListDocument.GetEnumerator();
        }
    }
    class СontrollerByx
    {
        public static int Nakladsum(Bygalteria ListDocument,string nameOfProduct)
        {
            int sum = 0;
            foreach (var i in ListDocument)
            {
                if (i is Naklad)
                {
                    Naklad kvit = (Naklad)i;
                    int pos = kvit.Products.IndexOf(nameOfProduct);
                    if( pos != -1)
                    {
                        string text = kvit.Products.Remove(0, pos + 1);
                        string[] parts = text.Split(new char[] { ' ' });
                        sum += Int32.Parse(parts[1]);
                    }
                }
            }
            return sum;
        }
        public static int NumberOfCheks(Bygalteria ListDOC)
        {
            int sum = 0;
            foreach (var i in ListDOC)
            {
                if (i is Check)
                {
                    sum++;
                }
            }
            return sum;
        }
        public static void ShowDocDate(Bygalteria ListDocument)
        {
            
        }
       
    }
}
