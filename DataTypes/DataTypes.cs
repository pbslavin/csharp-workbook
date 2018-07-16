using System;
using System.Threading;

namespace DataTypes
{
    class Program
    {
        static bool complete = false;
        static int fdmg1;
        static int edmg1;
        static bool alive = true;
        static void Main(string[] args)
        {
            while (alive) {
                string again;
                complete = Game();
                if (complete) {
                    Console.WriteLine("You managed to escape the cavern alive! Would you like to play again? [y/n]: ");
                } else {
                    Console.WriteLine("You have died! Would you like to play again? [y/n]: ");
                }
                again = Console.ReadLine().ToLower();
                if (again == "y" || again == "yes") {
                    alive = true;
                } else {
                    alive = false;
                }
            }
        }
        static void Fight(int a, int b, int c, int d)
        {       
            Random rnd = new Random();    
            Thread.Sleep(2000);
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("                  Fighting...                   ");
            Console.WriteLine("   YOU MUST HIT ABOVE A 5 TO KILL THE SPIDER    ");
            Console.WriteLine("IF THE SPIDER HITS HIGHER THAN YOU, YOU WILL DIE");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Thread.Sleep(2000);
            fdmg1 = rnd.Next(a, b);
            edmg1 = rnd.Next(c, d);
            Console.WriteLine("You hit a {0}.", fdmg1);
            Console.WriteLine("The spider hits a {0}.", edmg1);
            Thread.Sleep(2);
        }
        
        static bool Game() 
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Welcome to the cavern of secrets!");    
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            Thread.Sleep(3000);

            Console.WriteLine("You enter a dark cavern out of curiosity. It is dark and you can only make out a small stick on the floor.");
            Console.WriteLine("Do you take it? [y/n]: ");
            string ch1 = Console.ReadLine().ToLower();
            bool stick;
            if (ch1 == "y" || ch1 == "yes") { // STICK TAKEN
                Console.WriteLine("You have taken the stick!");
                Thread.Sleep(2000);
                stick = true;
            } else { // STICK NOT TAKEN
                Console.WriteLine("You did not take the stick.");
                stick = false;
            }

            Console.WriteLine("As you proceed further into the cave, you see a small glowing object.");
            Console.WriteLine("Do you approach the object? [y/n]: ");
            string ch2 = Console.ReadLine().ToLower();

            // APPROACH SPIDER 
            if (ch2 == "y" || ch2 == "yes") {
                Console.WriteLine("You approach the object...");
                Thread.Sleep(2000);
                Console.WriteLine("As you draw closer, you begin to make out the object as an eye!");
                Thread.Sleep(1000);
                Console.WriteLine("The eye belongs to a giant spider!");
                Console.WriteLine("Do you try to fight it? [y/n]: ");
                string ch3 = Console.ReadLine().ToLower();

                // FIGHT SPIDER
                if (ch3 == "y" || ch3 == "yes") {
                    // WITH STICK 
                    if (stick) {
                        Console.WriteLine("You only have a stick to fight with!");
                        Console.WriteLine("You quickly jab the spider in its eye and gain an advantage.");
                        Fight(3, 11, 1, 6);
                    } else {
                        Console.WriteLine("You don't have anything to fight with!");
                        Fight(1, 9, 1, 6);
                    }
                    if (edmg1 > fdmg1) {
                        Console.WriteLine("The spider has dealt more damage than you!");
                        complete = false;
                    } else if (fdmg1 < 5) {
                        Console.WriteLine("You didn't do enough damage to kill the spider, but you manage to escape.");
                        complete = true;
                    } else {
                        Console.WriteLine("You killed the spider!");
                        complete = true;
                    }
                return complete;
                }
                // DON'T FIGHT SPIDER
                Console.WriteLine("You choose not to fight the spider.");
                Thread.Sleep(1000);
                Console.WriteLine("As you turn away, it ambushes you and impales you with its fangs!!!");
                complete = false;
            } else {
                Console.WriteLine("You turn away from the glowing object, and attempt to leave the cave...");
                Thread.Sleep(1000);
                Console.WriteLine("But something won't let you....");
                Thread.Sleep(2);
                complete = false;
            }
            return complete;
        }
    }
}
