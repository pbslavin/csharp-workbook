using System;
using System.Collections.Generic;
using System.Linq;

namespace Checkers
{
    class Program
    {
        static void Main(string[] args)
        {
            Board.GenerateCheckers();
            Console.WriteLine("Hello World!");
        }
    }

    public class Checker
    {
        public string Symbol  { get; set; }
        public int[] Position  { get; set; }
        public string Color { get; set; }
        
        public Checker(string color, int[] position)
        {
            // Your code here
        }
    }

    public class Board
    {
        private List<Checker> checkers = new List<Checker>();
        public string[][] Grid  { get; set; }
        public List<Checker> Checkers { get; set; }
        
        public Board()
        {
            // for (int i = 0; i < 9; i++)
            // {
            //     Grid[0][i] = i.ToString();
            // }
            // for (int i = 0; i < 10; i++)
            // {
            //     for (int j = 0; i < 9; j++)
            //     {
            //         Grid[i][j] = null;
            //     }
            // }
            return;
        }
        
        public void CreateBoard()
        {
            Console.WriteLine("0 1 2 3 4 5 6 7");
            Console.WriteLine();
            return;
        }
        
        public static void GenerateCheckers()
        {
            int[,] whitePositions = new int[12,2];
            int[,] blackPositions = new int[12,2];
            int arr = 0;
            for (int i = 0; i < 3; i ++)
            {
                for (int j = 0; j < 8; j += 2)
                {
                    if (i % 2 == 0 && j == 0)
                    {
                        j += 1;
                    }
                    whitePositions[arr, 0] = i;
                    whitePositions[arr, 1] = j;
                    arr += 1;
                }
            }
            arr = 0;
            for (int i = 5; i < 8; i ++)
            {
                for (int j = 0; j < 8; j += 2)
                {
                    if (i % 2 == 0 && j == 0)
                    {
                        j += 1;
                    }
                    blackPositions[arr, 0] = i;
                    blackPositions[arr, 1] = j;
                    arr += 1;
                }
            }
            return;
        }
        
        public void PlaceCheckers()
        {
            // Your code here
            return;
        }
        
        public void DrawBoard()
        {
            // Your code here
            return;
        }
        
        public Checker SelectChecker(int row, int column)
        {
            return Checkers.Find(x => x.Position.SequenceEqual(new List<int> { row, column }));
        }
        
        public void RemoveChecker(int row, int column)
        {
            // Your code here
            return;
        }
        
        public bool CheckForWin()
        {
            return Checkers.All(x => x.Color == "white") || !Checkers.Exists(x => x.Color == "white");
        }
    }

    class Game
    {
        public Game()
        {
            // Your code here
        }
    }
}
