using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetExperimentation
{
    public class Threading
    {
        private int counter = 0;

        /// <summary>
        /// Interesting example taken off this Jon Skeet article: http://jonskeet.uk/csharp/threads/locking.shtml
        /// This simulates us incrementing the counter on multiple threads.
        /// Since an increment is actually a read, increment and write there is possiblity of one thread
        /// incrementing an out of date value
        /// </summary>
        public void IncrementCounter()
        {
            ThreadStart job = new ThreadStart(IncrementCounterDifferentThread);
            Thread thread = new Thread(job);
            thread.Start();

            for (int i = 0; i < 5; i++)
            {
                int tmp = counter;
                Console.WriteLine("Read count={0}", tmp);
                Thread.Sleep(50);
                tmp++;
                Console.WriteLine("Incremented tmp to {0}", tmp);
                Thread.Sleep(20);
                counter = tmp;
                Console.WriteLine("Written count={0}", tmp);
                Thread.Sleep(30);
            }

            thread.Join();
            Console.WriteLine("Final count: {0}", counter);
        }

        private void IncrementCounterDifferentThread()
        {
            int tmp = counter;
            Console.WriteLine("\t\t\t\tRead count={0}", tmp);
            Thread.Sleep(20);
            tmp++;
            Console.WriteLine("\t\t\t\tIncremented tmp to {0}", tmp);
            Thread.Sleep(10);
            counter = tmp;
            Console.WriteLine("\t\t\t\tWritten count={0}", tmp);
            Thread.Sleep(40);
        }

        public void TryMultithreading()
        {
            SomeClass aClass = new SomeClass();

            Thread thread = new Thread(() => aClass.DoSomethingContinuously("A"));
            thread.Start();

            while (!thread.IsAlive);

            //set task off
            Task theTask = new Task(() => aClass.DoSomething("B"));
            theTask.Start();
            theTask.Wait();

            //now just call it here
            aClass.DoSomething("C");
        }

    }

    public class SomeClass
    {
        private int _someMember; 

        public void DoSomething(string thread)
        {
            Console.WriteLine($"Thread {thread}, counter value {_someMember}");
            _someMember++;
        }

        public void DoSomethingContinuously(string thread)
        {
            Console.WriteLine($"Thread {thread}, counter value {_someMember}");
            _someMember++;
        }
    }
}
