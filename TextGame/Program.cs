using System;
using System.Threading;

namespace TextGame
{
    class Program
    {
        static string[] y = { "y", "yes" };
        static int fdmg1;
        static int edmg1;
        static int complete;
        static void Main()
        {
            //game loop
            bool alive = true;
            string playAgain;
            while (alive)
            {
                complete = game();
                if (complete == 1)
                {
                    Console.WriteLine("You managed to escape the cavern alive! Would you like to play again? [y/n]: ");
                    playAgain = Console.ReadLine();
                    if (Array.IndexOf(y, playAgain.ToLower()) > -1)
                    {
                        alive = true;
                    }
                    else
                    {
                        alive = false;
                    }
                }
                else
                {
                    Console.WriteLine("You have died! Would you like to play again? [y/n]: ");
                    playAgain = Console.ReadLine();
                    if (Array.IndexOf(y, playAgain.ToLower()) > -1)
                    {
                        alive = true;
                    }
                    else
                    {
                        alive = false;
                    }
                }
            }
        }

        public static int game()
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Welcome to the cavern of secrets!");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            Thread.Sleep(3000);

            Console.WriteLine("You enter a dark cavern out of curiosity. It is dark and you can only make out a small stick on the floor.");
            Console.WriteLine("Do you take it? [y/n]: ");
            string ch1 = Console.ReadLine();

            // STICK TAKEN
            int stick;
            string[] y = { "y", "Y", "Yes", "YES", "yes" };
            if (Array.IndexOf(y, ch1) > -1)
            {
                Console.WriteLine("You have taken the stick!");
                Thread.Sleep(2000);
                stick = 1;
            }
            // STICK NOT TAKEN
            else
            {
                Console.WriteLine("You have not taken the stick.");
                stick = 0;
            }

            Console.WriteLine("As you proceed further into the cave, you see a small glowing object");
            Console.WriteLine("Do you approach the object? [y/n]");
            string ch2 = Console.ReadLine();

            //APPROACH SPIDER
            if (Array.IndexOf(y, ch2) > -1)
            {
                Console.WriteLine("You approach the object...");
                Thread.Sleep(2000);
                Console.WriteLine("As you draw closer, you begin to make out the object as an eye!");
                Thread.Sleep(1000);
                Console.WriteLine("The eye belongs to a giant spider!");
                Console.WriteLine("Do you try to fight it? [y/n]");
                string ch3 = Console.ReadLine();

                //FIGHT SPIDER
                if (Array.IndexOf(y, ch3) > -1)
                {
                    //WITH STICK
                    if (stick == 1)
                    {
                        Console.WriteLine("You only have a stick to fight with!");
                        Console.WriteLine("You quickly jab the spider in it's eye and gain an advantage.");
                        Thread.Sleep(2000);
                        Fight(3, 10, 1, 5);
                    }
                    //WITHOUT STICK
                    else
                    {
                        Console.WriteLine("You don't have anything to fight with!");
                        Thread.Sleep(2000);
                        Fight(1, 8, 1, 5);
                    }
                    if (edmg1 > fdmg1)
                    {
                        Console.WriteLine("The spider has dealt more damage than you!");
                        complete = 0;
                        return complete;
                    }
                    else if (fdmg1 < 5)
                    {
                        Console.WriteLine("You didn't do enough damage to kill the spider, but you manage to escape.");
                        complete = 1;
                        return complete;
                    }
                    else
                    {
                        Console.WriteLine("You killed the spider!");
                        complete = 1;
                        return complete;
                    }
                }
                //DON"T FIGHT SPIDER
                Console.WriteLine("You choose not to fight the spider.");
                Thread.Sleep(1000);
                Console.WriteLine("As you turn away, it ambushes you and impales you with it's fangs!!!");
                complete = 0;
                return complete;
            }
            //DON"T APPROACH SPIDER
            else
            {
                Console.WriteLine("You turn away from the glowing object, and attempt to leave the cave...");
                Thread.Sleep(1000);
                Console.WriteLine("but something won't let you....");
                Thread.Sleep(2000);
                complete = 0;
                return complete;
            }
        }

        public static void Fight(int fLow, int fHigh, int eLow, int eHigh)
        {
            Random rnd = new Random();
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("                  Fighting...                   ");
            Console.WriteLine("   YOU MUST HIT ABOVE A 5 TO KILL THE SPIDER    ");
            Console.WriteLine("IF THE SPIDER HITS HIGHER THAN YOU, YOU WILL DIE");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Thread.Sleep(2000);
            fdmg1 = rnd.Next(fLow, fHigh);
            edmg1 = rnd.Next(eLow, eHigh);
            Console.WriteLine($"You hit a {fdmg1}.");
            Console.WriteLine($"The spider hits a {edmg1}.");
            Thread.Sleep(2000);
        }
    }
}