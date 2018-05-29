using System;
using System.Collections.Generic;

namespace TowersOfHanoi
{
    class Program
    {
        static void Main()
        {
            TowerOfHanoi T = new TowerOfHanoi();
            string cnumdiscs;
            Console.Write("Enter the number of discs: ");
            cnumdiscs = Console.ReadLine();
            T.numdiscs = Convert.ToInt32(cnumdiscs);
            T.moveTower(T.numdiscs, 1, 2, 3);
            Console.ReadLine();
        }
    }

    class TowerOfHanoi
    {
        int m_numdiscs;

        public TowerOfHanoi()
        {
            numdiscs = 0;
        }
        public TowerOfHanoi(int newval)
        {
            numdiscs = newval;
        }
        public int numdiscs
        {
            get
            {
                return m_numdiscs;
            }
            set
            {
                if (value > 0)
                {
                    m_numdiscs = value;
                }
            }           
        }
        public void moveTower(int n, int from, int to, int other)
        {
            if (n > 0)
            {
                moveTower(n - 1, from, other, to);
                Console.WriteLine("Move disc {0} from tower {1} to tower {2}", n, from, to);
                moveTower(n -1, other, to, from);
            }
        }
    }    
}

