using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank
{
    public class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool Direction { get; set; }


        public Cell(int x, int y, bool direction)
        {
            this.X = x;
            this.Y = y;
            this.Direction = direction;
        }
    }
    class CrosswordPuzzle
    {
        static void Main(string[] args)
        {
            char[,] field = new char[10,10];
            for (int i = 0; i < 10; ++i)
            {
                String line = Console.ReadLine();

                for (int j = 0; j < 10; ++j)
                {
                    field[i, j] = line[j];
                }
            }
            String[] words = Console.ReadLine().Split(';').ToArray();

            Solve(field, words, words.Length);

        }

        private static void print(char[,] field){
            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    Console.Write(field[i,j]);
                }
                Console.WriteLine();
            }
        }



        static char[,] copyField(char[,] field)
        {
            char[,] ret = new char[10, 10];

            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    ret[i, j] = field[i, j];
                }
            }
            return ret;
        }

        static String[] copyWords(String[] words)
        {
            String[] copy = new String[words.Length];

            for (int i = 0; i < words.Length; ++i)
            {
                copy[i] = words[i];
            }

            return copy;
        }

        private static bool Solve(char[,] field, String[] words, int left)
        {
            if (left == 0)
            {
                print(field);
                return true;
            }


            char[,] curField = copyField(field);
            String[] curWords = copyWords(words);

            for (int i = 0; i < curWords.Length; ++i)
            {
                if (curWords[i] == null) continue;
                List<Cell> cells = findPlaces(curField, curWords[i]);
                foreach (Cell cell in cells)
                {
                    putWord(curField, curWords[i], cell);
                    curWords[i] = null;
                    if (Solve(curField, curWords, left - 1))
                    {
                        return true;
                    }
                    else
                    {
                        // reset state
                        curField = copyField(field);
                        curWords = copyWords(words);
                    }
                }
                return false;
            }
            return false;
        }

        private static void putWord(char[,] field, String word, Cell cell)
        {
            if (cell.Direction)
            {
                for (int k = 0; k < word.Length; ++k)
                {
                    field[cell.X + k, cell.Y] = word[k];
                }
            }
            else
            {
                for (int k = 0; k < word.Length; ++k)
                {
                    field[cell.X, cell.Y + k] = word[k];
                }
            }
        }

        private static int cellSize(char[,] field, int i, int j, bool direction)
        {
            int res = 0;
            if (direction)
            {
                while (i < 10)
                {
                    if (field[i++, j] == '+') break;
                    res++;
                }
            }
            else
            {
                while (j < 10)
                {
                    if (field[i, j++] == '+') break;
                    res++;
                }
            }
            return res;
        }

        private static List<Cell> findPlaces(char[,] curField, String curWord)
        {
            int xLength = curField.GetLength(0);
            int yLength = curField.GetLength(1);

            List<Cell> cells = new List<Cell>();

            for (int i = 0; i < xLength; ++i)
            {
                for (int j = 0; j < yLength; ++j)
                {
                    if (IsXStart(curField, i, j))
                    {
                        int l = cellSize(curField, i, j, true);
                        if (l == curWord.Length)
                        {
                            if (CanBeFitted(curField, i, j, curWord, true))
                            {
                                cells.Add(new Cell(i, j, true));
                            }
                        }
                    }
                    if (IsYStart(curField, i, j))
                    {
                        int l = cellSize(curField, i, j, false);
                        if (l == curWord.Length)
                        {
                            if (CanBeFitted(curField, i, j, curWord, false))
                            {
                                cells.Add(new Cell(i, j, false));
                            }
                        }
                    }
                }
            }

            return cells;
        }

        private static bool IsYStart(char[,] curField, int i, int j)
        {
            return (curField[i, j] != '+') && ((j == 0) || (curField[i, j - 1] == '+'));
        }

        private static bool IsXStart(char[,] curField, int i, int j)
        {
            return (curField[i, j] != '+') && ((i == 0) || (curField[i - 1, j] == '+'));
        }

        private static bool CanBeFitted(char[,] field, int i, int j, String word, bool direction)
        {
            if (direction)
            {
                for (int k = 0; k < word.Length; ++k)
                {
                    char c = field[i + k, j];
                    if (c != '-' && c != word[k]) return false;
                }
            }
            else
            {
                for (int k = 0; k < word.Length; ++k)
                {
                    char c = field[i, j + k];
                    if (c != '-' && c != word[k]) return false;
                }
            }
            return true;
        }
    }
}