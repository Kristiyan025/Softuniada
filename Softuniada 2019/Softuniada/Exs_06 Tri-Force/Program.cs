using System;

namespace Exs_06_Tri_Force
{
    class Program
    {
        static void Main(string[] args)
        {
            int p = int.Parse(Console.ReadLine());
            decimal r = decimal.Parse(Console.ReadLine());
            decimal np = p / 2.0m;
            for (int i = (int)(2 * r); i >= 1; i--)
            {
                for (int j = p - i - 1; j >= 1; j--)
                {
                    int k = p - i - j;
                    if (i < j + k && j < i + k && k < i + j)
                    {
                        decimal s = np * (np - i) * (np - j) * (np - k);
                        decimal newR = (i * i * j * j * k * k) / (16.0m * s);
                        if (newR.Equals(r * r))
                        {
                            Console.WriteLine($"{i}.{j}.{k}");
                        }
                    }
                }
            }
        }
    }
}