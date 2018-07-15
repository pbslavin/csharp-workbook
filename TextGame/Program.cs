using System;
using System.Threading;

namespace TextGame
{
    class Program
    {
        static void Main()
        {
            //game loop
            bool alive = true;
            string aliveString;
            string[] y = { "y", "Y", "Yes", "YES", "yes" };
            while (alive)
            {
                int complete = game();
                if (complete == 1)
                {
                    Console.WriteLine("You managed to escape the cavern alive! Would you like to play again? [y/n]: ");
                    aliveString = Console.ReadLine();
                    if (Array.IndexOf(y, aliveString) > -1)
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
                    aliveString = Console.ReadLine();
                    if (Array.IndexOf(y, aliveString) > -1)
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
            int complete;
            Random rnd = new Random();
            int dmg1;
            int edmg1;
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
                        Console.WriteLine("You quickly jab the spider in it's eye and gain an advantage");
                        Thread.Sleep(2000);
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        Console.WriteLine("                  Fighting...                   ");
                        Console.WriteLine("   YOU MUST HIT ABOVE A 5 TO KILL THE SPIDER    ");
                        Console.WriteLine("IF THE SPIDER HITS HIGHER THAN YOU, YOU WILL DIE");
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        Thread.Sleep(2000);
                        dmg1 = rnd.Next(3, 10);
                        edmg1 = rnd.Next(1, 5);
                        Console.WriteLine($"You hit a {dmg1}.");
                        Console.WriteLine($"The spider hits a {edmg1}.");
                        Thread.Sleep(2000);

                        if (edmg1 > dmg1)
                        {
                            Console.WriteLine("The spider has dealt more damage than you!");
                            complete = 0;
                            return complete;
                        }
                        else if (dmg1 < 5)
                        {
                            Console.WriteLine("You didn't do enough damage to kill the spider, but you manage to escape");
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
                    //WITHOUT STICK
                    else
                    {
                        Console.WriteLine("You don't have anything to fight with!");
                        Thread.Sleep(2000);
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        Console.WriteLine("                  Fighting...                   ");
                        Console.WriteLine("   YOU MUST HIT ABOVE A 5 TO KILL THE SPIDER    ");
                        Console.WriteLine("IF THE SPIDER HITS HIGHER THAN YOU, YOU WILL DIE");
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        Thread.Sleep(2000);
                        dmg1 = rnd.Next(1, 8);
                        edmg1 = rnd.Next(1, 5);
                        Console.WriteLine($"You hit a {dmg1}.");
                        Console.WriteLine($"The spider hits a {edmg1}.");
                        Thread.Sleep(2000);

                        if (edmg1 > dmg1)
                        {
                            Console.WriteLine("The spider has dealt more damage than you!");
                            complete = 0;
                            return complete;
                        }
                        else if (dmg1 < 5)
                        {
                            Console.WriteLine("You didn't do enough damage to kill the spider, but you manage to escape");
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
                Console.WriteLine("But something won't let you....");
                Thread.Sleep(2000);
                complete = 0;
                return complete;
            }
        }
    }
}



/*
import time
import random

print ("As you proceed further into the cave, you see a small glowing object")
ch2 = str(input("Do you approach the object? [y/n]"))

# APPROACH SPIDER
if ch2 in ["y", "Y", "Yes", "YES", "yes"]:
    print ("You approach the object...")
    time.sleep(2)
    print ("As you draw closer, you begin to make out the object as an eye!")
    time.sleep(1)
    print ("The eye belongs to a giant spider!")
    ch3 = str(input("Do you try to fight it? [Y/N]"))

    # FIGHT SPIDER
    if ch3 in ["y", "Y", "Yes", "YES", "yes"]:

        # WITH STICK
        if stick == 1:
            print ("You only have a stick to fight with!")
            print ("You quickly jab the spider in it"s eye and gain an advantage")
            time.sleep(2)
            print ("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~")
            print ("                  Fighting...                   ")
            print ("   YOU MUST HIT ABOVE A 5 TO KILL THE SPIDER    ")
            print ("IF THE SPIDER HITS HIGHER THAN YOU, YOU WILL DIE")
            print ("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~")
            time.sleep(2)
            fdmg1 = int(random.randint(3, 10))
            edmg1 = int(random.randint(1, 5))
            print ("you hit a", fdmg1)
            print ("the spider hits a", edmg1)
            time.sleep(2)

            if edmg1 > fdmg1:
                print ("The spider has dealt more damage than you!")
                complete = 0
                return complete

            elif fdmg1 < 5:
                print ("You didn"t do enough damage to kill the spider, but you manage to escape")
                complete = 1
                return complete

            else:
                print ("You killed the spider!")
                complete = 1
                return complete

        # WITHOUT STICK
        else:
            print ("You don"t have anything to fight with!")
            time.sleep(2)
            print ("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~")
            print ("                  Fighting...                   ")
            print ("   YOU MUST HIT ABOVE A 5 TO KILL THE SPIDER    ")
            print ("IF THE SPIDER HITS HIGHER THAN YOU, YOU WILL DIE")
            print ("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~")
            time.sleep(2)
            fdmg1 = int(random.randint(1, 8))
            edmg1 = int(random.randint(1, 5))
            print ("you hit a", fdmg1)
            print ("the spider hits a", edmg1)
            time.sleep(2)

            if edmg1 > fdmg1:
                print ("The spider has dealt more damage than you!")
                complete = 0
                return complete

            elif fdmg1 < 5:
                print ("You didn"t do enough damage to kill the spider, but you manage to escape")
                complete = 1
                return complete

            else:
                print ("You killed the spider!")
                complete = 1
                return complete

    #DON"T FIGHT SPIDER
    print ("You choose not to fight the spider.")
    time.sleep(1)
    print ("As you turn away, it ambushes you and impales you with it"s fangs!!!")
    complete = 0
    return complete

# DON"T APPROACH SPIDER
else:
        print ("You turn away from the glowing object, and attempt to leave the cave...")
        time.sleep(1)
        print ("But something won"t let you....")
        time.sleep(2)
        complete = 0
        return complete

# game loop
alive = True
while alive:

complete = game()
if complete == 1:
    alive = input("You managed to escape the cavern alive! Would you like to play again? [y/n]: ")
    if alive in ["y", "Y", "YES", "yes", "Yes",]:
        alive

    else:
        break

else:
    alive = input("You have died! Would you like to play again? [y/n]: ")
    if alive in ["y", "Y", "YES", "yes", "Yes",]:
        alive

    else:
        break

        */
