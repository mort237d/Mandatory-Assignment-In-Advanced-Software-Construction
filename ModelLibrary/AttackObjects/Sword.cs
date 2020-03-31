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

        protected override void DrawWeapon()
        {
            Console.WriteLine("       /| ________________\r\nO|===|* >________________>\r\n      \\|");
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
