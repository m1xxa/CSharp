using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadLockExample
{
    
    class Program
    {
        public static int x = 0;
        public static Object locker = new Object();
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                Thread thread = new Thread(new ThreadStart(Func));
                thread.Name = "Thread: " + i;
                thread.Start();
                thread.Join();
            }
            
            Console.WriteLine("end");
        }

        static void Func()
        {
            lock (locker)
            {
                for (int i = 0; i < 5; i++)
                {
                    x++;
                    Console.WriteLine(Thread.CurrentThread.Name + ", x = " + x);
                    Thread.Sleep(1000);
                }
            }           
        }
    }
}
