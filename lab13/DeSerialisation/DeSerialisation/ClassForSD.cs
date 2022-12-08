using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DeSerialisation
{
    interface SignatureDocument
    {
        void Signature();
    }
    [Serializable]
    public abstract class Document : SignatureDocument
    {
        public abstract void Signature();
        public string TypeDocument { get; set; }

        public Document(string typeDocument)
        {
            TypeDocument = typeDocument;
        }

    }
    [Serializable]
    [DataContract]
    public class Kvitant : Document, SignatureDocument
    {
        [DataMember]
        public bool sign = false;
        [DataMember]
        public double Fine { get; set; }
        [DataMember]
        public int Sum { get; set; }
        [NonSerialized]
        public int date;
        public Kvitant() : base("Квитанция")
        {
            this.date = -1;
            Fine = -1;
            Sum = -1;
        }
        public Kvitant(int date, double fine, int sum) : base("Квитанция")
        {
            this.date = date;
            Fine = fine;
            Sum = sum;
        }
        public override void Signature()
        {
            sign = true;
        }
        public override string ToString()
        {
            Console.WriteLine($"\tКвитанция- налог: {Fine}, сумма: {Sum}");
            return "\0";
        }
    }
}