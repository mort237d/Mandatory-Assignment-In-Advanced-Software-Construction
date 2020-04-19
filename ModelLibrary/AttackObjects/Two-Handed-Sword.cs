using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLibrary.AttackObjects
{
    public class Two_Handed_Sword : AttackBaseObject
    {
        public Two_Handed_Sword()
        {
            Damage = 5;
            Speed = 1;
            Size = 2;
            Rarity1 = Rarity.COMMON;
        }

        protected override void SingleAttack()
        {
            throw new NotImplementedException();
        }

        protected override void ComboAttack()
        {
            throw new NotImplementedException();
        }
    }
}
