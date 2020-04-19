using System;
using System.Collections.Generic;
using System.Text;

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

        protected override void DrawWeapon()
        {
            Console.WriteLine("              +-+\r\n=============| |\r\n            `:_;'");
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
