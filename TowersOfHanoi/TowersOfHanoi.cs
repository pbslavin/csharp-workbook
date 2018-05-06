using System;

namespace TowersOfHanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            Disc smallest = new Disc(5);
            Disc medSmall = new Disc(10);
            Disc medLarge = new Disc(15);
            Disc largest = new Disc(20); 
            Disc[] initialStack = {largest, medLarge, medSmall, smallest};
            Disc[] emptyStack = new Disc[4];
            Rod rodOne = new Rod(initialStack);
            Rod rodTwo = new Rod(emptyStack);
            Rod rodThree = new Rod(emptyStack);
            rodOne.MoveDisc(rodTwo);
            Console.WriteLine("");

        }

        class Rod 
        {
            public Rod(Disc[] initialStack)
            {
                Stack = initialStack;
            }
            
            public Disc[] Stack { get; private set; }

            public void MoveDisc(Rod dest)
            {
                Disc moved = new Disc(0);

                for (int i = Stack.Length - 1; i > -1; i --)
                {
                    if (this.Stack[i] != null)
                    {
                        moved = this.Stack[i];
                        this.Stack[i] = null;
                        break;
                    }
                }
                for (int i = this.Stack.Length - 1; i > -1; i --)
                {
                    if ((dest.Stack[i] != null && dest.Stack[i].Size > moved.Size) && i > 0)
                    {
                        dest.Stack[i + 1] = moved;
                        break;
                    }
                    else if (i == 0)
                    {
                        dest.Stack[i] = moved;
                    }
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
