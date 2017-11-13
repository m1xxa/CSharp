using System;

namespace HomeWork02
{
    public abstract class Units : IDrawable, IMovable, IAttacker
    {
        public bool RangeAttack { get; set; }
        public int AttackPower { get; set; }

        public Units(bool rangeAttack, int attackPower)
        {
            RangeAttack = rangeAttack;
            AttackPower = attackPower;
        }

        public virtual void Draw()
        {
            Console.WriteLine("Draw unit");
        }

        public void Move()
        {
            Console.WriteLine("Move unit");
        }

        public void Jump()
        {
            Console.WriteLine("Jump unit");
        }

        public virtual void Attack()
        {
            Console.WriteLine($"Attack power: {AttackPower}");
        }

        public bool IsRangeAttack()
        {
            return RangeAttack;
        }

        public int GetAttackPower()
        {
            return AttackPower;
        }
    }
}