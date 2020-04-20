using System;
using System.Collections.Generic;
using System.Text;
using ModelLibrary.AttackObjects;
using ModelLibrary.CreatureObejcts;
using ModelLibrary.DefenceObjects;
using ModelLibrary.Objects;

namespace ModelLibrary.World
{
    public class Forest : BaseWorld
    {
        public Forest()
        {
            Size = new WorldObject[10,20];
            BaseObjects = new List<BaseObject>
            {
                new Chest(null, new Boot()),
                new Chest(new Bow(), new Helm()),
                new Rock(),
                new Rock(),
                new Rock(),
                new Tree(),
                new Tree(),
                new Tree(),
                new Tree(),
                new Tree()
            };
            CreatureBaseObjects = new List<CreatureBaseObject>
            {
                new Phoenix { AttackBaseObjects = new Sword() }, 
                new Snake(),
                new Deamon {AttackBaseObjects = new Bow(), DefenceBaseObjects = new List<DefenceBaseObject>{new Helm(), new Boot()}}
            };

            GiveObjectsCordinates();
            GiveCreaturesCordinates();
            EmptyWorld();
            PopulateWorld();
            DrawWorld();
        }
    }
}
