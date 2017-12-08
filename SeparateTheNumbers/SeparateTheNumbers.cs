using System;
using System.Text;

namespace HackerRank
{
    class SeparateTheNumbers
    {
        static void Main(string[] args)
        {
            Console.WriteLine("No. of strings to evaluate: ");
            int noOfInputs = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < noOfInputs; i++)
            {
                Console.Write("Input: ");
                string input = Console.ReadLine();
                Tuple<long, bool> output = Check(input);

                Console.WriteLine(output.Item2 ? "YES " + output.Item1 : "NO");
            }
        }

        private static Tuple<long, bool> Check(string input)
        {
            bool flag = false;
            long firstx = -1;
            for (int size = 1; size <= input.Length / 2; ++size)
            {
                long x = Convert.ToInt64(input.Substring(0, size));
                firstx = x;
                string test = x.ToString();
                while (test.Length < input.Length)
                {
                    test += (++x).ToString();
                }
                if (test.Equals(input))
                {
                    flag = true;
                    break;
                }
            }

            return Tuple.Create(firstx, flag);
        }
    }

}






