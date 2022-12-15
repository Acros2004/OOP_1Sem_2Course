using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Collections.Concurrent;


namespace lab15
{
    class Program
    {
        static CancellationTokenSource cancellation = new CancellationTokenSource();
        static void Main(string[] args)
        {
            First();
            Second();
            Third();
            Fourth();
            Fifth();
            Sixth();
            Seven();
            Eighth();
        }
        static void First()
        {
           for(int i = 0;i < 5; i++)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                Task task = new Task(() => MulByVector(10000000));
                task.Start();
                Console.WriteLine($"id: {task.Id}, статус: {task.Status}");
                task.Wait();
                Console.WriteLine($"id: {task.Id}, статус: {task.Status}");
                sw.Stop();
                Console.WriteLine($"#1: {sw.ElapsedMilliseconds}ms");
                Console.WriteLine();
            }
        }
        static void MulByVector(int k)
        {
            Random random = new Random();
            List<int> vector = new List<int>();
            for (int i = 0; i < k; i++)
            {
                vector.Add(random.Next(1, 10));
            }
            vector = vector.Select(x => x * 10).ToList();

        }
        static void MulByVector2(int k)
        {
            Random random = new Random();
            List<int> vector = new List<int>();
            for (int i = 0; i < k; i++)
            {
                vector.Add(random.Next(1, 10));
                Console.WriteLine(vector[i]);
                Thread.Sleep(100);
                if (cancellation.Token.IsCancellationRequested) return;
            }
            vector = vector.Select(x => x * 10).ToList();

        }
        static void Second()
        {
            
            Task task = Task.Run(() => MulByVector2(1000), cancellation.Token);
    
                if ("1" == Console.ReadLine()) cancellation.Cancel();
              
                task.Wait();
            
        }
        static void Third()
        {
            Task<int> first = new Task<int>(() => new Random().Next(0, 2) * 8);
            Task<int> second = new Task<int>(() => new Random().Next(0, 3) * 10);
            Task<int> third = new Task<int>(() => new Random().Next(3, 6));

            first.Start();
            second.Start();
            third.Start();
            first.Wait();
            second.Wait();
            third.Wait();

            Task<int> number = new Task<int>(() => first.Result + second.Result + third.Result);
            number.Start();
            Console.WriteLine($"Сумма результатов: {number.Result}");
        }
        static void Fourth()
        {
            Task<int> task4 = new Task<int>(() => 15 * 6 + 15 + 88);
            Task show = task4.ContinueWith(sum => Console.WriteLine($"Cумма = {sum.Result}"));
            task4.Start();
            show.Wait();

            Task<double> sqrt = new Task<double>(() => Math.Sqrt(81));
            TaskAwaiter<double> awaiter = sqrt.GetAwaiter();
            awaiter.OnCompleted(() => Console.WriteLine($"Корень 81: {sqrt.Result}"));
            sqrt.Start();
            sqrt.Wait();
            awaiter.GetResult();
            Thread.Sleep(10);
        }
        static void Fifth()
        {
            List<int> list = new List<int>();
            for(int i = 0;i < 10000; i++)
            {
                list.Add(i);
            }
            
            void Factorial(int x)
            {
                long result = 1;

                for (int i = 1; i <= x; i++)
                {
                    result *= i;
                }
            }


            Stopwatch sw = new Stopwatch();
            sw.Start();
            Parallel.For(0, 10000, Factorial);
            sw.Stop();
            Console.WriteLine($"Параллельный for: {sw.ElapsedMilliseconds}ms");

            sw.Restart();
            for (int i = 0; i < 10000; i++)
            {
                Factorial(i);
            }
            sw.Stop();
            Console.WriteLine($"Нормальный for: {sw.ElapsedMilliseconds}ms");

            sw.Restart();
            Parallel.ForEach<int>(list, Factorial);
            sw.Stop();
            Console.WriteLine($"Параллельный foreach: {sw.ElapsedMilliseconds}ms");
            sw.Restart();
            foreach(int item in list)
            {
                Factorial(item);
            }
            sw.Stop();
            Console.WriteLine($"Нормальный foreach: {sw.ElapsedMilliseconds}ms");
        } 
        static void Sixth()
        {
            int count = 0;
            int maxCount = 100;
            Parallel.Invoke(
            () =>
            {
                while (count < maxCount)
                {
                    count++;
                    Console.WriteLine($"1: {count}");
                }
            },
            () =>
            {
                while (count < maxCount)
                {
                    count++;
                    Console.WriteLine($"2: {count}");
                }
            });
        }
        static void Seven()
        {
            CancellationTokenSource tokenSource_2 = new CancellationTokenSource();
            BlockingCollection<string> bc = new BlockingCollection<string>(5);

            Task[] sellers = new Task[5]
            {
                new Task (()=>{while (true) { Thread.Sleep(1000); bc.Add("Стул");if(tokenSource_2.Token.IsCancellationRequested) return;} }, tokenSource_2.Token),
                new Task (()=>{while (true) { Thread.Sleep(1000); bc.Add("Шкаф");if(tokenSource_2.Token.IsCancellationRequested) return;} }, tokenSource_2.Token),
                new Task (()=>{while (true) { Thread.Sleep(1000); bc.Add("Кирпич");if(tokenSource_2.Token.IsCancellationRequested) return;} }, tokenSource_2.Token),
                new Task (()=>{while (true) { Thread.Sleep(1000); bc.Add("Молоко");if(tokenSource_2.Token.IsCancellationRequested) return;} }, tokenSource_2.Token),
                new Task (()=>{while (true) { Thread.Sleep(1000); bc.Add("Телевизор горизонт");if(tokenSource_2.Token.IsCancellationRequested) return;} }, tokenSource_2.Token),
            };

            Task[] consumers = new Task[10]
            {
                new Task(() => { while(true){ Thread.Sleep(6000);   bc.Take(); if(tokenSource_2.Token.IsCancellationRequested) return;} }, tokenSource_2.Token),
                new Task(() => { while(true){ Thread.Sleep(6000);   bc.Take(); if(tokenSource_2.Token.IsCancellationRequested) return;} }, tokenSource_2.Token),
                new Task(() => { while(true){ Thread.Sleep(6000);   bc.Take(); if(tokenSource_2.Token.IsCancellationRequested) return;} }, tokenSource_2.Token),
                new Task(() => { while(true){ Thread.Sleep(6000);   bc.Take(); if(tokenSource_2.Token.IsCancellationRequested) return;} }, tokenSource_2.Token),
                new Task(() => { while(true){ Thread.Sleep(6000);   bc.Take(); if(tokenSource_2.Token.IsCancellationRequested) return;} }, tokenSource_2.Token),
                new Task(() => { while(true){ Thread.Sleep(6000);   bc.Take(); if(tokenSource_2.Token.IsCancellationRequested) return;} }, tokenSource_2.Token),
                new Task(() => { while(true){ Thread.Sleep(6000);   bc.Take(); if(tokenSource_2.Token.IsCancellationRequested) return;} }, tokenSource_2.Token),
                new Task(() => { while(true){ Thread.Sleep(6000);   bc.Take(); if(tokenSource_2.Token.IsCancellationRequested) return;} }, tokenSource_2.Token),
                new Task(() => { while(true){ Thread.Sleep(6000);   bc.Take(); if(tokenSource_2.Token.IsCancellationRequested) return;} }, tokenSource_2.Token),
                new Task(() => { while(true){ Thread.Sleep(6000);   bc.Take(); if(tokenSource_2.Token.IsCancellationRequested) return;} }, tokenSource_2.Token)
            };

            foreach (var item in sellers)
                if (item.Status != TaskStatus.Running)
                    item.Start();

            foreach (var item in consumers)
                if (item.Status != TaskStatus.Running)
                    item.Start();

            Task task7 = new Task(() =>
            {
                int count = 0;
                while (true)
                {
                    if (bc.Count != count && bc.Count != 0)
                    {
                        count = bc.Count;

                        Console.Clear();
                        Console.WriteLine("--------------- Склад ---------------");

                        foreach (var item in bc)
                            Console.WriteLine(item);

                        Thread.Sleep(400);

                        if (tokenSource_2.Token.IsCancellationRequested)
                        {
                            Console.WriteLine("\nProcess stopped.");
                            return;
                        }
                        Console.WriteLine("-------------------------------------");
                    }
                }
            }, tokenSource_2.Token);

            task7.Start();

            if ("7" == Console.ReadLine()) tokenSource_2.Cancel();

            task7.Wait();
        }
        static void Eighth()
        {
            void Factorial()
            {
                int result = 1;
                for (int i = 1; i <= 5; i++)
                    result *= i;
                Thread.Sleep(100);
                Console.WriteLine($"5! = {result}");
            }
            async void FactorialAsync()
            {
                await Task.Run(() => Factorial());
            }

            FactorialAsync();
            Console.ReadKey();
        }
    }
}