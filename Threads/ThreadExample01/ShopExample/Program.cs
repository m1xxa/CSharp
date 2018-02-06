using System;
using System.Threading;

namespace ShopExample
{

    class Program
    {
        private static readonly object Object = new object();
        static void Main()
        {
            Random random = new Random();
            int nameIndex = 0;

            while (true)
            {
                int rnd = random.Next(0, 2);
                if (rnd == 1)
                {
                    for (int i = 0; i < 20; i++)
                    {
                        Thread thread = new Thread(Buyer);
                        thread.Name = nameIndex.ToString();
                        nameIndex++;
                        thread.Start();
                    }
                    Console.WriteLine("Customers add");
                   
                }
                Thread.Sleep(5000);
                if(rnd == 10) return;
            }

        }

        static void Buyer()
        {
            Random random = new Random();
            int apple = 0;
            int tomatos = 0;
            int index = 0;

            while (index < 10)
            {
                int rnd = random.Next(0, 3);
                if (rnd == 1)
                {
                    lock (Object)
                    {
                        apple++;
                        Storage.Apple--;
                        index++;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(
                            $"Buyer: {Thread.CurrentThread.Name} buy apple, left {Storage.Apple} {Storage.Tomatos}");
                        Console.ResetColor();
                    }
                }
                else if (rnd == 2)
                {
                    lock (Object)
                    {
                        tomatos++;
                        Storage.Tomatos--;
                        index++;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"Buyer: {Thread.CurrentThread.Name} buy tomatos, left {Storage.Apple} {Storage.Tomatos}");
                        Console.ResetColor();
                    }
                }
                Thread.Sleep(2000);
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Buyer: {Thread.CurrentThread.Name} buy apple {apple}, tomatos {tomatos}");
            Console.ResetColor();
        }
    }

    

    static class Storage
    {
        public static int Apple { get; set; } = 10000;
        public static int Tomatos { get; set; } = 10000;
    }
}
