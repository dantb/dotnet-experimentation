using DeepCopyExpressionTreeHashSetIssue;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpressionTreesCopying
{
    class Program
    {
        static void Main(string[] args)
        {
            B b = new B();
            A a = new A(b);

            // result is true
            bool testEqualBeforeClone =
                object.ReferenceEquals(a.DependencyOnB.SetOfCs.First(), a.SharedC);

            // result is true
            bool containsBeforeClone = a.DependencyOnB.SetOfCs.Contains(a.SharedC);

            // make a clone
            A clonedA = a.DeepCopyByExpressionTree();

            // result is true
            bool testEqualAfterClone =
                object.ReferenceEquals(clonedA.DependencyOnB.SetOfCs.First(), clonedA.SharedC);

            // result is false
            bool contains = clonedA.DependencyOnB.SetOfCs.Contains(clonedA.SharedC);

            Console.ReadKey();
        }


        public class A
        {
            public B DependencyOnB;
            public C SharedC = new C();

            public A(B dep)
            {
                DependencyOnB = dep;
                DependencyOnB.SetOfCs.Add(SharedC);
            }
        }

        public class B
        {
            public HashSet<C> SetOfCs { get; } = new HashSet<C>();
        }

        public class C { }
    }
}
