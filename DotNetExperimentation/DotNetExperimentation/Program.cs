using System;

namespace DotNetExperimentation
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Press a key to continue\n");
                Console.ReadKey();
                Threading threadClass = new Threading();
                threadClass.IncrementCounter();
                Console.ReadKey();
                threadClass.TryMultithreading();
                Console.ReadKey();
            }
        }
    }
}
