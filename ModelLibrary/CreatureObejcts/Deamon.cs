using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLibrary.CreatureObejcts
{
    class Deamon : CreatureBaseObject
    {
        public Deamon()
        {
            BaseDamage = 1;
            BaseSpeed = 1;
            Size = 1;
            Difficulty1 = Difficulty.EASY;
            Life = 10;
        }
    }
}
