using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank
{
    class MatrixLayerRotation
    {
        static int[][] Matrix;
        static int R;
        static int level;

        static void Main(string[] args)
        {
            level = 0;
            string input1 = Console.ReadLine();
            int[] inpput1Arr = input1.Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
            int M = inpput1Arr[0];
            int N = inpput1Arr[1];
            R = inpput1Arr[2];

            Matrix = new int[M][];

            for (int y = 0; y < M; y++)
            {
                Matrix[y] = Console.ReadLine().Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
                if (y == M - 1) { break; }
            }

            Rotate(M, N);

            Print(M, N);
        }

        public static void Rotate(int h, int w)
        {

            Queue<int> que = new Queue<int>();

            for (int i = 0 + level; i < w - 1 - level; i++)
            {
                que.Enqueue(Matrix[0 + level][i]);
            }
            for (int i = 0 + level; i < h - 1 - level; i++)
            {
                que.Enqueue(Matrix[i][w - 1 - level]);
            }
            for (int i = w - 1 - level; i > 0 + level; i--)
            {
                que.Enqueue(Matrix[h - 1 - level][i]);
            }
            for (int i = h - 1 - level; i > 0 + level; i--)
            {
                que.Enqueue(Matrix[i][0 + level]);
            }
            int redo = R;

            if ((2 * (h - level * 2) + 2 * (w - level * 2) - 4) > 0)
            {
                redo = R % (2 * (h - level * 2) + 2 * (w - level * 2) - 4);
            }

            for (int i = 0; i < redo; i++)
            {
                que.Enqueue(que.Dequeue());
            }

            for (int i = 0 + level; i < w - 1 - level; i++)
            {
                Matrix[0 + level][i] = que.Dequeue();
            }
            for (int i = 0 + level; i < h - 1 - level; i++)
            {
                Matrix[i][w - 1 - level] = que.Dequeue();
            }
            for (int i = w - 1 - level; i > 0 + level; i--)
            {
                Matrix[h - 1 - level][i] = que.Dequeue();
            }
            for (int i = h - 1 - level; i > 0 + level; i--)
            {
                Matrix[i][0 + level] = que.Dequeue();
            }

            if (level < w / 2 - 1 && level < h / 2 - 1)
            {
                level++;
                Rotate(h, w);
            }

        }

        public static void Print(int h, int w)
        {
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    Console.Write(Matrix[y][x] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

    }
}
