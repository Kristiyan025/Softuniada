using System;
using System.Text;

namespace Exs_02_Crocs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n/2; i++)
            {
                Console.WriteLine(First(n, ' ','#'));
            }
            Console.WriteLine(First(n, '#', ' '));
            for (int i = 0; i < n-1; i++)
            {
                Console.WriteLine(Second(n,'#',' '));
                Console.WriteLine(Second(n,' ','#'));
            }
            Console.WriteLine(Second(n, '#', ' '));

            Console.WriteLine(First(n, '#', ' '));
            for (int i = 0; i < (n+1)/2; i++)
            {
                Console.WriteLine(new string('#', 5*n));
                Console.WriteLine(Second(n, '#', ' '));
            }

            Console.WriteLine(new string('#', 5 * n));
            for (int i = 0; i < n / 2; i++)
            {
                Console.WriteLine(First(n, ' ', '#'));
            }
        }

        static string First(int n,char s,char t)
        {
            StringBuilder sb=new StringBuilder();
            sb.Append(new string(s, n));
            sb.Append(new string(t, 3 * n));
            sb.Append(new string(s, n));
            return sb.ToString();
        }

        static string Second(int n, char s,char t)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(new string('#', n));
            sb.Append(' ');
            for (int i = 0; i < (3*n-3)/2; i++)
            {
                sb.Append(s);
                sb.Append(t);
            }

            sb.Append(s);
            sb.Append(' ');
            sb.Append(new string('#', n));
            return sb.ToString();
            
        }
    }
}
