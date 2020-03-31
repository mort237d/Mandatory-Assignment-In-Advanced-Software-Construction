using System;
using System.Collections.Generic;
using System.Text;
using ModelLibrary.AttackObjects;

namespace ModelLibrary.AttackDecorator
{
    public class Fiery : AttackDecorator
    {
        protected int FireDamage;

        public Fiery(AttackBaseObject attackBaseObject) : base(attackBaseObject)
        {
            Name = attackBaseObject.GetType().Name + " w/ " + this.GetType().Name;
            Damage = attackBaseObject.Damage;
            Speed = attackBaseObject.Speed;
            Size = attackBaseObject.Size;
            Rarity1 = Rarity.RARE;
            FireDamage = 3;
        }

        protected override void DrawWeapon()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{base.ToString()}, FireDamage: {FireDamage}";
        }
    }
}
