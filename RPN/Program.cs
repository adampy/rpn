using System;

namespace RPN
{
    class Stack
    {
        object[] items = new object[128];
        int indx = -1;

        public void Push(object obj)
        {
            this.indx++;
            this.items[this.indx] = obj;
        }

        public object Pop()
        {
            object item = this.items[this.indx];
            this.indx--;
            return item;
        }
    }

    class Program
    {
        static int ReversePolish(string[] items)
        {
            Stack stack = new Stack();

            foreach(string item in items)
            {
                if (item == "+")
                {
                    object a = stack.Pop();
                    object b = stack.Pop();
                    dynamic result = (dynamic)b + (dynamic)a;
                    stack.Push(result);
                }
                else if (item == "-")
                {
                    object a = stack.Pop();
                    object b = stack.Pop();
                    dynamic result = (dynamic)b - (dynamic)a;
                    stack.Push(result);
                }
                else if (item == "*")
                {
                    object a = stack.Pop();
                    object b = stack.Pop();
                    dynamic result = (dynamic)b * (dynamic)a;
                    stack.Push(result);
                }
                else if (item == "/")
                {
                    object a = stack.Pop();
                    object b = stack.Pop();
                    dynamic result = (dynamic)b / (dynamic)a;
                    stack.Push(result);
                }
                else
                {
                    stack.Push(Convert.ToInt32(item));
                }
            }

            return Convert.ToInt32(stack.Pop());
        }
        static void Main(string[] args)
        {
            int[] arr = { 4, 7, 7, 27, 3, 1, 2, 89, 7, 1 };

            unsafe
            {
                fixed (int* pointer = &arr[0])
                {
                    Console.WriteLine(*pointer);
                    int inc = Convert.ToInt32(Console.ReadLine());
                    int* pointer2 = pointer + inc;
                    Console.WriteLine(*pointer2);
                }
            }
            

            /*Console.Write("Enter a postfix notation expression: ");
            string input = Console.ReadLine();
            string[] splitted = input.Split(' ');

            Console.WriteLine(ReversePolish(splitted));*/
            
        }
    }
}
