using System;
using System.Collections;

namespace Stacks
{
    public class MyStack
    {
        private Stack theStack;

        public MyStack()
        {
            theStack = new Stack();
        }

        public Stack TheStack { get; set; }

        public void MyPush(Object obj)
        {   
            if (obj != null)
            {
                theStack.Push(obj);
            }
            else
            {
                throw new InvalidOperationException("Nothing to push");
            }
        }

        public Object MyPop()
        {
            if (theStack.Peek() != null)
            {
                return theStack.Pop();
            }
            else
            {
                throw new InvalidOperationException("Stack empty");
            }
        }

        public void MyClear()
        {
            Console.WriteLine("Clearing stack");
            theStack.Clear();
        }

        public void ShowValues()
        {
            if (theStack.Count != 0)
            {
                foreach (var member in theStack)
                {
                    Console.WriteLine("value: {0}", member);
                }
            }
            else
            {
                Console.WriteLine("Nothing to see here.");
            }
        }
    }

    public class Program
    {
        static void Main()
        {
            int num1 = 35;
            int num2 = 8;
            string str1 = "thirty-five";
            string str2 = "eight";
            int? nothing = null;
            MyStack myStack = new MyStack();

            myStack.MyPush(num1);
            myStack.MyPush(num2);
            myStack.MyPush(str1);
            myStack.MyPush(str2);
            myStack.MyPush(nothing);

            myStack.ShowValues();
            Console.WriteLine(myStack.MyPop());
            Console.WriteLine(myStack.MyPop());
            Console.WriteLine(myStack.MyPop());
            // Console.WriteLine(myStack.MyPop());
            // Console.WriteLine(myStack.MyPop());
            myStack.ShowValues();
            myStack.MyClear();
            myStack.ShowValues();

        }
    }     
}
