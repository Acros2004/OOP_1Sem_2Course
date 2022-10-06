using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab04
{
    class Program
    {
        static void Main(string[] args)
        {
            Document docKvit = new Kvitancia(7, 112, "12.01.2020");
            Kvitancia Kvit = docKvit as Kvitancia;
            if (Kvit is Kvitancia)
            {
                Kvit.ShowInfo();
                Kvit.ToString();
            }
            MyOrganization docNaklad = new Naklad("11.11.2022", "Баунти", 11111, 111);
            if (docNaklad is Naklad)
            {
                Naklad naklad1 = (Naklad)docNaklad;
                naklad1.SignDoc();
                naklad1.OfficialDocument();
                naklad1.ShowInfo();
                naklad1.ToString();
            }
            Document check = new Check("12,03,2022", 12345, 374761464767);
            if(check is Check check1)
            {
                check1.ShowInfo();
                check1.ToString();
            }
            check = check as Check;
            Naklad nakl = docNaklad as Naklad;
            Document[] docs = { Kvit, check, nakl };
            Printer printer = new Printer();
            Console.WriteLine("Вызываем метод класса Printer:");
            foreach (var item in docs)
            {
                printer.IAmPrinting(item);
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}