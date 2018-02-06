using System;
using System.Collections.Generic;
using System.Threading;

namespace QuerryExample
{
    class Program
    {
        static readonly Object Locker = new Object();

        static void Main(string[] args)
        {
            Random random = new Random();
            List<Buyer> listBuyers = new List<Buyer>();
            int idBuyer = 1;
            List<Stand> stands = InitStands();

            Console.WriteLine("Shop was open!");
            while (true)
            {
                Thread.Sleep(random.Next(0, 10) * 500);
                int numberOfBuyers = random.Next(0, 5);
                for (int i = 0; i < numberOfBuyers; i++)
                {
                    listBuyers.Add(new Buyer(idBuyer.ToString()));
                    idBuyer++;
                }

                for (int i = listBuyers.Count - 1; i>=0; i--)
                {
                    Buyer buyer = listBuyers[i];
                    if (!CheckForAllBuy(buyer))
                    {
                        Thread thread = new Thread(() => FindFreeAssistent(buyer, stands));
                        thread.Start();
                    }
                    else
                    {
                        listBuyers.Remove(listBuyers[i]);
                    }
                }
                
                if (listBuyers.Count == 0) break;
            }
            
        }

        private static void FindFreeAssistent(Buyer buyer, List<Stand> stands)
        {
            foreach (var stand in stands)
            {
                foreach (var assistant in stand.Assistants)
                {
                    if (assistant.IsFree)
                    {
                        if (stands.IndexOf(stand) == 0 && buyer.IsBuyFirst) continue;
                        if (stands.IndexOf(stand) == 1 && buyer.IsBuySecond) continue;
                        if (stands.IndexOf(stand) == 2 && buyer.IsBuyThird) continue;
                            
                        assistant.IsFree = false;
                        switch (stands.IndexOf(stand))
                        {
                            case 0:
                                assistant.Working();
                                Console.WriteLine($"Buyer {buyer.Id} bought 1 product " +
                                                  $"from seller {stand.Assistants.IndexOf(assistant) + 1}");
                                buyer.IsBuyFirst = true;
                                break;
                            case 1:
                                assistant.Working();
                                Console.WriteLine(
                                    $"Buyer {buyer.Id} bought 2 product " +
                                    $"from seller {stand.Assistants.IndexOf(assistant) + 1}");
                                buyer.IsBuySecond = true;
                                break;
                            case 2:
                                assistant.Working();
                                Console.WriteLine(
                                    $"Buyer {buyer.Id} bought 3 product " +
                                    $"from seller {stand.Assistants.IndexOf(assistant) + 1}");
                                buyer.IsBuyThird = true;
                                break;
                        }
                    }
                }
            }
        }

        private static bool CheckForAllBuy(Buyer buyer)
        {
            if (buyer.IsBuyFirst || buyer.IsBuySecond || buyer.IsBuyThird) return true;
            return false;
        }

        private static List<Stand> InitStands()
        {
            Random random = new Random();
            List<Stand> stands = new List<Stand>()
            {
                new StandOne(),
                new StandTwo(),
                new StandThree()
            };

            foreach (var stand in stands)
            {
                int rnd = random.Next(3, 6);
                for (int i = 0; i < rnd; i++)
                {
                    stand.Assistants.Add(new ShopAssistant());
                }
                Console.WriteLine($"{rnd} assistents in {stands.IndexOf(stand)+1} stand");

            }

            return stands;
        }
    }
}
