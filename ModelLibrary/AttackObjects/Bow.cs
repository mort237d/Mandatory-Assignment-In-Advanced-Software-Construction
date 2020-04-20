using System;

namespace ModelLibrary.AttackObjects
{
    public class Bow : AttackBaseObject
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
