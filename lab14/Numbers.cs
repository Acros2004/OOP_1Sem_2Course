using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.IO;

namespace lab14
{
    public class Numbers
    {
        public static void First()
        {
            var allProcess = Process.GetProcesses();
            foreach (var process in allProcess)
                try
                {
                    Console.WriteLine($"ID: {process.Id}  Name: {process.ProcessName} Priority: {process.BasePriority} ");
                    Console.WriteLine($"Start time : {process.StartTime}  Total processor time: {process.TotalProcessorTime}\n");
                }
                catch
                {
                    Console.WriteLine();
                }
        }
        public static void Second()
        {
            var domain = AppDomain.CurrentDomain;
            Console.WriteLine($"Name: {domain.FriendlyName}\nConfig datails: {domain.SetupInformation}\n Base Directory: {domain.BaseDirectory}");
            Console.WriteLine("Assemblies: ");
            foreach (var s in domain.GetAssemblies()) Console.WriteLine(s.FullName);

            var newDomain = AppDomain.CreateDomain("Domain");
            newDomain.Load(Assembly.GetExecutingAssembly().GetName());
            AppDomain.Unload(newDomain);
        }
        public static void Third()
        {
            int n;
            bool flag;
            while (true)
            {
                Console.WriteLine("n:");
                flag = int.TryParse(Console.ReadLine(), out n);
                if (flag == false)
                    Console.WriteLine("Неверно введено значение. Введите снова");
                else break;
            }

            Thread mythread = new Thread(new ParameterizedThreadStart(begin));
            mythread.Name = "thread";
            mythread.Priority = ThreadPriority.Highest;
            mythread.Start(n);
            mythread.Suspend();
            Console.WriteLine($"Priority: {mythread.Priority}; Name: {mythread.Name}; State: {mythread.ThreadState}");
            mythread.Resume();
            mythread.Join();

        }
        public static void ShowThreadInfo(object thread)
        {
            var currentThread = thread as Thread;
            Console.WriteLine($"Name: {currentThread.Name} Id: {currentThread.ManagedThreadId} Priority: {currentThread.Priority} Status: {currentThread.ThreadState}");
        }
        public static void begin(object n)
        {
            StreamWriter fout = new StreamWriter("Numbers.txt");
            var first = new Thread(ShowThreadInfo);
            first.Start(Thread.CurrentThread);
            first.Join();
            for (int i = 1; i < (int)n; i++)
            {
                fout.WriteLine(i.ToString());
                Console.WriteLine("Простые числа " + i.ToString());
            }
            fout.Close();
        }
        public static void Fourth()
        {
            var even = new Thread(ShowEvenNumbers) { Priority = ThreadPriority.Highest };
            var odd = new Thread(ShowOddNumbers);
            even.Start();
            odd.Start();
            even.Join();
            odd.Join();

            Console.WriteLine();
            FirstlyEvenSecondlyOdd();
            Console.WriteLine();
            ShowOneByOne();
        }
        private static void ShowOneByOne()
        {
            var mutex = new Mutex();
            var even = new Thread(ShowEvenNumbers);
            var odd = new Thread(ShowOddNumbers);
            odd.Start();
            even.Start();
            even.Join();
            odd.Join();
            void ShowEvenNumbers()
            {
                for (var i = 0; i < 10; i++)
                {
                    mutex.WaitOne();
                    if (i % 2 == 0)
                        Console.Write(i + " ");
                    mutex.ReleaseMutex();
                }
            }
            void ShowOddNumbers()
            {
                for (var i = 0; i < 10; i++)
                {
                    mutex.WaitOne();
                    Thread.Sleep(200);
                    if (i % 2 != 0)
                        Console.Write(i + " ");
                    mutex.ReleaseMutex();
                }
            }
        }
        private static void FirstlyEvenSecondlyOdd()
        {
            var objectToLock = new object();
            var even = new Thread(ShowEvenNumbers);
            var odd = new Thread(ShowOddNumbers);
            even.Start();
            odd.Start();
            even.Join();
            odd.Join();

            void ShowEvenNumbers()
            {
                lock (objectToLock)
                {
                    for (var i = 0; i < 10; i++)
                    {
                        if (i % 2 == 0)
                            Console.Write(i + " ");
                    }
                }
            }

            void ShowOddNumbers()
            {
                for (var i = 0; i < 10; i++)
                {
                    Thread.Sleep(200);
                    if (i % 2 != 0)
                        Console.Write(i + " ");
                }
            }
        }
        private static void ShowEvenNumbers()
        {
            for (var i = 0; i < 10; i++)
            {
                Thread.Sleep(100);
                if (i % 2 == 0)
                    Console.Write(i + " ");
            }
        }
        private static void ShowOddNumbers()
        {
            for (var i = 0; i < 10; i++)
            {
                Thread.Sleep(200);
                if (i % 2 != 0)
                    Console.Write(i + " ");
            }
        }

        public static void Fifth()
        {
            Console.WriteLine();

            TimerCallback timerCallback = new TimerCallback(CurrentTime);
            Timer timer = new Timer(timerCallback, 3, 0, 1000);
            void CurrentTime(object obj)
            {
                for(int i = 0;i < (int)obj; i++)
                {
                    Console.WriteLine(DateTime.Now);
                }
                
            }
           
        }
    }
}
