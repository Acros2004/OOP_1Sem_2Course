using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;


namespace lab04
{
    
    partial class Naklad
    {
        
        public override void getOfficial()
        {
            base.getOfficial();
        }
       
        public override void ShowInfo()
        {
            base.ShowInfo();
        }
        public override string ToString()
        {
            Console.WriteLine($"\tНакладная");
            Console.WriteLine($"Организация: {Organization}\nПродукты и их цена: {Products}\nСумма к оплате: {Sum}");
            base.ShowInfo();

            return "\0";
        }
    }
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
    class Controller
    {
        
        public static void ReadFile(Bygalteria collection, string patch)
        {
            string[] textFile = System.IO.File.ReadAllLines(patch);
            for (int i = 0; i < textFile.Length; i++)
            {
                string[] dwordLine = textFile[i].Split(' ');
                // имя цена масса объём
                //collection.addDoc(new Component(Convert.ToDouble(dwordLine[3]), Convert.ToDouble(dwordLine[2]), Convert.ToInt32(dwordLine[1]), dwordLine[0]));
                switch (dwordLine[0])
                {
                    case "Kvitancia":
                        collection.addDoc(new Kvitancia(Convert.ToInt32(dwordLine[1]), Convert.ToInt32(dwordLine[2]), dwordLine[3]));
                        break;
                    case "Naklad":
                        string provString = textFile[i];
                        for(int j = 0; j < 2; j++)
                        {
                            provString = provString.Replace(dwordLine[j],"");
                        }
                        collection.addDoc(new Naklad(dwordLine[1], dwordLine[2], provString, Convert.ToInt32(dwordLine[3])));
                        break;
                    case "Cheak":
                        collection.addDoc(new Check(dwordLine[1], Convert.ToInt32(dwordLine[2]), long.Parse(dwordLine[3])));
                        break;
                }
            }
        }
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
                        string text = kvit.Products.Remove(0, pos);
                        string[] parts = text.Split(new char[] { ' ' });
                        sum += Int32.Parse(parts[1]);
                    }
                }
            }
            return sum;
        }
        public static int ShowAmountOfCheks(Bygalteria ListDOC)
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
        public static void ShowDocDate(Bygalteria ListDocument,string begin, string end)
        {
            string[] period = { begin, end };
            int[] days = new int[3];
            int[] months = new int[3];
            int[] years = new int[3];
            int col = 0;
            foreach (string i in period)
            {
                string[] parts1 = i.Split(new char[] { '.' });
                days[col] = Int32.Parse(parts1[0]);
                months[col] = Int32.Parse(parts1[1]);
                years[col] = Int32.Parse(parts1[2]);
                col++;
            }
            foreach (var i in ListDocument)
            {
                Document document = (Document)i;
                string[] parts = document.Date.Split(new char[] { '.' });
                days[col] = Int32.Parse(parts[0]);
                months[col] = Int32.Parse(parts[1]);
                years[col] = Int32.Parse(parts[2]);
                if ((years[0] < years[2]) || ((years[0] == years[2]) && (months[0] < months[2])) || ((years[0] == years[2]) && (months[0] == months[2]) && (days[0] < days[2])))
                {
                    if ((years[2] < years[1]) || ((years[2] == years[1]) && (months[2] < months[1])) || ((years[2] == years[1]) && (months[2] == months[1]) && (days[2] < days[1])))
                    {
                        document.ShowInfo();
                    }
                }
            }
        }
       
    }
}
