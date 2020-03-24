using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLibrary.AttackObjects
{
    class Bow : AttackBaseObject
    {
        public Bow()
        {
            Damage = 3;
            Speed = 3;
            Size = 2;
            Rarity1 = Rarity.RARE;
        }
    }
}
