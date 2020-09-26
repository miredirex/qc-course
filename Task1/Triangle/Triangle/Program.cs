using System;

namespace Triangle
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                Console.Write("Invalid arguments count");
                return;
            }

            try
            {
                var a = double.Parse(args[0]);
                var b = double.Parse(args[1]);
                var c = double.Parse(args[2]);

                var triangle = new Triangle(a, b, c);

                Console.Write(triangle.Type.ToString());
            }
            catch (ArgumentException)
            {
                Console.Write("Impossible to construct a triangle");
            }
            catch (Exception e)
            {
                if (e is FormatException || e is OverflowException)
                    Console.Write("Error");
            }
        }
    }
}