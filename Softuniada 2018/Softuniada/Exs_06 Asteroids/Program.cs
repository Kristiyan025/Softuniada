using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Exs_06_Asteroids
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }

                var parts = input.Split('x');
                int n = int.Parse(parts[0]);
                int m = int.Parse(parts[1]);

                var g = new bool[n][];

                for (int i = 0; i < n; i++)
                {
                    string line = Console.ReadLine();
                    g[i] = new bool[m];
                    for (int j = 0; j < m; j++)
                    {
                        g[i][j] = (int)line[j] - 48 == 1;
                    }
                }

                var counts = Bfs(n, m, g);
                var list = new List<KeyValuePair<int,int>>();
                for (int i = 0; i < counts[0].Count; i++)
                {
                    list.Add(new KeyValuePair<int,int>(counts[0][i],counts[1][i]));
                }

                list = list.OrderByDescending(x => x.Key).ToList();
                foreach (var par in list)
                {
                    Console.WriteLine(par.Value.ToString() + 'x' + par.Key.ToString());
                }

                Console.WriteLine(list.Select(x=>x.Value).Sum());
            }

        }

        static List<List<int>> DFS(int vx, int vy, int n, int m, bool[][] g)
        {
            var used = new bool[n][];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    used[i][j] = false;
                }
            }

            if (g[vx][vy])
            {
                if (vx < n - 1 && !g[vx + 1][vy])
                {
                    DFS(vx + 1, vy, n, m, g);
                }

                if (vx > 0 && !g[vx - 1][vy])
                {
                    DFS(vx - 1, vy, n, m, g);

                }

                if (vy < n - 1 && !g[vx][vy + 1])
                {
                    DFS(vx - 1, vy, n, m, g);

                }

                if (vy > 0 && !g[vx][vy - 1])
                { 
                    DFS(vx + 1, vy, n, m, g);

                }
            }

                return new List<List<int>>();
        }

        static List< List<int> > Bfs(int n, int m, bool[][] g)
        {
            /*var used = new bool[n][];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    used[i][j] = false;
                }
            }

            used[vx][vy] = true;
            var qx = new Queue<int>();
            var qy = new Queue<int>();
            qx.Enqueue(vx);
            qy.Enqueue(vy);
            int count = 0;
            while (qx.Count != 0)
            {
                int cx = qx.Dequeue();
                int cy = qy.Dequeue();

                if (cx < n - 1 && !used[cx + 1][cy] )
                {
                    used[cx + 1][cy] = true;
                    qx.Enqueue(cx+1);
                    qy.Enqueue(cy);
                }

                if (cx > 0 && !used[cx - 1][cy])
                {
                    used[cx - 1][cy] = true;
                    qx.Enqueue(cx - 1);
                    qy.Enqueue(cy);
                }

                if (cy < n - 1 && !used[cx][cy+1])
                {
                    used[cx][cy+1] = true;
                    qx.Enqueue(cx);
                    qy.Enqueue(cy+1);
                }

                if (cy > 0 && !used[cx][cy - 1])
                {
                    used[cx][cy - 1] = true;
                    qx.Enqueue(cx);
                    qy.Enqueue(cy - 1);
                }
            }*/
            var ast = new List<int>();
            var pointers = new int[n][];
            for (int i = 0; i < n; i++)
            {
                pointers[i] = new int[m];
                for (int j = 0; j < m; j++)
                {
                    pointers[i][j] = -1;
                }
            }
            int ind = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (g[i][j])
                    {
                        bool b1 = i > 0 && g[i-1][j];
                        bool b2 = j > 0 && g[i][j-1];
                        if (!b1 && !b2)
                        {
                            ast.Add(1);
                            pointers[i][j] = ind;
                            ind++;
                        }
                        else if (b1)
                        {
                            pointers[i][j] = pointers[i - 1][j];
                            ast[pointers[i][j]]++;
                        }
                        else if (b2)
                        {
                            pointers[i][j] = pointers[i][j-1];
                            ast[pointers[i][j]]++;
                        }
                    }
                }
            }

            var counts=new List< List<int> >(2);
            counts.Add(new List<int>());
            counts.Add(new List<int>());
            for (int i = 0; i < ast.Count; i++)
            {
                if (!counts[0].Contains(ast[i]))
                {
                    counts[0].Add(ast[i]);
                    counts[1].Add(1);
                }
                else
                {
                    counts[1][ast[i]]++;
                }
            }

            return counts;
        }
    }
}
