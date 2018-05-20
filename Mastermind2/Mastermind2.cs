using System;
using System.Collections.Generic;
namespace Mastermind2
{

    class Peg
    {
        public Peg(char letter)
        {
            Letter = letter;
        }

        public char Letter { get; private set; }
    }

    class Row
    {
        private string score;
        private char[] pegs = new char[4];
        public Row(char[] pegs)
        {   
            for (int i = 0; i < pegs.Length; i ++)
            {
                Pegs[i] = pegs[i];
            }
        }

        public char[] Pegs 
        {
            get {
                return pegs;
            }
            private set {
                pegs = value;
            }
        }

        public string Score
        {
            get {
                return score;
            }
            internal set {
                score = value;
            }
        }
    }

    class Game
    {
        private char[] answer;
        private int red;
        private int white; 
        private List<Row> guesses = new List<Row>();
        private bool win = false;

        public Game(Row answer)
        {
            Answer = answer.Pegs;
        }

        public bool Win 
        {
            get {
                return win;
            }
            private set {
                win = value;
            }
        }

        public char[] Answer
        {
            get {
                return answer;
            }
            private set {
                answer = value;
            }
        }

        public void CompareGuess(Row guess)
        {
            red = 0;
            white = 0;
            char[] answerCopy = new char[this.answer.Length];
            char[] guessCopy = new char[this.answer.Length];
            Array.Copy(this.answer, answerCopy, answerCopy.Length);
            Array.Copy(guess.Pegs, guessCopy, answerCopy.Length);
            for (int i = 0; i < answerCopy.Length; i ++)
            {
                if (guessCopy[i] == answerCopy[i])
                {
                    red ++;
                    answerCopy[i] = ' ';
                    guessCopy[i] = ' ';             }
            }
            for (int i = 0; i < answerCopy.Length; i ++)
            {
                if (Array.Exists(answerCopy, element => element == guessCopy[i]) && guessCopy[i] != ' ')
                {
                    white ++;
                    answerCopy[Array.IndexOf(answerCopy, guessCopy[i])] = ' ';
                }
            }
            guess.Score = $"white: {white}, red: {red}";
            guesses.Add(guess);
            if (red != 4)
            {
                Console.WriteLine("");
                foreach (Row row in guesses)
                {
                    Console.WriteLine(new string(row.Pegs) + " - " + row.Score);
                }
            }
            else
            {
                Console.WriteLine("You win!\n");
                Win = true;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {   
            // int numberOfPegs = 4;
            char[] letters = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
            // Random rand = new Random();
            // char[] randRow = new char[4];
            // for (int i = 0; i < numberOfPegs; i ++)
            // {
            //     randRow[i] = letters[rand.Next(0, 7)];
            // }

            char[] randRow = new char[] {'c','e','a','c'};

            Row answerRow = new Row(randRow);

            Game game = new Game(answerRow);
            string answerString = new string(game.Answer);
            // Console.WriteLine(answerString);
            for (int i = 0; i < 10; i ++)
            {   
                string turn = "";
                while (turn.Length != 4)
                {
                    Console.Write("\nEnter four letters from a to h: ");
                    turn = Console.ReadLine();
                    if (turn.Length != 4)
                    {
                        Console.WriteLine("\nWrong number of letters");
                        continue;
                    }
                    foreach (char letter in turn)
                    {
                        if (Array.IndexOf(letters, letter) == -1)
                        {
                            Console.WriteLine("\nInvalid characters");
                            turn = "";
                            break;
                        }
                    }
                }
                Row guess = new Row(turn.ToCharArray());
                game.CompareGuess(guess);
                if (game.Win)
                {
                    break;
                }
            }
            if (!game.Win)
            {
                Console.WriteLine("Game over\n");
                Console.WriteLine(game.Answer);
            }
        }
    }
}
