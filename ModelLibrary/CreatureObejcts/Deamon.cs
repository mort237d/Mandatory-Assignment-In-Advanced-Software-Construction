using System;

namespace ModelLibrary.CreatureObejcts
{
    public class Deamon : CreatureBaseObject
    {
        public Deamon()
        {
            BaseDamage = 1;
            BaseSpeed = 1;
            Size = 1;
            Difficulty1 = Difficulty.EASY;
            Life = 10;

            CalculateDamage();
        }

        public override void DeadText(CreatureBaseObject creatureBaseObject)
        {
            Console.WriteLine($"{this.Name} died to {creatureBaseObject.Name}");
        }

        public override void UpgradeWeapon(CreatureBaseObject creatureBaseObject)
        {
            Console.WriteLine($"{this.Name} have no upgrade for the weapon of {creatureBaseObject.Name}");
        }
    }
}
