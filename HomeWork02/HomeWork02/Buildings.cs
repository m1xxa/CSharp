using System;

namespace HomeWork02
{
    public abstract class Buildings : IDrawable
    {
        private int _health;
        private string _name;

        protected Buildings(int health, string name)
        {
            _health = health;
            _name = name;
        }

        public virtual void Draw()
        {
            Console.WriteLine("Draw building");
        }

        public abstract void Produce();
    }
}