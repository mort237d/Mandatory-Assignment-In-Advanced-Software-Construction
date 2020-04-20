using System.Collections.Generic;
using ModelLibrary.AttackObjects;
using ModelLibrary.CreatureObejcts;
using ModelLibrary.DefenceObjects;
using ModelLibrary.Objects;

namespace ModelLibrary.World
{
    public class Volcano : BaseWorld
    {
        public Volcano()
        {
            Size = new WorldObject[10, 10];

            List<WorldObject> wo = new List<WorldObject>();
            wo.AddRange(BaseObjects);
            wo.AddRange(CreatureBaseObjects);

            GiveCordinates(wo);
            EmptyWorld();
            PopulateWorld();
            DrawWorld();
        }

        public override void CreateCreatures()
        {
            CreatureBaseObjects.Add(new Phoenix { EquipedAttackBaseObject = new Sword() });
            CreatureBaseObjects.Add(new FireGolem());
            CreatureBaseObjects.Add(new Deamon { EquipedAttackBaseObject = new Bow(), DefenceBaseObjects = new List<DefenceBaseObject> { new Helm(), new Boot() } });
        }

        public override void CreateObjects()
        {
            BaseObjects.Add(new Chest(null, new Boot()));
            BaseObjects.Add(new Chest(new Bow(), new Helm()));
            for (int i = 0; i < 4; i++) BaseObjects.Add(new Rock());
            for (int i = 0; i < 8; i++) BaseObjects.Add(new Lava());
        }
    }
}
