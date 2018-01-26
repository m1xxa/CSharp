using System;

namespace EntityExample
{
    public class Order
    {
        public Guid Id { get; set; }

        public string OrderName { get; set; }

        public int Value { get; set; }

        public virtual Client IdClient { get; set; }
        
        

    }
}