using System;

namespace ModelLibrary.AttackObjects
{
    public class Axe : AttackBaseObject
    {
        public Axe()
        {
            Damage = 2;
            Speed = 2;
            Size = 1;
            Rarity1 = Rarity.COMMON;
        }
    }
}
