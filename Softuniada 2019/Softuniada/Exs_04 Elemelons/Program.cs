using System;
using System.Linq;

namespace Exs_04_Elemelons
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            var cube = new char[n, n, n];
            for (int i = 0; i < n; i++)
            {
                var wall = Console.ReadLine()
                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Where(x => x != "|")
                    .Select(char.Parse)
                    .ToArray();
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        cube[j, i, k] = wall[j * n + k];
                    }
                }
            }


            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Melolemonmelon")
                {
                    break;
                }

                var input1 = input
                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int ei = input1[0];
                int ej = input1[1];
                int ek = input1[2];

                cube[ei, ej, ek] = '0';
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        for (int k = 0; k < n; k++)
                        {
                            if ((i == ei - 1 && j == ej && k == ek) ||
                                (i == ei + 1 && j == ej && k == ek) ||
                                (i == ei && j == ej - 1 && k == ek) ||
                                (i == ei && j == ej + 1 && k == ek) ||
                                (i == ei && j == ej && k == ek - 1) ||
                                (i == ei && j == ej && k == ek + 1))
                            {

                            }
                            else cube[i, j, k] = Morph(i, j, k, cube);
                        }
                    }
                }
            }

           
            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        Console.Write(cube[i, j, k]);
                        Console.Write(' ');
                    }

                    if(i!=n-1)
                    Console.Write("| ");
                }

                Console.WriteLine();
            }
        }

        static char Morph(int i, int j, int k, char[,,] cube1)
        {
                 if (cube1[i, j, k] == 'W') return 'E';
            else if (cube1[i, j, k] == 'E') return 'F';
            else if (cube1[i, j, k] == 'F') return 'A';
            else if (cube1[i, j, k] == 'A') return 'W';
            else return '0';
        }

    }
}
