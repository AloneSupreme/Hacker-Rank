using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank
{
    class TwoCharacters
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Length of s: ");
            int length = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the string s: ");
            string s = Console.ReadLine();
            int lengthOfStringT = Solve(s, length);
            Console.WriteLine(lengthOfStringT);
        }

        private static int Solve(string s, int length)
        {
            int tLength = 0;
            for (int i = 0; i < length; i++)
            {
                for (int j = i + 1; j < length; j++)
                {
                    if (s[i] != s[j])
                    {
                        bool flag = true;
                        Stack<char> stack = new Stack<char>();
                        foreach (char charInS in s)
                        {
                            if (charInS == s[i] || charInS == s[j])
                            {
                                stack.Push(charInS);
                            }
                        }
                        char[] charArr = stack.ToArray();
                        for (int k = 0; k < charArr.Length - 1; k++)
                        {
                            if (charArr[k] != charArr[k + 1] && flag == true)
                            {
                                flag = true;
                            }
                            else
                            {
                                flag = false;
                            }
                        }
                        if (flag == true && charArr.Length > tLength)
                        {
                            tLength = charArr.Length;
                        }
                    }
                }
            }
            return tLength;
        }
    }
}