using System;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace Exs_05_Grid_Voyage
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var m = new int[n][];
            for (int i = 0; i < n; i++)
            {
                m[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    m[i][j] = 0;
                }
            }

            var coor = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int si = coor[0], ssi=si;
            int sj = coor[1], ssj=sj;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "eastern odyssey")
                {
                    break;
                }

                var parts = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                int newX = int.Parse(parts[0]);
                int newY = int.Parse(parts[1]);
                string dir = parts[2];
                int stamina = int.Parse(parts[3]), sta=stamina;
                int c = 0;
                var copyM = new int[n][];
                for (int i = 0; i < n; i++)
                {
                    copyM[i] = new int[n];
                    for (int j = 0; j < n; j++)
                    {
                        copyM[i][j] = m[i][j];
                    }
                }

                while (true)
                {
                    if (dir != "imp")
                    {
                         si = MorphI(si, dir);
                         sj = MorphJ(sj, dir);
                    }
                    else
                    {
                        Console.WriteLine("Voyage impossible");
                        for (int i = 0; i < n; i++)
                        {
                            for (int j = 0; j < n; j++)
                            {
                                Console.Write(copyM[i][j]);
                                Console.Write(" ");
                            }

                            Console.WriteLine();
                        }
                    }
                    if(si>=0 && si==n-1 && sj >= 0 && sj == n - 1)
                    m[si][sj] += 1;
                    stamina--;
                    if (si == newX && sj == newY)
                    {
                        break;
                    }
                    if (stamina == 0)
                    {
                        stamina = sta;
                        c++;
                        if (dir == "left")
                        {
                            if (si <= newX)
                            {
                                if (si + stamina <= n - 1)
                                {
                                    dir = "down";
                                }
                                else if (si - stamina >= 0)
                                {
                                    dir = "up";
                                }
                                else
                                {
                                    dir = "imp";
                                }
                            }
                            else
                            {
                                if (si - stamina >= 0)
                                {
                                    dir = "up";
                                }
                                else if (si + stamina <= n - 1)
                                {
                                    dir = "down";
                                }
                                else
                                {
                                    dir = "imp";
                                }
                            }

                        }
                        else if (dir == "right")
                        {
                            if (si >= newX)
                            {
                                if (si - stamina >= 0)
                                {
                                    dir = "up";
                                }
                                else if (si + stamina <= n - 1)
                                {
                                    dir = "down";
                                }
                                else
                                {
                                    dir = "imp";
                                }
                            }
                            else
                            {
                                if (si + stamina <= n - 1)
                                {
                                    dir = "down";
                                }
                                else if (si - stamina >= 0)
                                {
                                    dir = "up";
                                }
                                else
                                {
                                    dir = "imp";
                                }
                            }

                        }
                        else if (dir == "up")
                        {
                            if (sj >= newY)
                            {
                                if (sj - stamina >= 0)
                                {
                                    dir = "left";
                                }
                                else if (sj + stamina <= n - 1)
                                {
                                    dir = "right";
                                }
                                else
                                {
                                    dir = "imp";
                                }
                            }
                            else
                            {
                                if (sj + stamina <= n - 1)
                                {
                                    dir = "right";
                                }
                                else if (sj - stamina >= 0)
                                {
                                    dir = "left";
                                }
                                else
                                {
                                    dir = "imp";
                                }                                
                            }
                        }
                        else if(dir == "down")
                        {
                            if (sj <= newY)
                            {
                                if (sj + stamina <= n - 1)
                                {
                                    dir = "right";
                                }
                                else if (sj - stamina >= 0)
                                {
                                    dir = "left";
                                }
                                else
                                {
                                    dir = "imp";
                                }
                            }
                            else
                            {
                                if (sj - stamina >= 0)
                                {
                                    dir = "left";
                                }
                                else if (sj + stamina <= n - 1)
                                {
                                    dir = "right";
                                }
                                else
                                {
                                    dir = "imp";
                                }
                            }

                        }
                    }

                }

                Console.WriteLine(c);
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(m[i][j]);
                    Console.Write(' ');
                }

                Console.WriteLine();
            }
        }

        static int MorphI(int i,string dir)
        {
            if (dir == "left") return i;
            if (dir == "right") return i;
            if (dir == "up") return i-1;
            if (dir == "down") return i+1;
            return 0;
        }

        static int MorphJ(int j, string dir)
        {
            if (dir == "left") return j - 1;
            if (dir == "right") return j + 1;
            if (dir == "up") return j;
            if (dir == "down") return j;
            return 0;
        }
    }
}
