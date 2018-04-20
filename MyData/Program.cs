using System;

namespace MyData
{
    class Program
    {
        static void Main(string[] args)
        {   
            int n = 0;
            int i = 0;
            bool people = true;
            bool f = false;
            decimal num = 38.03001M;
            string firstName = "Peter";
            string lastName = "Slavin";
            int age = 51;
            string job = "musician";
            string favoriteComposer = "Gyorgy Ligeti";
            string anotherGreatComposer = "Luciano Berio";
            int ten = 10;
            int hun = 100;
            Console.WriteLine("Please enter an integer: ");
            n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter another integer: ");
            i = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("The sum of those integers is {0}.\n{0} yards is {1} inches.\n", n + i, (n + i) * 12 * 3);
            Console.WriteLine("The square of the decimal value contained in the variable \"num\" is {0}", num*num);
            Console.WriteLine("\nI'm {0} {1}. I'm {2} years old and I am a {3}.", firstName, lastName, age, job);
            if (people == true) {
                Console.WriteLine("\nThere are people...");
                if (f == false) {
                    Console.WriteLine("but \"f\" is false.");
                }
                else
                {
                    Console.WriteLine("and \"f\" is true!!");
                }
            }
            else
            {
                Console.WriteLine("Uh oh -- no people...");
                if (f == false) {
                    Console.WriteLine("but at least \"f\" is false.");
                }
                else
                {
                    Console.WriteLine("and to top that off, \"f\" is true!!");
                }
            }
            Console.WriteLine("\nMy favorite composers of the late 20th century are {0} and {1}.", favoriteComposer, anotherGreatComposer);
            Console.WriteLine("\nThe value contained in the variable \"num\", converted to an integer, is {0}.", Convert.ToInt32(num));
            Console.WriteLine("\nThe sum, product, difference and quotient of 100 and 10, respectively, are {0}, {1}, {2} and {3}.", ten+hun, ten*hun, hun-ten, hun/ten);
        }
    }
}
