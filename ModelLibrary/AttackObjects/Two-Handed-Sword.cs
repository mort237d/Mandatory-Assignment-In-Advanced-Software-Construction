using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLibrary.AttackObjects
{
    class Two_Handed_Sword : AttackBaseObject
    {
        public Two_Handed_Sword()
        {
            Damage = 5;
            Speed = 1;
            Size = 2;
            Rarity1 = Rarity.COMMON;
        }
    }
}
