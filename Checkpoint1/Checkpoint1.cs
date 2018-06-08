using System;

namespace Checkpoint1
{
    class Program
    {
        static void Main(string[] args)
        {
            DivByThree();
            Sum();
            Factorial();
            Guess();
            FindMax();
        }

        static public void DivByThree() 
        {
            int count = 0;
            for (int i = 1; i < 101; i ++) 
            {
                if (i % 3 == 0)
                {
                    count ++;
                }
            }
            Console.WriteLine(count);
            Console.ReadLine();
        }

        static public void Sum()
        {   
            bool cont = true;
            int sum = 0;
            while (cont)
            {
                Console.WriteLine("Enter a number, or 'ok' to exit:");
                string entry = Console.ReadLine().ToLower();
                if (entry == "ok" || entry == "OK")
                {
                    cont = false;
                    break;
                }
                try
                {
                    sum += Convert.ToInt32(entry);
                    Console.WriteLine("Sum of entered numbers: {0}", sum);
                }
                catch
                {
                    Console.WriteLine("Entry must be a number, " +
                                      "'ok' or 'OK'.");
                }
            }
        }

        static public void Factorial() 
        {   
            string entry = "";
            int fact = 0;
            while (entry == "")
            {
                Console.WriteLine("Enter an integer between 1 and 31:");
                entry = Console.ReadLine();
                try
                {
                    fact = Convert.ToInt32(entry);           
                }
                catch
                {
                    Console.WriteLine("Entry must be an integer.");
                    entry = "";
                }
            }
            for (int i = fact - 1; i > 0; i --)
            {
                fact *= i;
            }
           Console.WriteLine("{0}! = {1}", entry, fact);
           Console.ReadLine();
        }

        static public void Guess()
        {
            int counter = 4;
            Random rnd = new Random();
            int secret = rnd.Next(0, 10);
            Console.WriteLine("Try to guess the secret number " +
                              "between 1 and 10:");
            while (counter > 0)
            {
                Console.WriteLine("You have {0} chance(s) remaining.", counter);
                string guess = Console.ReadLine();
                if (guess == secret.ToString())
                {
                    Console.WriteLine("You win!");
                    Console.ReadLine();
                    return;
                }
                counter --;
            }
            Console.WriteLine("You lose.");
            Console.ReadLine();
        }

        static public void FindMax()
        {
            int max = 0;
            int [] nums = new int [5];
            bool correct = false;
            while (!correct)
            {
                correct = true;
                Console.WriteLine("Enter a series of up to 5 integers separated by commas:");
                string [] series = Console.ReadLine().Split(',');
                for (int i = 0; i < series.Length; i ++)
                {
                    try
                    {
                        nums[i] = Convert.ToInt32(series[i]);
                    }
                    catch
                    {
                        Console.WriteLine("That's not a valid entry.");
                        correct = false;
                        break;
                    }
                }
            }

            foreach (int num in nums)
            {
                if (num > max)
                {
                    max = num;
                }
            }
            Console.WriteLine("The greatest of those numbers is {0}.", max);
        }
    }
}
