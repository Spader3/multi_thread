using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var locker = new Object();
            int count = 0;
            Parallel.For
                (0
                 , 10000
                 , new ParallelOptions { MaxDegreeOfParallelism = 1 }
                 , (i) =>
                 {
                     Interlocked.Increment(ref count);
                     lock (locker)
                     {
                         Console.WriteLine("Number of active threads:" + count);
                         Thread.Sleep(10);
                     }
                     Interlocked.Decrement(ref count);
                 }
                );
        }
    }
}
