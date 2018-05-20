using System;
using System.Collections.Generic;

namespace Mastermind
{

    class Game
    {
        private List<Row> rows = new List<Row>();
        public string answer;

        public Game(string answer)
        {
            this.answer = answer;
        }

        public int[] Score(Row row)
        {
            char[] answerChars = answer.ToCharArray();
            int red = 0;
            int white = 0;
            for (int i = 0; i < 4; i ++)
            {
                if (answerChars[i] == row.Pegs[i])
                {
                    red += 1;
                    answerChars[i] = ' ';
                }
            }
            for (int i = 0; i < 4; i ++)
            {
                if (Array.IndexOf(answerChars, row.Pegs[i]) != -1)
                {
                    white += 1;
                    answerChars[Array.IndexOf(answerChars, row.Pegs[i])]= ' ';
                }
            }
            Console.WriteLine($"Red: {red}; White: {white}");
            return new int[2] {red, white};
        }

        public void AddRow(Row row)
        {
            this.rows.Add(row);
        }

        public string[] Rows 
        { 
            get {
                string[] currentRows = new string[10];
                for (int i = 0; i < rows.Count; i ++)
                {
                    currentRows[i] = rows[i].Pegs;
                }
                return currentRows;
            } 
        }
    }
    class Peg
    {
        public Peg(char letter)
        {
            this.Letter = letter;
        }

        public char Letter { get; internal set; }
    }

    class Row
    {
        private Peg[] pegs = new Peg[4];

        public Row(Peg[] pegs)
        {
            this.pegs = pegs;
        }

        public string Pegs
        {
            get {
                string pegsString = "";
                foreach (Peg peg in pegs)
                {
                   pegsString += peg.Letter; 
                }
                return pegsString;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool win = false;
            string pegLetters = "abcdefgh";
            string answer = "";
            Random random = new Random();
            for (int i = 0; i < 4; i ++)
            {
                int index = random.Next(0, 8);
                answer += pegLetters[index];
            }
            Console.WriteLine(answer);
            Game game = new Game(answer);

            for (int turns = 0; turns < 10; turns ++)
            {
                Console.Write("Choose four letters: ");
                string letters = Console.ReadLine();
                Peg[] pegs = new Peg[4];
                for (int i = 0; i < pegs.Length; i++)
                {
                    pegs[i] = new Peg(letters[i]);
                }
                Row row1 = new Row(pegs);
                game.AddRow(row1);
                foreach(string row in game.Rows)
                {
                    if (row != null)
                    {
                        Console.WriteLine(row);
                    }
                    else
                    {
                        break;
                    }
                }
                if (game.Score(row1)[0] == 4)
                {
                    Console.WriteLine("You win!");
                    win = true;
                    break;
                }
            }
            if (!win)
            {
                Console.WriteLine("No more turns");
            }
        }
    }
}
