using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoResetEventExample
{
    class Program
    {
        static AutoResetEvent waitHandler = new AutoResetEvent(true);
        public static int x = 0;

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
            waitHandler.WaitOne();

            for (int i = 0; i < 5; i++)
            {
                x++;
                Console.WriteLine(Thread.CurrentThread.Name + ", x = " + x);
                Thread.Sleep(1000);
            }

            waitHandler.Set();
        }
    }
}
