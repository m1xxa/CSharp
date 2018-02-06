using System;
using System.Runtime.Remoting.Contexts;
using System.Threading;

namespace QuerryExample
{
    class ShopAssistant
    {
        private readonly object _object = new object();
        public bool IsFree { get; set; } = true;

        public void Working()
        {
            lock (_object)
            {
                IsFree = !IsFree;
                Thread.Sleep(2000);
            }
            
        }
    }
}