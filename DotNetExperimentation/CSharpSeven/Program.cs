using System;

namespace CSharpSeven
{
    class Program
    {
        static void Main(string[] args)
        {
            int bigNumber = 1_000_000_000;

            WriteBigNumber();

            var result = Calculate(234, 456);
            WriteLine($"Sum is {result.Sum} and product is {result.Product}");

            WriteLine("Press any key to exit...");
            Console.ReadKey();

            void WriteLine(string message)
            {
                Console.WriteLine(message);
            }

            void WriteBigNumber()
            {
                WriteLine("Big number is " + bigNumber);
            }
        }

        private static (double Sum, double Product) Calculate(double x, double y)
        {
            return (x + y, x * y);
        }
    }
}
