using System;

namespace HackerRank
{
    class ThePrimeGame
    {
        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < t; i++)
            {
                Console.WriteLine(solve());
            }
        }

        public static int[] values = new int[] { 0, 0, 1, 1, 2, 2, 3, 3, 4 };
        public static String solve()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            long ak;
            long num = 0;
            for (int i = 0; i < n; i++)
            {
                ak = Convert.ToInt64(Console.ReadLine());
                num ^= values[(int)(ak % values.Length)];
            }
            if (num > 0) return "Manasa";
            return "Sandy";
        }
    }
}
