using System;

namespace Triangle
{
    public enum TriangleType
    {
        Scalene,
        Isosceles,
        Equilateral
    }

    public struct Triangle
    {
        public double A, B, C;

        public Triangle(double a, double b, double c)
        {
            if (a + b > c && a + c > b && b + c > a)
            {
                A = a;
                B = b;
                C = c;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public TriangleType Type
        {
            get
            {
                if (!DoublesEqual(A, B) && !DoublesEqual(B, C) && !DoublesEqual(A, C))
                    return TriangleType.Scalene;

                if (DoublesEqual(A, B) && DoublesEqual(A, C) && DoublesEqual(B, C))
                    return TriangleType.Equilateral;

                return TriangleType.Isosceles;
            }
        }

        public static bool DoublesEqual(double first, double second, double tolerance = double.Epsilon)
        {
            return Math.Abs(first - second) < tolerance;
        }
    }
}