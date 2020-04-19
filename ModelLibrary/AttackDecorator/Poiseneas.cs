using System;
using System.Collections.Generic;
using System.Text;
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

        protected override void SingleAttack()
        {
            throw new NotImplementedException();
        }

        protected override void ComboAttack()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{base.ToString()}, PoisonDamage: {PoisonDamage}";
        }
    }
}
