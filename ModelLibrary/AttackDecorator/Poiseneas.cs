using System;
using ModelLibrary.AttackObjects;

namespace ModelLibrary.AttackDecorator
{
    public class Poiseneas : AttackDecorator
    {
        protected int PoisonDamage;

        public Poiseneas(AttackBaseObject attackBaseObject) : base(attackBaseObject)
        {
            Name = attackBaseObject.GetType().Name + " w/ " + this.GetType().Name;
            Damage = attackBaseObject.Damage;
            Speed = attackBaseObject.Speed;
            Size = attackBaseObject.Size;
            Rarity1 = Rarity.RARE;
            PoisonDamage = 2;

            Damage += PoisonDamage;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, PoisonDamage: {PoisonDamage}";
        }
    }
}
