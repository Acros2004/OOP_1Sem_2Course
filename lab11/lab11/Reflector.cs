using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace lab11
{
    static class Reflector
    {
        public static string GetAssemblyName()
        {
            return typeof(Program).Assembly.GetName().FullName;
        }

        public static bool HasPublicConstructors(string name)
        {
            Type type = Type.GetType(name, false,true);
            foreach (var item in type.GetConstructors())
            {
                if (item.IsPublic)
                {
                    return true;
                }
            }
            return false;
        }

        public static IEnumerable<string> PublicMethods(string name, StreamWriter sw)
        {
            List<string> list = new List<string>();
            Type type = Type.GetType(name, false, true);
            foreach (MethodInfo method in type.GetMethods())
            {
                if (method.IsPublic)
                {
                    list.Add(method.Name);
                    sw.WriteLine(method.Name);
                }
            }
            return list;
        }
        public static IEnumerable<string> FieldsAndProperties(string name, StreamWriter sw)
        {
            List<string> list = new List<string>();
            Type type = Type.GetType(name, false, true);
            foreach (var item in type.GetFields())
            {
                list.Add(item.Name);
                sw.WriteLine(item.Name);
            }
            foreach (var item in type.GetProperties())
            {
                list.Add(item.Name);
                sw.WriteLine(item.Name);
            }
            return list;
        }
        public static IEnumerable<string> Interfaces(string name, StreamWriter sw)
        {
            List<string> list = new List<string>();
            Type type = Type.GetType(name, false, true);
            foreach (var item in type.GetInterfaces())
            {
                list.Add(item.Name);
                sw.WriteLine(item.Name);
            }
            return list;
        }
        public static void MethodType(string name, string param, StreamWriter sw)
        {
            Type type = Type.GetType(name, false, true);
            foreach (var item in type.GetMethods())
            {
                if (item.GetParameters().Any(e => e.Name == param))
                {
                    sw.WriteLine(item);
                }
            }
        }
        public static void Invoke(string name, string methodName)
        {
            try
            {
                Type type = Type.GetType(name, false, true);
                object obj = Activator.CreateInstance(type);
                string[] param = File.ReadAllLines(@"Invoke.txt");
                MethodInfo method = type.GetMethod(methodName);
                method.Invoke(obj, param);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static object Create(string name)
        {
            return Activator.CreateInstance(Type.GetType(name));
        }
    }
}
