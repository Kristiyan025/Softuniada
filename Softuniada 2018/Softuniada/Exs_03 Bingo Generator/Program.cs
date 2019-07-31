namespace Exs_03_Bingo_Generator
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {

            int fourDigits = int.Parse(Console.ReadLine());
            int firstTwoDigits = fourDigits / 1000 * 10 + fourDigits / 10 % 10;
            int secondTwoDigits = fourDigits / 100 % 10 * 10 + fourDigits % 10;
            int ceiling = firstTwoDigits + secondTwoDigits;
            var twelve = new List<int>();
            var fifteen = new List<int>();
            for (int i = firstTwoDigits; i <= ceiling; i++)
            {
                for (int j = secondTwoDigits; j <= ceiling; j++)
                {
                    int current = i * 100 + j;
                    if(current%12==0)twelve.Add(current);
                    if(current%15==0)fifteen.Add(current);
                }
            }

            Console.WriteLine($"Dividing on 12: {string.Join(" ", twelve)}");
            Console.WriteLine($"Dividing on 15: {string.Join(" ", fifteen)}");
            if (twelve.Count == fifteen.Count)
            {
                Console.WriteLine("!!!BINGO!!!");
            }
            else
            {
                Console.WriteLine("NO BINGO!");
            }

        }
    }
}
