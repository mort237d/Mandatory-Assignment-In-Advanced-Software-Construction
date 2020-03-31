using System;
using System.Collections.Generic;
using System.Text;
using ModelLibrary.AttackDecorator;
using ModelLibrary.AttackObjects;

namespace ModelLibrary.CreatureObejcts
{
    class Snake : CreatureBaseObject
    {
        public Snake()
        {
            BaseDamage = 1;
            BaseSpeed = 1;
            Size = 1;
            Difficulty1 = Difficulty.EASY;
            Life = 9;
        }

        public Poiseneas PoisonUpgrade(AttackBaseObject attackBaseObject)
        {
            Poiseneas poiseneas = new Poiseneas(attackBaseObject);
            return poiseneas;
        }
    }
}
