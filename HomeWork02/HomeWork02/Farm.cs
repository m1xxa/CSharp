using System;

namespace HomeWork02
{
    public class Farm : Buildings
    {
        public Farm(int health, string name) : base(health, name)
        {
        }

        public override void Produce()
        {
            Console.WriteLine("Produce peon");
        }

        public override void Draw()
        {
            Console.WriteLine("Draw farm");
        }
    }
}