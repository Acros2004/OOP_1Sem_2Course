using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab04
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
    sealed class Kvitancia : Document, MyOrganization
    {
        public int amountServicesUses = 0;
        public int sum = 0;
        public int Sum
        {
            get { return sum; }
            set { sum = value; }
        }
        public int AmountServicesUses
        {
            get { return amountServicesUses; }
            set { amountServicesUses = value; }
        }
        public Kvitancia(int _amountServicesUses, int _sum, string data) : base(data)
        {
            Sum = _sum;
            AmountServicesUses = _amountServicesUses;
        }
        public bool SignDoc()
        {
            return Signed = true;
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
            Console.WriteLine($"\tКвитанция");
            Console.WriteLine("Количество использованных коммунальных услуг: " + AmountServicesUses);
            Console.WriteLine("Сумма к оплате: " + Sum);
            return "\0";
        }
    }
    class Naklad : Document, MyOrganization
    {
        public string _organization;
        public int amountProduct = 0;
        public int _sum = 0;
        public string products;

        public int Sum
        {
            get { return _sum; }
            set { _sum = value; }
        }
        public int AmountProduct
        {
            get { return amountProduct; }
            set { amountProduct = value; }
        }
        public string Organization
        {
            get { return _organization; }
            set { _organization = value; }
        }
        public string Products
        {
            get { return products; }
            set { products = value; }
        }

        public Naklad(string data, string organization, string products, int sum) : base(data)
        {
            Products = products;
            Organization = organization;
            AmountProduct = amountProduct;
            Sum = sum;
        }
        public bool SignDoc()
        {
            return Signed = true;
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
            Console.WriteLine($"\tНакладная");
            Console.WriteLine($"Организация: {Organization}\nКоличество продуктов: {AmountProduct}\nСумма к оплате: {Sum}");
            return "\0";
        }
    }
    class Check : Document, MyOrganization
    {
        public int _sum = 0;
        public long _cardNumber = 0;
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
            Console.WriteLine("\tЧек");
            Console.WriteLine($"Сумма перевода на карту {CardNumber} составляет {Sum} рублей");
            return "\0";
        }
    }
    class Printer
    {
        public virtual void IAmPrinting(Document doc)
        {
            Console.WriteLine($"\t{doc.GetType().Name}");
            doc.ToString();
        }
    }
}
