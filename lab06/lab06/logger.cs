using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab04
{
    public class Logger
    {
        string TimeLog { get; set; }
        public void FileLoggerWriteLine(string message)
        {
            using StreamWriter streamWriter = new StreamWriter("C:\\Users\\noname\\Desktop\\123\\OOP\\lab06\\lab06\\log.txt", false);
            streamWriter.WriteLine("<-><-><-><-><-><-><-><-><-><-><-><-><-><-><-><->");
            streamWriter.WriteLine(message);
            streamWriter.WriteLine("<-><-><-><-><-><-><-><-><-><-><-><-><-><-><-><->");
            streamWriter.WriteLine("");
        }
        public void FileLoggerWriteError(string TypeLog, string Message, string ObjLog)
        {
            using StreamWriter streamWriter = new StreamWriter("C:\\Users\\noname\\Desktop\\123\\OOP\\lab06\\lab06\\log.txt", true);
            streamWriter.WriteLine("<-><-><-><-><-><-><-><-><-><-><-><-><-><-><-><->");
            streamWriter.WriteLine();
            streamWriter.Write("Тип: ");
            streamWriter.WriteLine(TypeLog);
            streamWriter.Write("Время: ");
            streamWriter.WriteLine(DateTime.Now);
            streamWriter.Write("Сообщение: ");
            streamWriter.WriteLine(Message);
            streamWriter.Write("Объект: ");
            streamWriter.WriteLine(ObjLog);
            streamWriter.WriteLine();
            streamWriter.WriteLine("<-><-><-><-><-><-><-><-><-><-><-><-><-><-><-><->");
        }
        public void ConsoleLoggerError(string TypeLog, string Message, string ObjLog)
        {
            Console.WriteLine("<-><-><-><-><-><-><-><-><-><-><-><-><-><-><-><->");
            Console.WriteLine();
            Console.Write("Тип: ");
            Console.WriteLine(TypeLog);
            Console.Write("Время: ");
            Console.WriteLine(DateTime.Now);
            Console.Write("Сообщение: ");
            Console.WriteLine(Message);
            Console.Write("Объект: ");
            Console.WriteLine(ObjLog);
            Console.WriteLine();
            Console.WriteLine("<-><-><-><-><-><-><-><-><-><-><-><-><-><-><-><->");
        }
    }
}
