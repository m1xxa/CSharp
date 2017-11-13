using System;

namespace HomeWork02
{
    public class Archer : Units
    {
        public Archer(bool rangeAttack, int attackPower) : base(rangeAttack, attackPower)
        {
        }

        public override void Draw()
        {
            Console.WriteLine("Draw Archer");
        }

        public override void Attack()
        {
            Console.WriteLine("Archer attack");
        }
    }
}