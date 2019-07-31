namespace Exs_05_Circumscribed_Circle
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input1 = Console.ReadLine().Remove(0, 7);
                var input2 = Console.ReadLine().Remove(0, 9);
                var c = input1
                    .Split(new []{ ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();
                var t = input2
                    .Split(new[] { ' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();
                double pX = c[0];
                double pY = c[1];
                double pR = c[2];
                var circle = new Circle(new Point(pX,pY), pR);

                double p1X = t[0];
                double p1Y = t[1];
                double p2X = t[2];
                double p2Y = t[3];
                double p3X = t[4];
                double p3Y = t[5];

                var triangle = new Triangle(new Point(p1X, p1Y), 
                                            new Point(p2X, p2Y), 
                                            new Point(p3X, p3Y));
                string s = string.Empty;
                bool isCircumscribed = circle.IsCircumscribedAround(triangle);
                bool isCenterInside = circle.IsCenterInside(triangle);
                if (isCircumscribed)
                {
                    s = isCenterInside ? 
                        "The circle is circumscribed and the center is inside." : 
                        "The circle is circumscribed and the center is outside.";
                }
                else
                {
                    s = isCenterInside ? 
                        "The circle is not circumscribed and the center is inside." : 
                        "The circle is not circumscribed and the center is outside.";
                }

                Console.WriteLine(s);
            }
        }

        class Point
        {
            public Point(double x, double y)
            {
                this.X = x;
                this.Y = y;
            }

            public double X { get; }

            public double Y { get; }

            public double X_DiffWith(Point p)
                => Math.Abs(this.X - p.X);

            public double Y_DiffWith(Point p)
                => Math.Abs(this.Y - p.Y);
            
            public double DistanceTo(Point p)
                => Math.Sqrt(this.X_DiffWith(p) * this.X_DiffWith(p) + 
                                        this.Y_DiffWith(p) * this.Y_DiffWith(p));
        }

        /*
        class Line
        {
            public Line(Point p1, Point p2)
            {
                this.A = p1.Y - p2.Y;
                this.B = p2.X - p1.X;
                this.C = p1.X * p2.Y - p1.Y * p2.X;
            }

            public Line(double a, double b, double c)
            {
                this.A = a;
                this.B = b;
                this.C = c;
            }

            public double A { get; }

            public double B { get; }

            public double C { get; }

            public Point IntersectionPointWith(Line line)
            {
                double denominator = this.A * line.B - line.A * this.B;
                if (denominator.Equals(0.0)) return null;
                double x = ((-this.C) * line.B - (-line.C) * this.B) / denominator;
                double y = (this.A * (-line.C) - line.A * (-this.A)) / denominator;
                return new Point(x, y);
            }

            public double DistanceFrom(Point p)
            {
                var perpendicularLine = new Line(this.B, -this.A, this.A * p.Y - this.B * p.X);
                var intersectionPoint = this.IntersectionPointWith(perpendicularLine);
                return p.DistanceTo(intersectionPoint);
            }
        }
        */

        class Triangle
        {
            public Triangle(Point p1, Point p2, Point p3)
            {
                this.P1 = p1;
                this.P2 = p2;
                this.P3 = p3;
            }

            public Point P1 { get; }

            public Point P2 { get; }

            public Point P3 { get; }

            public double Area()
            {
                /*
                 *                 w
                 *      |---------------------. P3
                 *      |    S3   ////////////|
                 *   P1 . ///////           / |
                 *      |\                 /  |
                 *      |   \       S     /   | h
                 *      |      \         /    |
                 *      |   S1    \     /  S2 |
                 *      |            \ /      |
                 *      |-------------.-------|
                 *                    P2
                 * S = w * h - (S1 + S2 + S3)
                 */
                /*double width = new double[]{this.P1.X_DiffWith(this.P2),
                                            this.P2.X_DiffWith(this.P3),
                                            this.P1.X_DiffWith(this.P3)}.Max();
                double height = new double[]{this.P1.Y_DiffWith(this.P2),
                                             this.P2.Y_DiffWith(this.P3),
                                             this.P1.Y_DiffWith(this.P3)}.Max();
                double s1 = 0.5 * this.P1.X_DiffWith(this.P2) * this.P1.Y_DiffWith(this.P2);
                double s2 = 0.5 * this.P2.X_DiffWith(this.P3) * this.P2.Y_DiffWith(this.P3);
                double s3 = 0.5 * this.P1.X_DiffWith(this.P3) * this.P1.Y_DiffWith(this.P3);
                return width * height - (s1 + s2 + s3);*/
                return (this.P1.X * (this.P2.Y - this.P3.Y) +
                       this.P2.X * (this.P3.Y - this.P1.Y) +
                       this.P3.X * (this.P1.Y - this.P2.Y)) / 2;
            }
        }

        class Circle
        {
            public Circle(Point p, double r)
            {
                this.P = p;
                this.R = r;
            }

            public Point P { get; }

            public double R { get; }

            public bool IsCircumscribedAround(Triangle t)
            {
                double distanceToP1 = this.P.DistanceTo(t.P1);
                double distanceToP2 = this.P.DistanceTo(t.P2);
                double distanceToP3 = this.P.DistanceTo(t.P3);
                return Math.Abs(distanceToP1 - this.R) < 0.01 &&
                       Math.Abs(distanceToP2 - this.R) < 0.01 &&
                       Math.Abs(distanceToP3 - this.R) < 0.01;
            }

            /// <summary>
            /// It calculates the sum of all areas of triangles,
            /// built with one side from triangle and the circle center,
            /// and if is equal to the area of triangle,
            /// then the circle center is inside triangle
            /// </summary>
            /// <param name="t"></param>
            /// <returns></returns>
            public bool IsCenterInside(Triangle triangle)
            {
                bool isInside = false;
                bool b1, b2, b3;
                b1 = sign(this.P, triangle.P1, triangle.P2) < 0.0f;
                b2 = sign(this.P, triangle.P2, triangle.P3) < 0.0f;
                b3 = sign(this.P, triangle.P3, triangle.P1) < 0.0f;
                isInside = ((b1 == b2) && (b2 == b3));
                return isInside;
            }

            public double sign(Point point, Point point1, Point point2)
            {
                return (point.X - point2.X) * (point1.Y - point2.Y) - (point1.X - point2.X) * (point.Y - point2.Y);
            }
        }
    }
}
