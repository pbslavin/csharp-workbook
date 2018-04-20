using System;
using System.Threading;

namespace RockPaperScissors
{
    class Program
    {
        static string [] validHands = new string [] {"rock", "paper", "scissors"};
        static int [] scores = {0, 0};
        public static void Main()
        {   
            string computerHand;
            string again = "y";
            while (again == "y")
            {
                string playerHand = "";
                while (!Array.Exists(validHands, element => element == playerHand))
                {
                    Console.WriteLine("\nEnter hand 1:");
                    playerHand = Console.ReadLine().ToLower().Trim();
                    if (!Array.Exists(validHands, hand => hand == playerHand && playerHand != ""))
                    {
                        Console.WriteLine("\nThat's not a valid hand.");
                    }
                }
                Random rnd = new Random(); 
                int computerIndex = rnd.Next(0, 2);
                computerHand = validHands[computerIndex];
                Console.WriteLine("\nThe computer picks {0}.", computerHand);
                Console.WriteLine(CompareHands(playerHand, computerHand));
                Console.WriteLine("\nYou: {0}, Computer: {1}", scores[0], scores[1]);
            // leave this command at the end so your program does not close automatically
            Console.WriteLine("\nDo you want to play again? ('y' if yes, anything else if no)");
            again = Console.ReadLine().ToLower().Trim();
            }
        }
        
        public static string CompareHands(string hand1, string hand2)
        {
            string computer = "\nComputer wins!";
            string player = "\nYou win!";
            if (hand1 == hand2) 
                {
                    return "\nIt's a tie!";
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
