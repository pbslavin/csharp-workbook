using System;
using System.Threading;

namespace RockPaperScissors
{
    class Program
    {
        static string [] validHands = new string [] {"rock",
            "paper", "scissors"};
        static int [] scores = {0, 0};
        public static void Main()
        {   
            string computerHand;
            string again = "y";

            while (again == "y")
            {   
                bool win = false;
                bool valid = false;
                string playerHand = "";

                while (valid == false)
                {
                    Console.WriteLine(
                        "\nEnter 'rock', 'paper, or 'scissors' " +
                        "(without quotation marks)"
                        );
                    playerHand = Console.ReadLine().ToLower().Trim();

                    if (playerHand == "autowin")
                    {
                        valid = true;
                        win = true;
                        scores[0] += 1;
                        Console.WriteLine("\nYou win automatically!!\n");
                        break;
                    }

                    try
                    {
                        if (Array.Exists(validHands,
                            hand => hand == playerHand))
                        {
                            valid = true;
                        }
                        else
                        {
                            throw new HandException("Hand exception: " +
                                                    "That hand is invalid.");
                        }
                    }
                    catch (HandException ihx)
                    {   
                        valid = false;
                        Console.WriteLine(ihx.Message.ToString());
                    }
                }
                if (win == false)
                {
                    Random rnd = new Random(); 
                    int computerIndex = rnd.Next(0, 3);
                    computerHand = validHands[computerIndex];
                    Console.WriteLine("\nYou pick {0}.", playerHand);
                    Console.WriteLine("The computer picks {0}.",
                        computerHand);
                    Console.WriteLine(CompareHands(playerHand, computerHand));
                }
                Console.WriteLine("You: {0}, Computer: {1}",
                    scores[0], scores[1]);
                Console.WriteLine("\nDo you want to play again?" +
                                  "('y' if yes, anything else if no)");
                again = Console.ReadLine().ToLower().Trim();
            }
        }
        
        public static string CompareHands(string hand1, string hand2)
        {
            string computer = "\nThe computer wins!\n";
            string player = "\nYou win!\n";
            if (hand1 == hand2) 
                {
                    return "\nIt's a tie!\n";
                }
            if (hand1 == "rock")
            {
                if (hand2 == "paper")
                {
                    scores[1] += 1;
                    return computer;
                }
                else
                {   
                    scores[0] += 1;
                    return player;
                }
            }
            if (hand1 == "paper")
            {
                if (hand2 == "scissors")
                {
                    scores[1] += 1;
                    return computer;
                }
                else
                {
                    scores[0] += 1;
                    return player;
                }
            } 
            if (hand2 == "rock")
            {
                scores[1] += 1;
                return computer;
            }
            else
            {
                scores[0] += 1;
                return player;
            }
        }
    }
}

public class HandException : Exception
{
    public HandException(string message) : base(message)
    {
    }
}