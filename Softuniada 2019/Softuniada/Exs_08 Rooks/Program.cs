namespace Exs_08_Rooks
{
    using System;

    public class Program
    {
        public static int C(int k, int n)
        {
            int result = 1;
            for (int i = n; i >= n - k + 1; i--)
            {
                result *= i;
            }

            for (int i = k; i >= 1; i--)
            {
                result /= i;
            }

            return result;
        }

        public static void Main(string[] args)
        {
            
            // the code that you want to measure comes here
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int x = int.Parse(Console.ReadLine());
            var p = new long[n + 1][][];
            for (int i = 0; i <= n; i++)
            {
                p[i] = new long[m + 1][];
                for (int j = 0; j <= m; j++)
                {
                    p[i][j] = new long[x + 1];
                    p[i][j][0] = 1;
                    for (int k = 1; k <= x; k++)
                    {
                        p[0][j][k] = 0;
                        p[i][0][k] = 0;
                    }
                }
            }

            for (int k = 1; k <= x; k++)
            {
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= m; j++)
                    {
                        p[i][j][k] = 0;
                        if (i - 2 >= 0 && j - 1 >= 0 && k - 2 >= 0)
                        {
                            p[i][j][k] += (C(2, i) * p[i - 2][j - 1][k - 2]) % 1000001;
                        }

                        if (i - 1 >= 0 && j - 2 >= 0 && k - 2 >= 0)
                        {
                            p[i][j][k] += (C(1, i) * C(1,j - 1) * p[i - 1][j - 2][k - 2]) % 1000001;
                        }

                        if (i - 1 >= 0 && j - 1 >= 0 && k - 1 >= 0)
                        {
                            p[i][j][k] += (C(1, i) * p[i - 1][j - 1][k - 1]) % 1000001;
                        }

                        if (j - 1 >= 0)
                        {
                            p[i][j][k] += p[i][j - 1][k] % 1000001;
                        }

                        p[i][j][k] %= 1000001;
                    }
                }
            }

            Console.WriteLine(p[n][m][x]);
        }
    }
}
