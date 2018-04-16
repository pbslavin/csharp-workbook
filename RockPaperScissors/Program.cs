using System;

namespace RockPaperScissors
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Enter hand 1:");
            string hand1 = Console.ReadLine().ToLower();
            Console.WriteLine("Enter hand 2:");
            string hand2 = Console.ReadLine().ToLower();
            Console.WriteLine(CompareHands(hand1, hand2));
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
