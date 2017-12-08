using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace HackerRank
{
    class MissingNumbers
    {
        static void Main(string[] args)
        {

            int[] a = new int[Convert.ToInt32(Console.ReadLine())];
            a = Console.ReadLine().Split(' ').Select(n => Convert.ToInt32(n)).ToArray();

            //int m = a[0];
            int[] b = new int[Convert.ToInt32(Console.ReadLine())];
            b = Console.ReadLine().Split(' ').Select(n => Convert.ToInt32(n)).ToArray();

            Array.Sort(a);
            Array.Sort(b);

            int min = b[0];

            int[] aNew = new int[101];
            int[] bNew = new int[101];

            for (int i = 0; i < b.Length; i++)
            {
                bNew[b[i] - min]++;
            }
            for (int i = 0; i < a.Length; i++)
            {
                aNew[a[i] - min]++;
            }


            for (int i = 0; i < 101; i++)
            {
                if (bNew[i] > aNew[i])
                {
                    Console.Write(min + i + " ");
                }
            }

        }

    }
}


