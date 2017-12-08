using System;
using System.Linq;

namespace HackerRank
{
    class InsertionSortPart1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Length: ");
            int length = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Enter array with spaces: ");
            string unsortedStr = Console.ReadLine();

            Sort(unsortedStr, length);
        }

        private static void Sort(string unsortedStr, int length)
        {
            int[] unsortedArr = unsortedStr.Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
            int i = length - 1;
            int temp = unsortedArr[i];
            while(unsortedArr[i-1]> temp && i > 0)
            {
                unsortedArr[i] = unsortedArr[i - 1];
                Console.WriteLine(string.Join(" ", unsortedArr));
                i -= 1;
                if(i == 0){
                    break;
                }
            }

            unsortedArr[i] = temp;
            Console.WriteLine(string.Join(" ", unsortedArr));
        }
    }
}
