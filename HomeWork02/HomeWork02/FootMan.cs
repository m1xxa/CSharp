using System;

namespace HomeWork02
{
    public class FootMan : Units
    {
        public FootMan(bool rangeAttack, int attackPower) : base(rangeAttack, attackPower)
        {
        }

        public override void Draw()
        {
            Console.WriteLine("Draw Footman");
        }

        public override void Attack()
        {
            Console.WriteLine("Footman Attack");
        }
    }
}