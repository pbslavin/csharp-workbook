using System;
using System.Threading;

namespace RockPaperScissors
{
    class Program
    {
        static string [] validHands = new string [] {"rock", "paper", "scissors"};
        public static void Main()
        {   string playerHand = "";
            string computerHand;
            while (!Array.Exists(validHands, element => element == playerHand))
            {
                Console.WriteLine("Enter hand 1:");
                playerHand = Console.ReadLine().ToLower();
                if (!Array.Exists(validHands, hand => hand == playerHand && playerHand != ""))
                {
                    Console.WriteLine("That's not a valid hand.");
                }
            }
            Random rnd = new Random(); 
            int computerIndex = rnd.Next(0,2);
            computerHand = validHands[computerIndex];
            Console.WriteLine("The computer picks {0}.", computerHand);
            string winner = CompareHands(playerHand, computerHand);
            if (winner != "")
            {
                Console.WriteLine("{0} wins!", winner);
            }
            else
            {
                Console.WriteLine("It's a tie!");
            }
            // leave this command at the end so your program does not close automatically
            Console.ReadLine();
        }
        
        public static string CompareHands(string hand1, string hand2)
        {
            if (hand1 == hand2) 
                {
                    return "";
                }
            if (hand1 == "rock")
            {
                if (hand2 == "paper")
                {
                    return hand2;
                }
                else
                {
                    return hand1;
                }
            }
            if (hand1 == "paper")
            {
                if (hand2 == "scissors")
                {
                    return hand2;
                }
                else
                {
                    return hand1;
                }
            } 
            if (hand2 == "rock")
            {
                return hand2;
            }
            else
            {
                return hand1;
            }
        }
    }
}
