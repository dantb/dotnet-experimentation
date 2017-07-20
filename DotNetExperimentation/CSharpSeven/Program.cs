using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeven
{
    class Program
    {
        static void Main(string[] args)
        {
            int bigNumber = 1_000_000_000;

            WriteBigNumber();

            WriteLine("Press any key to exit...");
            Console.ReadKey();

            void WriteLine(string message)
            {
                Console.WriteLine(message);
            }

            void WriteBigNumber()
            {
                WriteLine(bigNumber.ToString());
            }
        }
    }
}
