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
            Size = new WorldObject[20, 20];

            BaseObjects = new List<BaseObject>
            {
                new Chest(null, new Boot()),
                new Chest(new Bow(), new Helm()),
                new Rock(),
                new Rock(),
                new Rock(),
                new Lava(),
                new Lava(),
                new Lava(),
                new Lava(),
                new Lava()
            };

            CreatureBaseObjects = new List<CreatureBaseObject>
            {
                new Phoenix { EquipedAttackBaseObject = new Sword() },
                new FireGolem(),
                new Deamon {EquipedAttackBaseObject = new Bow(), DefenceBaseObjects = new List<DefenceBaseObject>{new Helm(), new Boot()}}
            };

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
            throw new System.NotImplementedException();
        }

        public override void CreateObjects()
        {
            throw new System.NotImplementedException();
        }
    }
}
