namespace Exs_01_Awesome_Numbers
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {

            int number = int.Parse(Console.ReadLine());
            int joroNumber = int.Parse(Console.ReadLine());
            int counter = 0;
            if (number < 0)
            {
                number *= -1;
                counter++;
            }
            if (number % 2 == 1) counter++;
            if (number % joroNumber == 0) counter++;
            string s = string.Empty;
            switch (counter)
            {
                case 0:
                    s = "boring";
                    break;
                case 1:
                    s = "awesome";
                    break;
                case 2:
                    s = "super awesome";
                    break;
                case 3:
                    s = "super special awesome";
                    break;
            }

            Console.WriteLine(s);

        }
    }
}
