using System;

namespace TowersOfHanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            Disc five = new Disc(5);
            Disc ten = new Disc(10);
            Disc fifteen = new Disc(15);
            Disc twenty = new Disc(20); 
            Disc[] initialStack = { twenty, fifteen, ten, five };
            Rod rodOne = new Rod(initialStack, "1");
            Rod rodTwo = new Rod(new Disc[4], "2");
            Rod rodThree = new Rod(new Disc[4], "3");
            Rod fromRod = null;
            Rod toRod = null;

            Console.WriteLine("");
            rodOne.reportDiscs();
            rodTwo.reportDiscs();
            rodThree.reportDiscs();
            Console.WriteLine("");
            while (rodOne.winFlag == false && rodTwo.winFlag == false && rodThree.winFlag == false)
            {
                Console.WriteLine("Move from? (Enter 1, 2 or 3)");
                string from = Console.ReadLine();
                Console.WriteLine("Move to? (Enter 1, 2 or 3)");
                string to = Console.ReadLine();
                Rod [] rods = { rodOne, rodTwo, rodThree };
                foreach (Rod rod in rods)
                {
                    if (rod.Number == from)
                    {
                       fromRod = rod; 
                    }
                    if (rod.Number == to)
                    {
                        toRod = rod;
                    }
                }
                if (fromRod != null && toRod != null)
                {
                    fromRod.checkAndMove(toRod);
                    fromRod = null;
                    toRod = null;
                }
                else
                {
                    rodOne.printErrorMessage();        
                }
                rodOne.reportDiscs();
                rodTwo.reportDiscs();
                rodThree.reportDiscs();
                Console.WriteLine("");
            }
        }

        class Rod 
        {
            public bool winFlag = false;

            public Rod(Disc[] initialStack, string num)
            {
                Number = num;
                Stack = initialStack;
            }

            public string Number { get; private set; }

            public Disc[] Stack { get; private set; }

            public void checkAndMove(Rod dest)
            { 
                if (this.Stack[0] != null)
                {
                    Disc md = this.MoveDisc(dest);
                    if (md != null)
                    {
                        Console.WriteLine($"\nMoved size {md.Size} disc to rod {dest.Number}\n");
                        if (dest.checkForWin())
                        {
                            dest.winFlag = true;
                        }
                        return;
                    }
                }
                printErrorMessage(); 
            }

            private Disc MoveDisc(Rod dest)
            {
                Disc moved = new Disc(0);
                int i;
                for (i = Stack.Length - 1; i > -1; i --)
                {
                    if (this.Stack[i] != null)
                    {
                        moved = this.Stack[i];
                        this.Stack[i] = null;
                        break;
                    }
                }
                if (dest.Stack[0] != null)
                {
                    for (int j = this.Stack.Length - 1; j > -1; j --)
                    {
                        if ((dest.Stack[j] != null && dest.Stack[j].Size > moved.Size))
                        {
                            return dest.Stack[j + 1] = moved;
                        }
                    }
                }
                else
                {
                    return dest.Stack[0] = moved;
                }
                
                // replace disc in its original position if move is invalid
                this.Stack[i] = moved;
                return null;
            }

            public void reportDiscs()
            {   
                Console.Write($"Rod {this.Number}: ");
                if (this.Stack[0] != null)
                {
                    foreach (Disc disc in this.Stack)
                    {
                        if (disc != null)
                        {
                            Console.Write($"{disc.Size} ");
                        }
                    }
                }
            Console.WriteLine("");
            }

            public void printErrorMessage()
            {
                Console.WriteLine("\nTry again!\n");
            }

            public bool checkForWin()
            {
                if (this.Stack[this.Stack.Length - 1] != null)
                {
                    Console.WriteLine("You win!\n");
                    return true;
                }
                return false;
            }
        }

        class Disc 
        {
            public Disc(int size)
            {
                Size = size;
            }

            public int Size { get; private set; }

        }
    }
}
