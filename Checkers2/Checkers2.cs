using System;
using System.Collections.Generic;

namespace Checkers2
{
    // class Checker()
    // {
    //     public string Symbol { get; set; }
    //     public int[] Position { get; set; }
    //     public string Color { get; set; }
    // }

    // class Board()
    // {
    //     public string[][] Grid { get; set; }
    //     public List<Checker> Checkers { get; set; }
    //     static void CreateBoard()
    //     {

    //     }
    //     void DrawBoard()
    //     {

    //     }
    //     void GenerateBoard()
    //     {

    //     }
    //     void SelectChecker()
    //     {

    //     }
    //     void RemoveChecker()
    //     {

    //     }
    //     bool CheckForWin()
    //     {

    //     }
    // }

    // class Game()
    // {
    //     static void Start()
    //     {

    //     }
    // }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int openCircleId = int.Parse("25CB", System.Globalization.NumberStyles.HexNumber);
            string openCircle = char.ConvertFromUtf32(0x10FFFC);

            Console.WriteLine($"open circle: {openCircle}");

            int closedCircleId = int.Parse("25CF", System.Globalization.NumberStyles.HexNumber);
            string closedCircle = char.ConvertFromUtf32(closedCircleId);

            Console.WriteLine($"closed circle: {closedCircleId}");
        }
    }
}
