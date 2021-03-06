﻿using System;

namespace TicTacToe
{
    public class Program
    {
        public static string playerTurn;
        public static string[][] board = new string[][]
        {
            new string[] {" ", " ", " "},
            new string[] {" ", " ", " "},
            new string[] {" ", " ", " "}
        };
        public static int turn = 0;

        public static void Main()
        {
            DrawBoard();
            while (playerTurn != "X" && playerTurn != "O")
            {
                Console.WriteLine("Play 'X' or 'O'?");
                playerTurn = Console.ReadLine().ToUpper();
            }
            do
            {   
                turn += 1;
                GetInput();
                if (CheckForWin()) 
                {
                    Console.WriteLine(playerTurn + " wins!");
                    break;
                }
                // after 8 turns, the final possible move is made automatically
                if (turn == 8)
                {   
                    playerTurn = (playerTurn == "X") ? "O" : "X";
                    for (int i = 0; i < 3; i ++)
                    {
                        for (int j = 0; j < 3; j ++)
                        {
                            if (board[i][j] == " ")
                            {
                                PlaceMark(i, j);
                            }
                        }
                    }
                    if (CheckForWin())
                    {
                       Console.WriteLine(playerTurn + " wins!");
                        break; 
                    }

                    Console.WriteLine("It's a tie.");
                    break;
                }
                playerTurn = (playerTurn == "X") ? "O" : "X";
            }
            while (true);

            // leave this command at the end so your program does not close automatically
            Console.ReadLine();
        }

        public static void invalidEntry()
        {
            Console.WriteLine("That entry is invalid.");
        }

        public static void GetInput()
        {    
            int row = 0;
            int column = 0;
            bool invalidRow = false;
            bool invalidColumn = false;
            bool occupied;
            do
            {   
                occupied = false;
                Console.WriteLine("Player " + playerTurn);

                // take row input and check if valid
                do
                {
                    Console.WriteLine("Enter Row:");
                    try
                    {
                        row = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        invalidRow = true;
                        invalidEntry();
                        continue;
                    }
                    if (row > -1 && row < 3)
                    {
                        invalidRow = false;
                    }
                    else
                    {
                        invalidRow = true;
                        invalidEntry();
                    }
                }
                while (invalidRow);

                // take column input and check if valid
                do
                {
                    Console.WriteLine("Enter Column:");
                    try
                    {
                        column = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        invalidColumn = true;
                        invalidEntry();
                        continue;
                    }
                    if (column > -1 && column < 3)
                    {
                        invalidColumn = false;
                    }
                    else
                    {
                        invalidColumn = true;
                        invalidEntry();
                    }
                }
                while (invalidColumn);
                
                
                // Check if cell is occupied
                if (board[row][column] != " ") 
                {
                    Console.WriteLine("That cell is occupied.");
                    occupied = true;
                }
                else
                {
                    occupied = false;
                    PlaceMark(row, column);
                }
            } 
            while (occupied);
        }

        public static void PlaceMark(int row, int column)
        {
            board[row][column] = playerTurn;
            DrawBoard();
        }

        public static bool CheckForWin()
        {
            return (HorizontalWin() || VerticalWin() || DiagonalWin());
        }
        
        public static bool HorizontalWin()
        {   
            for (int i = 0; i < 3; i ++)
            {
                for (int j = 1; j < 3; j ++)
                {
                    if (board[i][j] != board[i][0] || board[i][j] == " ")
                    {
                        break;
                    }
                    if (j == 2)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool VerticalWin()
        {
            for (int i = 0; i < 3; i ++)
            {
                for (int j = 1; j < 3; j ++)
                {
                    if (board[j][i] != board[0][i] || board[j][i] == " ")
                    {
                        break;
                    }
                    if (j == 2)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool DiagonalWin()
        {
            // check top left to bottom right
            for (int i = 1; i < 3; i ++)
            {
                if (board[i][i] != board[0][0] || board[i][i] == " ")
                {
                    break;
                }
                if (i == 2)
                    {
                        return true;
                    }
            }

            //check top right to bottom left
            for (int i = 1; i < 3; i ++)
            {
                if (board[i][2 - i] != board[0][2] || board[i][2 - i] == " ")
                {
                    break;
                }
                if (i == 2)
                {
                    return true;
                }
            }
            return false;
        }

        public static void DrawBoard()
        {
            Console.WriteLine("  0 1 2");
            Console.WriteLine("0 " + String.Join("|", board[0]));
            Console.WriteLine("  -----");
            Console.WriteLine("1 " + String.Join("|", board[1]));
            Console.WriteLine("  -----");
            Console.WriteLine("2 " + String.Join("|", board[2]));
        }
    }
}
