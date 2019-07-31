using System;
using System.Collections.Generic;
using System.Linq;

namespace Exs_08_Logistics
{
    public class Package
    {
        public Package(int price, int deadline)
        {
            this.Price = price;
            this.Deadline = deadline;
        }

        public int Price { get; set; }

        public int Deadline { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var packages=new Package[n + 1];
            var crashes = new List<int>();
            for (int i = 1; i < n; i++)
            {
                var param = Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                packages[i]=new Package(param[0],param[1]);
            }

            string input = Console.ReadLine();
            if(input != "none")
            crashes = input
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            var days=new List<int>();
            days.Add(0);
            for (int i = 1; i < packages.Select(x=>x.Deadline).Max(); i++)
            {
                days.Add(packages.Where(x=>x.Deadline==i).Count());
            }
        }
    }
}
