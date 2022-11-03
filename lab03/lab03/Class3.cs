using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab03
{
    class DATA
    {
        public string Date
        {
            get;
            set;
        }
        public DATA(string date)
        {
            Date = date;
        }
    }

    interface MyOrganization
    {
        bool SignDoc();
        bool OfficialDocument();
        void ShowInfo();
        string ToString();
    }
    abstract class Document
    {
        DATA date;
        bool official = false;
        bool signed = false;

        public string Date
        {
            get { return date.Date; }
        }

        public bool Signed
        {
            get { return signed; }
            set { signed = value; }
        }
        public bool Official
        {
            get { return official; }
            set { official = value; }
        }

        public Document(string data)
        {
            this.date = new DATA(data);
        }
        public virtual void ShowInfo()
        {
            Console.WriteLine($"\nДата: {date.Date}\nПодпись: {signed}\nОфициальный документ: {official}");
        }
        public override string ToString()
        {
            return "Документ";
        }
       
    }
    class Check : Document, MyOrganization
    {
        public int _sum = 0;
        public long _cardNumber = 0;
        public string _data;
        public int Sum
        {
            get { return _sum; }
            set { _sum = value; }
        }
        public long CardNumber
        {
            get { return _cardNumber; }
            set { _cardNumber = value; }
        }
        public Check(string date, int sum, long _cardNumber) : base(date)
        {
            Sum = sum;
            CardNumber = _cardNumber;
            _data = date;
        }
        public bool SignDoc()
        {
            return Signed = false;
        }
        public bool OfficialDocument()
        {
            return Official = true;
        }
        public override void ShowInfo()
        {
            base.ShowInfo();
        }
        public override string ToString()
        {
            string str = $"Check {_data} {Sum} {CardNumber}";
            return str;
        }
    }
    class Streams<T> where T : class
    {
       
        public static void InFile(ref List<T> list, string patch)
        {
            Node<T> node = list.Head;
            string str2 = "";
            using (StreamWriter sw = new StreamWriter(patch, false, Encoding.Default))
            {
                while (node != null)
                {
                    if (node.Info is Check)
                    {
                        str2 = node.Info.ToString() + "\n";
                        sw.WriteLine(str2);
                        node = node.Next;

                    }
                    else if (node.Info is int)
                    {
                        str2 = $"int {node.Info}\n";
                        sw.WriteLine(str2);
                        node = node.Next;

                    }
                    else if(node.Info is string)
                    {
                        str2 = $"string {node.Info}\n";
                        sw.WriteLine(str2);
                        node = node.Next;

                    }
                }
                   
            }
                
        }


        public static void ReadFile(ref List<Check> collection, ref List<string> collection2, ref List<int> collection3, string patch)
        {
            string[] textFile = System.IO.File.ReadAllLines(patch);
            for (int i = 0; i < textFile.Length; i++)
            {
                string[] dwordLine = textFile[i].Split(' ');
               switch (dwordLine[0])
                {
                    case "Check":
                        collection.AddNode(new Check(dwordLine[1], Convert.ToInt32(dwordLine[2]), long.Parse(dwordLine[3])));
                        break;
                    case "string":
                        collection2.AddNode(dwordLine[1]);
                        break;
                    case "int":
                        collection3.AddNode(Convert.ToInt32(dwordLine[1]));
                        break;
                }
            }
        }
     
    }
}
