using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace lab04
{
    class Program
    {
        static void Main(string[] args)
        {
            //Document docKvit = new Kvitancia(7, 112, "12.01.2020");
            //Kvitancia Kvit = docKvit as Kvitancia;
            //if (Kvit is Kvitancia)
            //{
            //    Kvit.ShowInfo();
            //    Kvit.ToString();
            //}
            //MyOrganization docNaklad = new Naklad("11.11.2022", "Баунти", " Молоко 33 Яблоки 24 Кофе 123", 111);
            //if (docNaklad is Naklad)
            //{
            //    Naklad naklad1 = (Naklad)docNaklad;
            //    naklad1.SignDoc();
            //    naklad1.ShowInfo();
            //    naklad1.ToString();
            //}
            //Document check = new Check("12,03,2022", 12345, 374761464767);
            //if (check is Check check1)
            //{
            //    check1.ShowInfo();
            //    check1.ToString();
            //}
            //check = check as Check;
            //Naklad nakl = docNaklad as Naklad;
            //Document[] docs = { Kvit, check, nakl };
            //Printer printer = new Printer();
            //Console.WriteLine("Вызываем метод класса Printer:");
            //foreach (var item in docs)
            //{
            //    printer.IAmPrinting(item);
            //    Console.WriteLine();
            //}

            //5

            Bygalteria bygalteria = new Bygalteria();
            Document[] documents = { new Naklad("11.11.2022", "Баунти", " Молоко 33 Яблоки 24 Кофе 123", 111), new Naklad("02.12.2022", "Сон", " Кофе 11 Йогурт 55", 312), new Naklad("25.09.2022", "Сон", " Молоко 1021 Йогурт 66", 0), new Check("13.03.2022", 12345, 374761464767), new Check("01.03.2022", 12345, 374761464767), new Kvitancia(7, 112, "23.09.2022"), new Kvitancia(7, 112, "12.01.2020") };
            foreach (var i in documents)
            {
                i.getOfficial();
                bygalteria.addDoc(i);
            }
            bygalteria.Show();
            bygalteria.removeDoc(6);
            bygalteria.Show();

            Console.WriteLine($"\nОбщая сумма некоторого товара из всех накладных составляет: {Controller.Nakladsum(bygalteria, "Молоко")}");
            Console.WriteLine($"Количество чеков составило: {Controller.ShowAmountOfCheks(bygalteria)}");
            Console.WriteLine($"\nДокументы входящие в промежуток с 14.03.2022 до 23.11.2022");
            Controller.ShowDocDate(bygalteria, "14.03.2022", "23.11.2022");

            Console.WriteLine("\n\n- - - - - - - - Тест чтения файла - - - - - - - -");
            Bygalteria container = new Bygalteria();
            Controller.ReadFile(container, @"C:\Users\noname\Desktop\123\OOP\lab05\test.txt");
            container.Show();

            try
            {
                int testpr = 0;
                Logger logger = new Logger();
                logger.FileLoggerWriteLine("Log-файл успесно создан");
                try
                {
                    Bygalteria test1 = new Bygalteria();
                    //test1.Show();
                    //test1.removeDoc(1);
                    Check doc3 = new Check("12.11.2003", 123, 123556);
                    for (int i = 0; i < 12; i++)
                    {
                        test1.addDoc(doc3);
                    }
                    documents[13].ToString();

                    int test3 = 0;
                    test3 /= 0;
                }
                catch (DivideByZeroException exception) when (testpr != 1)
                {
                    logger.FileLoggerWriteError("Error NullReferenceException", exception.Message, exception.StackTrace);
                    logger.ConsoleLoggerError("Error NullReferenceException", exception.Message, exception.StackTrace);
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Попытка поднлить на ноль");
                }
                catch (NullCollectionException exception)
                {
                    Console.WriteLine($"ПРОИЗОШЛА ОШИБКА: {exception.Message}");
                }
                catch (MaxCollection exception) when (testpr != 1)
                {
                    logger.FileLoggerWriteError("Error Class MaxCollection", exception.Message, exception.StackTrace);
                    logger.ConsoleLoggerError("Error class MaxCollections", exception.Message, exception.StackTrace);
                }
                catch (MaxCollection exception)
                {
                    Console.WriteLine($"ПРОИЗОШЛА ОШИБКА: {exception.Message}");
                }
                catch (DeleteNullObject exception)
                {
                    Console.WriteLine($"ПРОИЗОШЛА ОШИБКА: {exception.Message}");
                }
                catch 
                {
                    Console.WriteLine("Поиск возможной причины исключения выше");
                    throw;
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Вы пытались обратитьс к элементу которого не существует, и как такое понимать?");
            }
            catch 
            {
                Console.WriteLine("Исключение необработано");
            }
            finally
            {
                Console.WriteLine("Тест закончился");
            }


            Console.ReadKey();
        }
    }
}