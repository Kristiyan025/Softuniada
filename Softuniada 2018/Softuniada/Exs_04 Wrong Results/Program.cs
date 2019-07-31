namespace Exs_04_Wrong_Results
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            var cube = new int[n,n,n];
            for (int i = 0; i < n; i++)
            {
                var wall = Console.ReadLine()
                    .Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Where(x => x != "|")
                    .Select(int.Parse)
                    .ToArray();
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        cube[j, i, k] = wall[j * n + k];
                    }
                }
            }

            var input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int ei = input[0];
            int ej = input[1];
            int ek = input[2];
            int value = cube[ei, ej, ek];

            var cube1 = new int[n,n,n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        cube1[i, j, k] = cube[i, j, k];
                    }
                }
            }

            int counter = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        if (cube[i, j, k] == value)
                        {
                            int current = 0;
                            if (i - 1 >= 0 && cube[i - 1, j    , k    ] != value) current += cube[i - 1, j, k];
                            if (i + 1 <  n && cube[i + 1, j    , k    ] != value) current += cube[i + 1, j, k];
                            if (j - 1 >= 0 && cube[i    , j - 1, k    ] != value) current += cube[i, j - 1, k];
                            if (j + 1 <  n && cube[i    , j + 1, k    ] != value) current += cube[i, j + 1, k];
                            if (k - 1 >= 0 && cube[i    , j    , k - 1] != value) current += cube[i, j, k - 1];
                            if (k + 1 <  n && cube[i    , j    , k + 1] != value) current += cube[i, j, k + 1];
                            cube1[i, j, k] = current;
                            counter++;
                        }
                    }
                }
            }

            Console.WriteLine($"Wrong values found and replaced: {counter}");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        Console.Write(cube1[i,j,k]);
                        Console.Write(' ');
                    }

                    Console.WriteLine();
                }
            }

        }
    }
}
