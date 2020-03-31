using System;
using System.Collections.Generic;
using System.Text;
using ModelLibrary.AttackDecorator;
using ModelLibrary.AttackObjects;

namespace ModelLibrary.CreatureObejcts
{
    class Phoenix : CreatureBaseObject
    {
        public Phoenix()
        {
            BaseDamage = 3;
            BaseSpeed = 3;
            Size = 2;
            Difficulty1 = Difficulty.NORMAL;
            Life = 20;
        }

        public Fiery FireUpgrade(AttackBaseObject attackBaseObject)
        {
            Fiery fiery = new Fiery(attackBaseObject);
            return fiery;
        }
    }
}
