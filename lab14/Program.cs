using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.IO;


namespace lab14
{
    static class Program
    {
        private static void Main(string[] args)
        {
            Numbers.First();
            Console.WriteLine();
            Numbers.Second();
            Console.WriteLine();
            Numbers.Third();
            Console.WriteLine();
            Numbers.Fourth();
            Console.WriteLine();
            Numbers.Fifth();
            Console.ReadLine();
        }
        
    }
}