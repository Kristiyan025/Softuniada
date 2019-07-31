using System.Linq;

namespace Exs_07_Car
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            int c = int.Parse(Console.ReadLine());
            var numbers = new int[c];
            numbers = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            

            int inititial = int.Parse(Console.ReadLine());
            int max = int.Parse(Console.ReadLine());
            var table = new bool[c + 1][];
            for (int i = 0; i < c+1; i++)
            {
                table[i]=new bool[max+1];
                for (int j = 0; j < max+1; j++)
                {
                    table[i][j] = false;
                }
            }

            table[0][inititial] = true;
            for (int i = 1; i < c + 1; i++)
            {
                for (int j = 0; j < max+1; j++)
                {
                    if (j - numbers[i - 1] >= 0 && table[i-1][j - numbers[i - 1]])
                    {
                        table[i][j] = true;
                    }
                    if (j + numbers[i - 1] <= max && table[i - 1][j + numbers[i - 1]])
                    {
                        table[i][j] = true;
                    }
                }
            }

            int lastMaxSpeed = 0;
            for (int i = max; i >= 0; i--)
            {
                if (table[c][i])
                {
                    lastMaxSpeed = i;
                    break;
                }
            }

            bool b = table[c].Where(x => x == false).Count() == max + 1;
            if (b) lastMaxSpeed = -1;
            Console.WriteLine(lastMaxSpeed);
        }
    }
}
