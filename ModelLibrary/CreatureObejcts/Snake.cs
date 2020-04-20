using System;
using ModelLibrary.AttackDecorator;
using ModelLibrary.AttackObjects;

namespace ModelLibrary.CreatureObejcts
{
    public class Snake : CreatureBaseObject
    {
        public Snake()
        {
            BaseDamage = 1;
            BaseSpeed = 1;
            Size = 1;
            Difficulty1 = Difficulty.EASY;
            Life = 9;

            CalculateDamage();
        }

        public Poiseneas PoisonUpgrade(AttackBaseObject attackBaseObject)
        {
            Poiseneas poiseneas = new Poiseneas(attackBaseObject);
            return poiseneas;
        }

        public override void DeadText(CreatureBaseObject creatureBaseObject)
        {
            Console.WriteLine($"{this.Name} died to {creatureBaseObject.Name}");
        }

        public override void UpgradeWeapon(CreatureBaseObject creatureBaseObject)
        {
            if (creatureBaseObject.EquipedAttackBaseObject != null) creatureBaseObject.EquipedAttackBaseObject = PoisonUpgrade(creatureBaseObject.EquipedAttackBaseObject);
            Console.WriteLine($"{this.Name} upgrades the weapon of {creatureBaseObject.Name} with poision");
        }
    }
}
