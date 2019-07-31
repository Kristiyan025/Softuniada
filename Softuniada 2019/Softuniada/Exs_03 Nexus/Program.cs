using System;
using System.Linq;

namespace Exs_03_Nexus
{
    class Program
    {
        static void Main(string[] args)
        {
            var first = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            var second = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "nexus")
                {
                    break;
                }

                var cons = input.Split(new[] {'|'}).ToArray();
                var firstCon = cons[0].Split(new[] {':'}).Select(int.Parse).ToArray();
                var secondCon = cons[1].Split(new[] {':'}).Select(int.Parse).ToArray();
                int f11 = firstCon[0];
                int f12 = firstCon[1];
                int f21 = secondCon[0];
                int f22 = secondCon[1];
                bool isCross = false;
                if ((f11 < f21 && f22 < f12) ||
                    (f11 > f21 && f22 > f12))
                {
                    isCross = true;
                }

                if (isCross)
                {
                    int sum = first[f11] + first[f21] + second[f12] + second[f22];
                    var a1 = new[] {f11, f21};
                    var a2 = new[] {f12, f22};
                    for (int i = a1.Min(); i <= a1.Max(); i++)
                    {
                        first.RemoveAt(a1.Min());
                    }
                    for (int i = a2.Min(); i <= a2.Max(); i++)
                    {
                        second.RemoveAt(a2.Min());
                    }
                    //first.RemoveRange(a1.Min(), a1.Max() - a1.Min() + 1);
                    //second.RemoveRange(a2.Min(), a2.Max() - a2.Min() + 1);
                    for (int i = 0; i < first.Count; i++)
                    {
                        first[i] += sum;
                    }

                    for (int i = 0; i < second.Count; i++)
                    {
                        second[i] += sum;
                    }
                }
            }

            Console.WriteLine(string.Join(", ", first));
            Console.WriteLine(string.Join(", ", second));
        }
    }
}
