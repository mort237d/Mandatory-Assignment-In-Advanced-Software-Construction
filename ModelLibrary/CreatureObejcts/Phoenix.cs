using System;
using System.Collections.Generic;
using System.Text;
using ModelLibrary.AttackDecorator;
using ModelLibrary.AttackObjects;

namespace ModelLibrary.CreatureObejcts
{
    public class Phoenix : CreatureBaseObject
    {
        public Phoenix()
        {
            BaseDamage = 3;
            BaseSpeed = 3;
            Size = 2;
            Difficulty1 = Difficulty.NORMAL;
            Life = 20;
            
            CalculateDamage();
        }

        public Fiery FireUpgrade(AttackBaseObject attackBaseObject)
        {
            Fiery fiery = new Fiery(attackBaseObject);
            return fiery;
        }

        public override void DeadText(CreatureBaseObject creatureBaseObject)
        {
            Console.WriteLine($"{this.Name} died to {creatureBaseObject.Name}");
        }

        public override void UpgradeWeapon(CreatureBaseObject creatureBaseObject)
        {
            if (creatureBaseObject.EquipedAttackBaseObject != null) creatureBaseObject.EquipedAttackBaseObject = FireUpgrade(creatureBaseObject.EquipedAttackBaseObject);
            Console.WriteLine($"{this.Name} upgrades the weapon of {creatureBaseObject.Name} with fiery");
        }
    }
}
