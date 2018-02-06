using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadExample01
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread mainThread = new Thread(new ParameterizedThreadStart(Latency));
            Thread.CurrentThread.Name = "Main";
            mainThread.Name = "Latency";
            mainThread.Start(2000);

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(Thread.CurrentThread.Name + " " + i);
                Thread.Sleep(1000);
            }
        }

        public static void Latency(object value)
        {
            Console.WriteLine(Thread.CurrentThread.Name + "starded");
            Thread.Sleep((int)value);
            Console.WriteLine(Thread.CurrentThread.Name + "stopped");

        }
    }
}
