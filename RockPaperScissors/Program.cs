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
            string handNumber;
            string again = "y";

            while (again == "y")
            {   
                bool win = false;
                bool flag = false;
                string playerHand = "";
                while (flag == false)
                {
                    Console.WriteLine("\nChoose hand number: rock = 1, paper = 2, scissors = 3");
                    try
                    {
                        flag = true;
                        handNumber = Console.ReadLine();
                        if (handNumber == "autowin")
                        {   
                            Console.WriteLine("\nYou win!!");
                            win = true;
                            scores[0] += 1;
                            again = "";
                            break;
                        }
                        if (Convert.ToInt32(handNumber) > 3)
                        {
                            handNumber = "";
                        }
                        playerHand = validHands[Convert.ToInt32(handNumber) - 1];
                    }
                    catch
                    {   
                        flag = false;
                        Console.WriteLine("\nThat's not a valid hand.");
                    }
                    finally
                    {
                        handNumber = "";
                    }
                }
                if (!win)
                {
                    Random rnd = new Random(); 
                    int computerIndex = rnd.Next(0, 3);
                    computerHand = validHands[computerIndex];
                    Console.WriteLine("\nYou pick {0}.", playerHand);
                    Console.WriteLine("The computer picks {0}.", computerHand);
                    Console.WriteLine(CompareHands(playerHand, computerHand));
                }
                Console.WriteLine("You: {0}, Computer: {1}", scores[0], scores[1]);
                Console.WriteLine("\nDo you want to play again? ('y' if yes, anything else if no)");
                again = Console.ReadLine().ToLower().Trim();
            }
        }
        
        public static string CompareHands(string hand1, string hand2)
        {
            string computer = "\nComputer wins!";
            string player = "\nYou win!\n";
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
