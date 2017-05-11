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
                ThreadingStuff threadClass = new ThreadingStuff();
                threadClass.TryMultithreading();
            }
        }
    }
}
