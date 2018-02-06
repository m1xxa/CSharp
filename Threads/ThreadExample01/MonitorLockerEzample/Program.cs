using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MonitorLockerEzample
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
            }
        }

        static void Func()
        {
            try
            {
                Monitor.Enter(locker);
                for (int i = 0; i < 5; i++)
                {
                    x++;
                    Console.WriteLine(Thread.CurrentThread.Name + ", x = " + x);
                    Thread.Sleep(1000);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                Monitor.Exit(locker);
            }
                
            

        }
    }
}
