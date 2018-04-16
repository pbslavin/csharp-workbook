using System;

namespace FizzBuzz
{
    class Program
    {
        static bool isNumeric = false;
        static void Main()
        {
            while (!isNumeric) {
                Console.WriteLine("Please enter a natural number up to 100.: ");
                string numString = Console.ReadLine();
                isNumeric = Int32.TryParse(numString, out int n);
                if (isNumeric)
                {   
                    FizzBuzzIt(n);
                } else {
                    Console.WriteLine("That won't cut it.\n");
                }
            }
        }
        static void FizzBuzzIt(int n) 
        {   
            Console.WriteLine();
            for (int i = 1; i < n + 1; i ++) 
            {
                if ((i % 5 == 0) && (i % 3 == 0)) {
                    Console.WriteLine("fizz buzz");
                } else if (i % 3 == 0)
                {
                    Console.WriteLine("fizz");
                } else if (i % 5 == 0) 
                {
                    Console.WriteLine("buzz");
                } else {
                    Console.WriteLine(i);
                }
            }
            Console.WriteLine();
        }
    }
}
