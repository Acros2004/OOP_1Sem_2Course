using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics;
using System.Threading;
using System.IO;
using static System.Console;

namespace lab14
{
    class Program
    {
        public static void begin(object n)
        {
            StreamWriter fout = new StreamWriter("Numbers.txt");
            for (int i = 1; i < (int)n; i++)
            {
                fout.WriteLine(i.ToString());
                WriteLine("Простые числа" + i.ToString());
            }
            fout.Close();
        }
        static void Main(string[] args)
        {
            Process[] proc = Process.GetProcesses();
            foreach (Process x in proc)
            {
                try
                {
                    WriteLine("Id процесса: " + x.Id.ToString());
                    WriteLine("Имя процесса: " + x.ProcessName);
                    WriteLine("Приоритет: " + x.BasePriority.ToString());
                    WriteLine("Время старта: " + x.StartTime.ToString());
                    WriteLine("Время затраты процессора: " + x.TotalProcessorTime.ToString());
                    if (x.StartTime.ToString() != null)
                        WriteLine("Состояние: запущен");
                    WriteLine();
                }
                catch
                {
                    WriteLine();
                }
            }
            AppDomain domain = AppDomain.CurrentDomain;
            WriteLine($"Name: {domain.FriendlyName}");
            WriteLine($"Base Directory: {domain.BaseDirectory}");
            WriteLine($"Setup Information: {domain.SetupInformation}");
            WriteLine();
            Assembly buf = null;
            foreach (Assembly x in domain.GetAssemblies())
            {
                if (x.GetName().Name == "Lab15OOP")
                    buf = x;
                WriteLine(x.ToString());
            }
            AppDomain mydomain = AppDomain.CreateDomain("New domain");
            Assembly buf2 = mydomain.Load(buf.GetName());
            AppDomain.Unload(mydomain);
            WriteLine(buf2.ToString());

            int n;
            bool flag;
            while (true)
            {
                WriteLine("Введите n:");
                flag = int.TryParse(ReadLine(), out n);
                if (flag == false)
                    WriteLine("Неверно введено значение. Введите снова");
                else break;
            }

            Thread mythread = new Thread(new ParameterizedThreadStart(begin));
            mythread.Name = "thread";
            mythread.Priority = ThreadPriority.Highest;
            mythread.Start(n);
            mythread.Suspend();
            WriteLine($"Priority: {mythread.Priority}; Name: {mythread.Name}; State: {mythread.ThreadState}");
            mythread.Resume();
            mythread.Join();

            Thread thread1, thread2;
            Numbers numbers = new Numbers(n);
            thread1 = new Thread(numbers.Odd);
            thread2 = new Thread(numbers.Even);
            thread1.IsBackground = true;
            thread2.IsBackground = true;
            thread2.Priority = ThreadPriority.AboveNormal;
            thread1.Start();
            thread2.Start();

            Thread.Sleep(3000);
            Thread thread3 = new Thread(numbers.Odd1);
            Thread thread4 = new Thread(numbers.Even1);
            thread3.IsBackground = true;
            thread4.IsBackground = true;
            thread3.Priority = ThreadPriority.AboveNormal;
            thread3.Start();
            thread4.Start();
            thread4.Join();
            TimerCallback a = new TimerCallback(numbers.ForTimer);
            Timer timer = new Timer(a, 0, 0, 1000);
            WriteLine("Таймер");
            ReadKey();
        }
    }
}
