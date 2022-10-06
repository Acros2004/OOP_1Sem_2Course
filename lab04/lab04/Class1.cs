using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab04
{
    
    interface MyOrganization
    {
        bool SignDoc();
        bool OfficialDocument();
        void ShowInfo();
        string ToString();
    }
    abstract class Document
    {
        string _data = string.Empty;
        bool official = false;
        bool signed = false;

        public string Data
        {
            get { return _data; }
            set { _data = value; }
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
            Data = data;
        }
        public virtual void ShowInfo()
        {
            Console.WriteLine($"\nДата: {Data}\nПодпись: {signed}\nОфициальный документ: {official}");
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
        public Kvitancia(int _amountServicesUses,int _sum,string data) : base(data)
        {
            Sum= _sum;
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
        public Naklad(string data, string organization,int amountProduct,int sum) : base(data)
        {
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
            Console.WriteLine($"\tКвитанция");
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
        public Check(string date, int sum,long _cardNumber) : base(date)
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
