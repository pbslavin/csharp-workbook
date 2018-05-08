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
            Rod rodOne = new Rod(initialStack, "one");
            Rod rodTwo = new Rod(new Disc[4], "two");
            Rod rodThree = new Rod(new Disc[4], "three");
            rodOne.checkAndMove(rodTwo);
            rodOne.checkAndMove(rodThree);
            rodTwo.checkAndMove(rodThree);
            rodOne.checkAndMove(rodTwo);
            rodThree.checkAndMove(rodOne);
            rodThree.checkAndMove(rodTwo);
            rodOne.checkAndMove(rodTwo);
            rodOne.checkAndMove(rodThree);
            rodTwo.checkAndMove(rodOne);
            rodTwo.checkAndMove(rodThree);
            rodOne.checkAndMove(rodTwo);
            rodThree.checkAndMove(rodOne);
            rodTwo.checkAndMove(rodOne);
            rodTwo.checkAndMove(rodThree);
            rodOne.checkAndMove(rodTwo);
            rodOne.checkAndMove(rodThree);
            rodTwo.checkAndMove(rodThree);
            rodOne.reportDiscs();
            rodTwo.reportDiscs();
            rodThree.reportDiscs();



            Console.WriteLine("");
        }

        class Rod 
        {   public string rodNumber;
            public Rod(Disc[] initialStack, string num)
            {
                this.rodNumber = num;
                Stack = initialStack;
            }
            public Disc[] Stack { get; private set; }
            public void checkAndMove(Rod dest)
            { 
                if (this.Stack[0] != null)
                {
                    Disc md = this.MoveDisc(dest);
                    if (md != null)
                    {
                        Console.WriteLine($"Moved size {md.Size} disc to rod {dest.rodNumber}");
                        dest.checkForWin();
                        return;
                    }
                }
                Console.WriteLine("Try again"); 
            }
            public Disc MoveDisc(Rod dest)
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
                
                // replace disc in original position if move is invalid
                this.Stack[i] = moved;
                return null;
            }

            public void reportDiscs()
            {
                if (this.Stack[0] != null)
                {
                    Console.Write($"Rod {this.rodNumber}: ");
                    foreach (Disc disc in this.Stack)
                    {
                        if (disc != null)
                        {
                            Console.Write($"{disc.Size} ");
                        }
                    }
                Console.WriteLine("");
                }
            }
            public void checkForWin()
            {
                if (this.Stack[this.Stack.Length - 1] != null)
                {
                    Console.WriteLine("You win!");
                }
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
