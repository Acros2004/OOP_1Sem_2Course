using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab04
{
    class Data
    {
        public int Date
        {
            get;
            set;
        }
        public Data(int data)
        {
            Date = data;
        }
    }
    interface MyOrganization
    {
        bool SignDoc();
        void ShowInfo();
        string ToString();
    }
    abstract class Document
    {
        Data data;
        bool official = false;
        bool signed = false;

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
        
        public Document(int data)
        {
            this.data = new Data(data);
        }
        public virtual void ShowInfo()
        {
            Console.WriteLine($"\nДата: {data.Date}\nПодпись: {signed}\nОфициальный документ: {official}");
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
        public Kvitancia(int _amountServicesUses,int _sum,int data) : base(data)
        {
            Sum= _sum;
            AmountServicesUses = _amountServicesUses;
        }
        public bool SignDoc()
        {
            return Signed = true;
        }
        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine("Количество использованных коммунальных услуг: " + AmountServicesUses);
            Console.WriteLine("Сумма к оплате: " + Sum);
        }
        public override string ToString()
        {
            Console.WriteLine($"\tКвитанция");
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
        public Naklad(int data, string organization,int amountProduct,int sum) : base(data)
        {
            Organization = organization;
            AmountProduct = amountProduct;
            Sum = sum;
        }
        public bool SignDoc()
        {
            return Signed = true;
        }
        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Организация: {Organization}\nКоличество продуктов: {AmountProduct}\nСумма к оплате: {Sum}");
        }
        public override string ToString()
        {
            Console.WriteLine($"\tКвитанция");
            return "\0";
        }
    }
    class Check : Document, MyOrganization
    {
        public int _sum = 0;
        public int _cardNumber = 0;
        public int Sum
        {
            get { return _sum; }
            set { _sum = value; }
        }
        public int CardNumber
        {
            get { return _cardNumber; }
            set { _cardNumber = value; }
        }
        public Check(int date, int sum,int _cardNumber) : base(date)
        {
            Sum = sum;
            CardNumber = _cardNumber;
        }
        public bool SignDoc()
        {
            return Signed = false;
        }
        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Сумма перевода на карту {CardNumber} составляет {Sum} рублей");
        }
        public override string ToString()
        {
            Console.WriteLine("\tЧек");
            return "\0";
        }
    }
}
