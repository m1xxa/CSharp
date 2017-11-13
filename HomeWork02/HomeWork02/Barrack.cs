using System;

namespace HomeWork02
{
    public class Barrack : Buildings
    {
        public Barrack(int health, string name) : base(health, name)
        {
        }

        public override void Produce()
        {
            Console.WriteLine("Produce rider");
        }
        public override void Draw()
        {
            Console.WriteLine("Draw barrack");
        }

    }
}