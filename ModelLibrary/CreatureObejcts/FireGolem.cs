using System;
using ModelLibrary.AttackDecorator;
using ModelLibrary.AttackObjects;

namespace ModelLibrary.CreatureObejcts
{
    class FireGolem : CreatureBaseObject
    {
        public FireGolem()
        {
            BaseDamage = 5;
            BaseSpeed = 1;
            Size = 1;
            Difficulty1 = Difficulty.NORMAL;
            Life = 30;

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
