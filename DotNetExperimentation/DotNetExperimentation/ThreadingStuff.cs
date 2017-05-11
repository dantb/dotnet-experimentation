using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetExperimentation
{
    public class ThreadingStuff
    {
        public void TryMultithreading()
        {
            SomeClass aClass = new SomeClass();

            Thread thread = new Thread(() => aClass.DoSomething("A"));
            thread.Start();

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

    }
}
