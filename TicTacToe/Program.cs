using System;

namespace TicTacToe
{
    public class Program
    {
        public static string playerTurn = "X";
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
            do
            {   turn += 1;
                GetInput();
                if (CheckForWin()) 
                {
                    Console.WriteLine(playerTurn + " wins!");
                    break;
                }
                else if (turn == 8)
                {
                    Console.WriteLine("It's a tie.");
                    break;
                }
                playerTurn = (playerTurn == "X") ? "O" : "X";
            }
            while (true);

            // leave this command at the end so your program does not close automatically
            Console.ReadLine();
        }

        public static void GetInput()
        {
            Console.WriteLine("Player " + playerTurn);
            Console.WriteLine("Enter Row:");
            int row = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Column:");
            int column = int.Parse(Console.ReadLine());
            PlaceMark(row, column);
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
            return ((board[0][0] == playerTurn && board[0][1] == playerTurn && board[0][2] == playerTurn) || 
            (board[1][0] == playerTurn && board[1][1] == playerTurn && board[1][2] == playerTurn) ||
            (board[2][0] == playerTurn && board[2][1] == playerTurn && board[2][2] == playerTurn));
        }

        public static bool VerticalWin()
        {
            return ((board[0][0] == playerTurn && board[1][0] == playerTurn && board[2][0] == playerTurn) || 
            (board[0][1] == playerTurn && board[1][1] == playerTurn && board[2][1] == playerTurn) ||
            (board[0][2] == playerTurn && board[1][2] == playerTurn && board[2][2] == playerTurn));
        }

        public static bool DiagonalWin()
        {
            return ((board[0][0] == playerTurn && board[1][1] == playerTurn && board[2][2] == playerTurn) || 
            (board[0][2] == playerTurn && board[1][1] == playerTurn && board[2][0] == playerTurn));
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
