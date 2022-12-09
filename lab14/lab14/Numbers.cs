using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using static System.Console;

namespace lab14
{
    class Numbers
    {
        private int n;
        public StreamWriter file = new StreamWriter("odd.txt", false);
        public Numbers(int _n)
        {
            n = _n;
        }
        ~Numbers()
        {
            try { file.Close(); }
            catch { };
        }
        public void ForTimer(object obj)
        {
            for (int i = 1; i < n; i++)
                Write('X');
            WriteLine();
        }
        public void Odd()
        {
            if (file.BaseStream == null)
                file = new StreamWriter("odd and even.txt", true);
            for (int i = 1; i < n; i++)
            {
                Thread.Sleep(30);
                if (i % 2 != 0)
                {
                    if (file.BaseStream == null)
                        file = new StreamWriter("odd and even.txt", true);
                    file.WriteLine(i);
                    WriteLine("Нечётное число " + i);
                }
            }
            if (file.BaseStream != null)
                file.Close();
        }
        public void Even()
        {
            lock (this)
            {
                for (int i = 1; i < n; i++)
                {
                    if (i % 2 == 0)
                    {
                        if (file.BaseStream == null)
                            file = new StreamWriter("odd and even.txt", true);
                        file.WriteLine(i);
                        WriteLine("Чётное число" + i);
                    }
                    if (file.BaseStream != null)
                        file.Close();
                }
            }
        }
        public void Odd1()
        {
            Monitor.Enter(this);
            {
                if (file.BaseStream == null)
                    file = new StreamWriter("odd and even.txt", true);
                for (int i = 1; i < n; i++)
                {

                    if (i % 2 != 0)
                    {

                        if (file.BaseStream == null)
                            file = new StreamWriter("odd and even.txt", true);
                        file.WriteLine(i);
                        WriteLine("MonitorOdd" + i);
                        Monitor.Pulse(this);
                        Monitor.Wait(this);
                    }
                }
                if (file.BaseStream != null)
                    file.Close();
                Monitor.Exit(this);
            }
        }
        public void Even1()
        {
            Monitor.Enter(this);
            {
                if (file.BaseStream == null)
                    file = new StreamWriter("odd and even.txt", true);
                for (int i = 1; i < n; i++)
                {
                    if (i % 2 == 0)
                    {
                        if (file.BaseStream == null)
                            file = new StreamWriter("odd and even.txt", true);
                        file.WriteLine(i);
                        WriteLine("MonitorEven" + i);
                        Monitor.Pulse(this);
                        Monitor.Wait(this);
                    }
                }
                if (file.BaseStream != null)
                    file.Close();
                Monitor.Exit(this);
            }
        }
    }
}
