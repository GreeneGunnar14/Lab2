using System;
using System.Collections.Generic;

namespace Lab2
{
    public class Program
    {
        static void Main(string[] args)
        {
        }

        public static bool IsBalanced(string s)
        {
            Stack<char> stack = new Stack<char>();

            //parse string into tokens

            foreach (char c in s)
            {
                switch (c)
                {
                    case '{':
                    case '(':
                    case '<':
                    case '[':
                        stack.Push(c);
                        continue;

                    case '}':
                        if (stack.Count == 0)
                        {
                            return false;
                        }

                        if (stack.Peek() == '{')
                        {
                            stack.Pop();
                        }

                        continue;

                    case ']':
                        if (stack.Count == 0)
                        {
                            return false;
                        }

                        if (stack.Peek() == '[')
                        {
                            stack.Pop();
                        }

                        continue;

                    case '>':
                        if (stack.Count == 0)
                        {
                            return false;
                        }

                        if (stack.Peek() == '<')
                        {
                            stack.Pop();
                        }

                        continue;

                    case ')':
                        if (stack.Count == 0)
                        {
                            return false;
                        }

                        if (stack.Peek() == '(')
                        {
                            stack.Pop();
                        }

                        continue;

                    default:
                        continue;
                }
            }

            if (stack.Count == 0)
            {
                return true;
            }

            return false;
        }

        public static double? Evaluate(string s)
        {
            Stack<double> stack = new Stack<double>();

            string[] tokens = s.Split();

            foreach (string t in tokens)
            {
                try
                {
                    double num = Convert.ToDouble(t);

                    stack.Push(num);
                }
                catch (FormatException)
                {
                    if (stack.Count < 2)
                    {
                        return null;
                    }
                    switch (t)
                    {
                        case "+":
                            var num2 = stack.Pop();
                            var num1 = stack.Pop();

                            stack.Push(num1 + num2);

                            continue;

                        case "*":
                            var num4 = stack.Pop();
                            var num3 = stack.Pop();

                            stack.Push(num3 * num4);

                            continue;

                        case "-":
                            var num6 = stack.Pop();
                            var num5 = stack.Pop();

                            stack.Push(num5 - num6);

                            continue;

                        case "/":
                            var num8 = stack.Pop();
                            var num7 = stack.Pop();

                            stack.Push(num7 / num8);

                            continue;

                        default:
                            return null;
                    }
                }
            }

            if (stack.Count != 1)
            {
                return null;
            }

            return stack.Pop();
        }
    }
}
