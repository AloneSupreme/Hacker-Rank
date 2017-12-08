using System;

namespace HackerRank
{
    class Pairs
    {
        static void Main(string[] args)
        {
            int res;

            String line = Console.ReadLine();
            String[] line_split = line.Split(' ');
            int _a_size = Convert.ToInt32(line_split[0]);
            int _k = Convert.ToInt32(line_split[1]);
            int[] _a = new int[_a_size];
            int _a_item;
            String move = Console.ReadLine();
            String[] move_split = move.Split(' ');
            for (int _a_i = 0; _a_i < move_split.Length; _a_i++)
            {
                _a_item = Convert.ToInt32(move_split[_a_i]);
                _a[_a_i] = _a_item;
            }

            res = pairs(_a, _k);
            Console.WriteLine(res);
        }

        private static int pairs(int[] a, int k)
        {
            int count = 0;
            Array.Sort(a);

            int i = 0;
            int j = 1;
            while (j < a.Length)
            {
                int diff = a[j] - a[i];
                if (diff == k)
                {
                    count++;
                    j++;
                }
                else if (diff > k)
                {
                    i++;
                    if (i == j)
                    {
                        j++;
                    }
                }
                else if (diff < k)
                {
                    j++;
                }
            }

            return count;
        }
    }
}
