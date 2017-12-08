using System;
using System.Linq;

namespace HackerRank
{
    class BirthdayChoclate
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the number of squares in the choclate bar: ");
            int lengthOfBar = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the numbers written on each consecutive square of chocolate (space saperated): ");
            int[] numbersOnChoclate = Console.ReadLine().Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
            Console.WriteLine("Please enter the Ron's birth day and month(dd mm): ");
            int[] birthDate = Console.ReadLine().Split(' ').Select(n => Convert.ToInt32(n)).ToArray();

            int differentNoOfways = HelpLilli(lengthOfBar, numbersOnChoclate, birthDate);
            Console.WriteLine(differentNoOfways);
        }

        private static int HelpLilli(int lengthOfBar, int[] numbersOnChoclate, int[] birthDate)
        {
            int sum;
            int noOfWays = 0;

            for (int i = 0; i <= lengthOfBar - birthDate[1]; i++)
            {
                sum = 0;
                for (int j = i; j-i < birthDate[1]; j++)
                {
                    sum = sum + numbersOnChoclate[j];
                }
                if(birthDate[0] == sum)
                {
                    noOfWays++;
                }
            }
            return noOfWays;
        }
    }
}
