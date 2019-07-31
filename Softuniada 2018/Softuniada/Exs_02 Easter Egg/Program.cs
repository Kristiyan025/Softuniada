namespace Exs_02_Easter_Egg
{
    using System;
    using System.Text;

    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            Console.Write(First(n));
            Console.Write(Second(n,false));
            Console.Write(Third(n,false));
            Console.Write(Forth(n));
            Console.Write(Third(n,true));
            Console.Write(Second(n,true));
            Console.Write(First(n));

        }

        public static string First(int n)
        {
            string s = string.Empty;
            s+=new string('.', 2 * n);
            s+=new string('*', n);
            s+=new string('.', 2 * n);
            s += "\n";
            return s;
        }

        public static string Second(int n, bool b)
        {
            StringBuilder s = new StringBuilder();
            if (!b)
            {
                for (int i = 1; i <= n / 2; i++)
                {
                    int k = 2 * (n - i);
                    s.Append(new string('.', k));
                    s.Append(new string('*', i));
                    s.Append(new string('+', n + 2 * i));
                    s.Append(new string('*', i));
                    s.Append(new string('.', k));
                    s.Append("\n");
                }
            }
            else
            {
                for (int i = n / 2; i >= 1; i--)
                {
                    int k = 2 * (n - i);
                    s.Append(new string('.', k));
                    s.Append(new string('*', i));
                    s.Append(new string('+', n + 2 * i));
                    s.Append(new string('*', i));
                    s.Append(new string('.', k));
                    s.Append("\n");
                }
            }

            return s.ToString();
        }

        public static string Third(int n, bool b)
        {
            StringBuilder s = new StringBuilder();
            if (!b)
            {
                for (int i = 1; i <= n / 2; i++)
                {
                    s.Append(new string('.', n - i));
                    s.Append("**");
                    s.Append(new string('=', 3 * n + 2 * i - 4));
                    s.Append("**");
                    s.Append(new string('.', n - i));
                    s.Append("\n");
                }
            }
            else
            {
                for (int i = n / 2; i >= 1; i--)
                {
                    s.Append(new string('.', n - i));
                    s.Append("**");
                    s.Append(new string('=', 3 * n + 2 * i - 4));
                    s.Append("**");
                    s.Append(new string('.', n - i));
                    s.Append("\n");
                }
            }

            return s.ToString();
        }

        public static string Forth(int n)
        {
            string s = string.Empty;
            s += new string('.', n / 2);
            s += "**";
            s += new string('~', 2 * n - 8);
            s += "HAPPY EASTER";
            s += new string('~', 2 * n - 8);
            s += "**";
            s += new string('.', n / 2);
            s += "\n";
            return s;
        }

    }
}
