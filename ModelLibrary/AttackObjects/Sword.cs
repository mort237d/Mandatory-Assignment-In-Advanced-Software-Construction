using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLibrary.AttackObjects
{
    public class Sword : AttackBaseObject
    {
        public Sword()
        {
            Damage = 3;
            Speed = 1;
            Size = 1;
            Rarity1 = Rarity.COMMON;
        }
    }
}
