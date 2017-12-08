using System;
using System.Linq;

namespace HackerRank
{
    class SherlockAndArray
    {
        static void Main(string[] args)
        {
            int noOfInputs = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < noOfInputs; i++)
            {
                int[] Elements = new int[Convert.ToInt32(Console.ReadLine())];
                Elements = Console.ReadLine().Split(' ').Select(n => Convert.ToInt32(n)).ToArray();


                Console.WriteLine(Solve(Elements));
            }
        }
        static String Solve(int[] elements)
        {
            int sum = 0;
            int lhs = 0;
            for (int j = 0; j < elements.Length; j++)
            {
                sum = sum + elements[j];
            }
            int rhs = sum;
            for (int j = 0; j < elements.Length; j++)
            {
                rhs = rhs - elements[j];
                if (rhs == lhs)
                {
                    return "YES";
                }
                lhs = lhs + elements[j];
            }

            return "NO";
        }
    }
}
