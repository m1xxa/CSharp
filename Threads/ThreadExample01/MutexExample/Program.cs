using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MutexExample
{
    class Program
    {
        public static int x = 0;
        public static Mutex mutex = new Mutex();

        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                Thread thread = new Thread(new ThreadStart(Func));
                thread.Name = "Thread: " + i;
                thread.Start();
            }
        }

        static void Func()
        {
            mutex.WaitOne();

            for (int i = 0; i < 20; i++)
            {
                x++;
                Console.WriteLine(Thread.CurrentThread.Name + ", x = " + x);
                Thread.Sleep(1000);
            }
            
            mutex.ReleaseMutex();
        }
    }
}
