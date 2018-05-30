﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Checkers
{
    public class Checker
    {
        private string symbol;
        private bool king;
        public Checker(string color, int[] position)
        {
            Color = color;
            Position = position;
            king = false;
            if (Color == "white")
            {
                int openCircleId = int.Parse("25CB", System.Globalization.NumberStyles.HexNumber);
                string openCircle = char.ConvertFromUtf32(openCircleId);
                symbol = openCircle;
            }
            else
            {
                int closedCircleId = int.Parse("25CF", System.Globalization.NumberStyles.HexNumber);
                string closedCircle = char.ConvertFromUtf32(closedCircleId);
                symbol = closedCircle;
            }
        }
        public bool King
        {
            get {
                return king;
            }
            set {
                king = value;
            }
        }
        public string Symbol
        {
            get {
                return symbol;
            }
            set {
                symbol = value;
            }
        }
        public int[] Position  { get; set; }
        public string Color { get; set; }
    }

    public class Board
    {
        private List<Checker> checkers = new List<Checker>();
        public static int[,] whitePositions = new int[12,2];
        public static int[,] blackPositions = new int[12,2];
        public string[][] Grid  { get; private set; }
        public List<Checker> Checkers
        {
            get {
                return checkers;
            }
            set {
                checkers = value;
            }
        }
        
        public void CreateBoard()
        {
            Grid = new string[9][];
            for (int i = 0; i < Grid.Length; i ++)
            {
                Grid[i] = new string[9];
            }
            Grid[0][0] = " ";
            for (int i = 1; i < 9; i ++)
            {
                Grid[0][i] = (i).ToString();
            }
            for (int i = 1; i < 9; i ++)
            {
                for (int j = 0; j < 9; j ++)
                {
                    if (j == 0)
                    {
                        Grid[i][j] = i.ToString();
                    }
                    // else if (i % 2 != 0 && j % 2 != 0)
                    // {
                    //     Grid[i][j] = " ";
                    // }
                    // else
                    // {
                    //     Grid[i][j] = nonPlaySquare;
                    // }
                }
            }
            return;
        }
        
        public void GenerateCheckers()
        {
            int[][] whitePositions = new int[12][];
            int[][] blackPositions = new int[12][];
            for (int i = 0; i < 12; i ++)
            {
                whitePositions[i] = new int[2];
                blackPositions[i] = new int[2];
            }
            int @array = 0;
            for (int i = 0; i < 3; i ++)
            {
                for (int j = 0; j < 8; j += 2)
                {
                    if (i % 2 == 0 && j == 0) //offset j by one on even rows
                    {
                        j += 1;
                    }
                    whitePositions[@array][0] = i;
                    whitePositions[@array][1] = j;
                    @array += 1;
                }
            }
            @array = 0;
            for (int i = 5; i < 8; i ++)
            {
                for (int j = 0; j < 8; j += 2)
                {
                    if (i % 2 == 0 && j == 0)
                    {
                        j += 1;
                    }
                    blackPositions[@array][0] = i;
                    blackPositions[@array][1] = j;
                    @array += 1;
                }
            }
            for (int i = 0; i < 12; i ++)
            {
                Checker whiteChecker = new Checker("white", whitePositions[i]);
                Checker blackChecker = new Checker("black", blackPositions[i]);
                this.Checkers.Add(whiteChecker);
                this.Checkers.Add(blackChecker);
            }
            return;
        }
        
        public void PlaceCheckers()
        {
            int nonPlaySquareId = int.Parse("25A4", System.Globalization.NumberStyles.HexNumber);
            string nonPlaySquare = char.ConvertFromUtf32(nonPlaySquareId);
            for (int i = 1; i < 9; i ++)
            {
                for (int j = 1; j < 9; j ++)
                {
                    if ((i % 2 == 0 && j % 2 != 0) || (i % 2 != 0 && j % 2 == 0))
                    {
                        Grid[i][j] = " ";
                    }
                    else
                    {
                        Grid[i][j] = nonPlaySquare;
                    } 
                }
            }
            for (int i = 0; i < this.Checkers.Count; i ++)
            {
                int row = this.Checkers[i].Position[0] + 1;
                int column = this.Checkers[i].Position[1] + 1;
                this.Grid[row][column] = this.Checkers[i].Symbol;
            }
            return;
        }

        public void PlaceChecker(Checker checker, int row, int column)
        {
            checker.Position[0] = row;
            checker.Position[1] = column;
            PlaceCheckers();
            DrawBoard();

        }
        
        public void DrawBoard()
        {   
            for (int i = 0; i < 9; i ++)
            {
                Console.WriteLine(String.Join(" ", this.Grid[i]));
            }
        }
        
        public Checker SelectChecker(int row, int column)
        {
            return Checkers.Find(x => x.Position.SequenceEqual(
                new int[] { row, column }));
        }

        public void MoveChecker(Checker checker, int row, int column)
        {
            if (Checkers.Find(x => x.Position.SequenceEqual(
                new int[] { row, column })) == null)
            {      
                // jumping  
                if ((Math.Abs(row - checker.Position[0]) == 2 && 
                    Math.Abs(column - checker.Position[1]) == 2))  
                {
                    if (checker.Color == "black" || checker.King)
                    {
                        // up right
                        if (row - checker.Position[0] == -2 && 
                        column - checker.Position[1] == 2)
                        {
                            JumpChecker(checker, row + 1, column - 1, row, column);
                            KingCheck(checker, row);
                            return;
                        }
                        // up left
                        if (row - checker.Position[0] == -2 && 
                            column - checker.Position[1] == -2)
                        {
                            JumpChecker(checker, row + 1, column + 1, row, column);
                            KingCheck(checker, row);
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Invalid move");
                        }
                    }
                    if (checker.Color == "white" || checker.King)
                    {
                        // down right
                        if (row - checker.Position[0] == 2 && 
                            column - checker.Position[1] == 2)
                        {
                            JumpChecker(checker, row - 1, column - 1, row, column);
                            KingCheck(checker, row);
                            return;
                        }
                        // down left
                        if (row - checker.Position[0] == 2 && 
                            column - checker.Position[1] == -2)
                        {
                            JumpChecker(checker, row - 1, column + 1, row, column);
                            KingCheck(checker, row);
                            return;      
                        }
                        else
                        {
                            Console.WriteLine("Invalid move");
                        }
                    }
                }
                // non-jumping
                else if (Math.Abs(row - checker.Position[0]) == 1 && 
                    Math.Abs(column - checker.Position[1]) == 1)
                {
                    if ((row > checker.Position[0] && checker.Color == "white") ||
                        (row < checker.Position[0] && checker.Color == "black") ||
                        checker.King)
                    {
                        PlaceChecker(checker, row, column);
                        KingCheck(checker, row);
                    }
                    else
                    {
                        Console.WriteLine("Invalid move");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid move");
                }
            }
            else
            {
                Console.WriteLine("Invalid move");
            }
            return;
        }

        public void JumpChecker(Checker checker, int row, int column,
            int newRow, int newColumn)
        {
          Checker deadChecker = Checkers.Find(x => x.Position.SequenceEqual(
                new int[] { row, column }));
          if (deadChecker.Color != checker.Color)
          {
              Checkers.Remove(deadChecker);
              PlaceChecker(checker, newRow, newColumn);
              return;
           }
           else 
           {
               Console.WriteLine("Invalid move");
               return;
            }  
        }
        
        public void RemoveChecker(int row, int column)
        {
            Checkers.Remove(Checkers.Find(x => x.Position.SequenceEqual(
                new int[] { row, column })));
            return;
        }

        public void KingCheck(Checker checker, int row)
        {
            if ((checker.Color == "white" && row == 7) ||
                (checker.Color == "black" && row == 0))
            {
                checker.King = true;
                PlaceCheckers();
                DrawBoard();
                if (checker.Color == "white")
                {
                    int openDiamondId = int.Parse("25D4", System.Globalization.NumberStyles.HexNumber);
                    string openDiamond = char.ConvertFromUtf32(openDiamondId);
                    checker.Symbol = openDiamond;
                }
                else
                {
                    int closedDiamondId = int.Parse("25D5", System.Globalization.NumberStyles.HexNumber);
                    string closedDiamond = char.ConvertFromUtf32(closedDiamondId);
                    checker.Symbol = closedDiamond;
                }
            }
        }
        
        public bool CheckForWin()
        {
            return Checkers.All(x => x.Color == "white") || 
                !Checkers.Exists(x => x.Color == "white");
        }
    }

    class Game
    {
        public Game()
        {
            Board board = new Board();
            board.CreateBoard();
            board.GenerateCheckers();
            board.PlaceCheckers();
            board.DrawBoard();
            while (!board.CheckForWin())
            {
                Console.Write("Enter starting row and column, " +
                    "separated by a comma: ");
                string rowAndColumn = Console.ReadLine();
                Regex regex = new Regex(@"\d, *\d");
                Match match = regex.Match(rowAndColumn);
                if (rowAndColumn != match.Value || rowAndColumn == "") 
                {
                    Console.WriteLine("Invalid entry");
                    continue;
                }
                string[] coordinates = rowAndColumn.Split(",");
                int startingRow = Convert.ToInt32(coordinates[0]) - 1;
                int startingColumn = Convert.ToInt32(coordinates[1]) - 1;
                Checker movingChecker;
                if (board.Checkers.Find(x => x.Position.SequenceEqual(
                    new int[] { startingRow, startingColumn })) != null)
                {
                    movingChecker = 
                    board.Checkers.Find(x => x.Position.SequenceEqual(
                        new int[] { startingRow, startingColumn }));
                }
                else
                {
                    Console.WriteLine("There is no checker there.");
                    movingChecker = null;
                    continue;
                }

                board.SelectChecker(startingRow, startingColumn);
                Console.Write("Enter ending row and column, " +
                    "separated by a comma: ");
                rowAndColumn = Console.ReadLine();
                match = regex.Match(rowAndColumn);
                if (rowAndColumn != match.Value || rowAndColumn == "") 
                {
                    Console.WriteLine("Invalid entry");
                    continue;
                }
                coordinates = rowAndColumn.Split(",");
                int endingRow = Convert.ToInt32(coordinates[0]) - 1;
                int endingColumn = Convert.ToInt32(coordinates[1]) - 1;
                board.MoveChecker(movingChecker, endingRow, endingColumn);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Game();
            
            Console.WriteLine("Hello World!");
        }
    }