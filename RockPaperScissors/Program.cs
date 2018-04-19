using System;
using System.Threading;

namespace RockPaperScissors
{
    class Program
    {
        public static void Main()
        {   string playerHand = "";
            string computerHand;
            string [] validHands = new string [] {"rock", "paper", "scissors"};
            while (!Array.Exists(validHands, element => element == playerHand))
            {
                Console.WriteLine("Enter hand 1:");
                playerHand = Console.ReadLine().ToLower();
                if (!Array.Exists(validHands, element => element == playerHand && playerHand != ""))
                {
                    Console.WriteLine("That's not a valid hand.");
                }
            }
            Random rnd = new Random(); 
            int computerIndex = rnd.Next(0,2);
            computerHand = validHands[computerIndex];
            Console.WriteLine("The computer picks {0}", computerHand);
            Console.WriteLine(CompareHands(playerHand, computerHand));
            // leave this command at the end so your program does not close automatically
            Console.ReadLine();
        }
        
        public static string CompareHands(string hand1, string hand2)
        {
            if ((hand1 == "rock" || hand1 == "paper" || hand1 == "scissors") && (hand2 == "rock" || hand2 == "paper" || hand2 == "scissors"))
            {
                if (hand1 == hand2) 
                {
                    return "It's a tie!";
                }
                if (hand1 == "rock")
                {
                    if (hand2 == "paper")
                    {
                        return hand2 + " wins!";
                    } else {
                        return hand1 + " wins!";
                    }
                    }
                if (hand1 == "paper")
                {
                    if (hand2 == "scissors")
                    {
                        return hand2 + " wins!";
                    } else {
                        return hand1 + " wins!";
                    }
                } 
                if (hand2 == "rock")
                {
                    return hand2 + " wins!";
                } else {
                    return hand1 + " wins!";
                }
            } else {
                return "That's not a valid pair of hands.";
            }
        }
    }
}
