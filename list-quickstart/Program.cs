using System;
using System.Collections.Generic;

namespace list_quickstart
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = new List<string> { "Peter", "Ana", "Felipe" };
            names.Add("Henry");
            names.Add("John");
            names.Add("Hermione");
            names.Remove("Felipe");
            names.Remove(names[4]);
            foreach (var name in names)
            {
                Console.WriteLine($"Hello {name.ToUpper()}!");
            }
            GetIndex(names, "Felipe");
            GetIndex(names, "Ana");

            var fibs = new List<int> { 1, 1 };
            for (int i = 1; i < 11; i ++)
            {
                fibs.Add(fibs[i - 1] + fibs[i]);
            }
            foreach (int num in fibs)
            {
                Console.WriteLine(num);
            }
        }

        static void GetIndex(List<string> list, string name)
        {
            if (list.IndexOf(name) == -1)
            {
                Console.WriteLine($"If item is not in list, IndexOf returns {list.IndexOf(name)}.");
            }
            else
            {
                Console.WriteLine($"That name is at index {list.IndexOf(name)}.");
            }
        }
    }
}
