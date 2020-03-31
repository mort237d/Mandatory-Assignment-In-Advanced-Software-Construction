﻿using System;
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

        protected override void DrawWeapon()
        {
            Console.WriteLine("          />_________________________________\r\n[########[]_________________________________>\r\n         \\>");
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
